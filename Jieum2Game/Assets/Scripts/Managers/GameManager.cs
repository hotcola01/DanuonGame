using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	#region Variables
	public UIManager uiManager;
	public MusicManager musicManager;
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
	public void UpdateTimeBar(float value)
	{
		uiManager.UpdateTimeBar(value);
	}
	#endregion
}
