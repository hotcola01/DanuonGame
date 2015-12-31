using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	#region Variable
	public LeanTouchTester leanTouchTester;
	public RippleEffect rippleEffect;

	public UIScaler labelScalerCombo;
	public UIScaler labelScalerScore;
	public UIScaler labelScalerMaxCombo;
	public UIScaler labelScalerMultiply;




	private int combo;
	private int maxCombo;
	private int score;
	private int multiply;


	private MusicManager musicManager;
	private UIManager uiManager;

	// notes
	private LivePlayNotes livePlayNotes;
	private List<PlayNoteInfo>[] touchableNotes = new List<PlayNoteInfo>[(int)TouchSectorType.NumberOfTouchSectorType];
	private int miss;
	private int good;
	public float goodTime = 0.25f;
	private int[] multiplyComboCounts = new int[Defines.Multiply_SectorCount];
	#endregion





	#region MonoBehaviour
	void Start () 
	{
		musicManager = Common.GetGameManager ().musicManager;
		uiManager = Common.GetGameManager ().uiManager;

		leanTouchTester.TouchEvent = TouchEvent;

		livePlayNotes = LiveManager.Instance.livePlayNotes;

		multiplyComboCounts [0] = 0;
		multiplyComboCounts [1] = 10;
		multiplyComboCounts [2] = 30;
		multiplyComboCounts [3] = 50;
		multiplyComboCounts [4] = 100;
		multiplyComboCounts [5] = 200;
		multiplyComboCounts [6] = 100000;

		for(int i=0; i<(int)TouchSectorType.NumberOfTouchSectorType; i++)
		{
			touchableNotes[i] = new List<PlayNoteInfo>();
		}


		Reset ();
	}
	
	void Update () 
	{
		if(musicManager.IsPlayBGM())
		{
			CheckTouchableNote ();
			if(CheckMissNote())
			{
				MissNote ();
			}
		}
	}
	#endregion





	#region Implements
	void Reset()
	{
		miss = 0;
		good = 0;

		combo = 0;
		maxCombo = 0;
		score = 0;
		multiply = 1;


		uiManager.UpdateGameData (score, combo, maxCombo, multiply);


		for(int i=0; i<touchableNotes.Length; i++)
		{
			touchableNotes[i].Clear();
		}
	}

	void TouchEvent(Vector2 pos)
	{
		// ripple
		float x = pos.x / Screen.width;
		float y = pos.y / Screen.height;
		rippleEffect.Emit (new Vector2 (x, y));

	

		// touch sectoraudioSourceBgm.time
		float centerx = Screen.width * 0.5f;
		float centery = Screen.height * 0.5f;


		// left
		if(pos.x < centerx)
		{
			// bottom
			if(pos.y < centery)
			{
				if(IsGoodTouch(TouchSectorType.TST_LeftBottom))
				{
					GoodNote(TouchSectorType.TST_LeftBottom);
				}
			}
			// top
			else
			{
				if(IsGoodTouch(TouchSectorType.TST_LeftTop))
				{
					GoodNote(TouchSectorType.TST_LeftTop);
				}
			}
		}
		// right
		else
		{
			// bottom
			if(pos.y < centery)
			{
				if(IsGoodTouch(TouchSectorType.TST_RightBottom))
				{
					GoodNote(TouchSectorType.TST_RightBottom);
				}
			}
			// top
			else
			{
				if(IsGoodTouch(TouchSectorType.TST_RightTop))
				{
					GoodNote(TouchSectorType.TST_RightTop);
				}
			}
		}
	}

	void CheckTouchableNote()
	{
		PlayNoteInfo pni = livePlayNotes.GetPlayableNoteInfo(musicManager.GetPlayTime());
		if(pni != null && pni.effectIndex < 4)
		{
			musicManager.PlayEffectSound(pni.effectIndex);
			pni.prePlayed = true;
			touchableNotes[pni.effectIndex].Add(pni);
		}
	}

	bool CheckMissNote()
	{
		float currentTime = musicManager.GetPlayTime();
		for(int i=0; i<touchableNotes.Length; i++)
		{
			for(int j=0; j<touchableNotes[i].Count; j++)
			{
				if(touchableNotes[i][j].playTime + goodTime < currentTime)
				{
					touchableNotes[i].RemoveAt(j);
					return true;
				}
			}
		}

		return false;
	}

	void MissNote()
	{
		// miss sound play
		musicManager.PlayEffectSoundMiss ();

		// miss count
		miss++;

		// combo reset
		combo = 0;
		uiManager.panelGame.Combo (combo);

		// multiply reset
		multiply = 1;
		uiManager.panelGame.Multiplay (multiply);
	}

	bool IsGoodTouch(TouchSectorType touchSectorType)
	{
		int type = (int)touchSectorType;
		float playTime = musicManager.GetPlayTime ();
		for(int i=0; i<touchableNotes[type].Count; i++)
		{
			if(playTime >= touchableNotes[type][i].playTime - goodTime &&
			   playTime < touchableNotes[type][i].playTime + goodTime)
			{
				touchableNotes[type].RemoveAt(i);
				return true;
			}
		}

		return false;
	}

	void GoodNote(TouchSectorType type)
	{
		// good count
		good++;

		// combo
		combo++;
		Combo ();

		// max combo
		if(combo > maxCombo)
		{
			maxCombo = combo;
			MaxCombo ();
		}

		// score
		score += Defines.Default_NoteToScore * multiply;
		Score ();

		// multiply
		int mf = 1;
		for(int i=1; i<Defines.Multiply_SectorCount-1; i++)
		{
			if(combo >= multiplyComboCounts[i] &&
			   combo <  multiplyComboCounts[i+1])
			{
				mf = i * 2;
			}
		}

		if(mf > multiply)
		{
			multiply = mf;
			Multiply ();
		}
	}





	void Score()
	{
		uiManager.panelGame.Score (score);
		if(labelScalerScore)		labelScalerScore.Play();
	}

	void MaxCombo()
	{
		uiManager.panelGame.MaxCombo (maxCombo);
		if(labelScalerMaxCombo)		labelScalerMaxCombo.Play ();
	}

	void Combo()
	{
		uiManager.panelGame.Combo (combo);
		if(labelScalerCombo)		labelScalerCombo.Play();
	}

	void Multiply()
	{
		// change effect

		uiManager.panelGame.Multiplay (multiply);
		if(labelScalerMultiply)		labelScalerMultiply.Play ();
	}
	#endregion
}












