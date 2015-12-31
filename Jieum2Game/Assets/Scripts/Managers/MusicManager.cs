using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
	public AudioSource audioBGM;
	public AudioSource[] audioEffects = new AudioSource[(int)TouchSectorType.NumberOfTouchSectorType];
	public AudioSource audioEffectMiss;

	private LivePlayNotes livePlayNotes;
	private GameManager gameManager;


	void Start () 
	{
		livePlayNotes = LiveManager.Instance.livePlayNotes;
		gameManager = Common.GetGameManager ();
		LoadBGM ("test05", 0.5f);
		PlayBGM ();
	}
	
	void Update () 
	{
		if(IsPlayBGM() && gameManager)
		{
			gameManager.UpdateTimeBar(GetPlayTime()/GetTotalTime());
		}
	}


	#region Implements
	public void LoadBGM(string fileName, float preListenTime)
	{
		livePlayNotes.Load (fileName);
		audioBGM.clip = Resources.Load ("AudioClips/" + livePlayNotes.soundName) as AudioClip;
		if(audioBGM.clip)
		{
			audioBGM.Stop();
		}

		livePlayNotes.preListenTime = preListenTime;
	}

	public void PlayBGM()
	{
		if(audioBGM.clip == null)
		{
			return;
		}

		audioBGM.Play ();
	}

	public void StopBGM()
	{
		if(audioBGM.clip == null)
		{
			return;
		}
		
		audioBGM.Stop ();
	}

	public void PlayEffectSound(int index)
	{
		audioEffects [index].time = 0f;
		audioEffects [index].Stop ();
		audioEffects [index].Play ();
	}

	public void PlayEffectSoundMiss()
	{
		audioEffectMiss.time = 0f;
		audioEffectMiss.Stop ();
		audioEffectMiss.Play ();
	}

	public float GetPlayTime()
	{
		return audioBGM.time;
	}

	public float GetTotalTime()
	{
		return audioBGM.clip.length;
	}

	public bool IsPlayBGM()
	{
		return audioBGM.isPlaying;
	}
	#endregion
}









