using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	#region Variables
	public PanelGame panelGame;
	#endregion


	#region MonoBehaviour
	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
	#endregion




	#region Implements
	public void UpdateGameData(int score, int combo, int maxCombo, int multiply)
	{
		panelGame.Score (score);
		panelGame.Combo (combo);
		panelGame.MaxCombo (maxCombo);
		panelGame.Multiplay (multiply);
	}

	public void UpdateTimeBar(float value)
	{
		panelGame.TimeBar (value);
	}
	#endregion
}







