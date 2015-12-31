using UnityEngine;
using System.Collections;

public class PanelGame : MonoBehaviour 
{
	#region Variables
	public UILabel labelCombo;
	public UILabel labelMaxCombo;
	public UILabel labelScore;
	public UILabel labelMultiply;
	public UIScrollBar scrollBarMusicTime;
	#endregion



	#region MonoBehaviour
	void Start () 
	{
		Common.SetResolution ();
	}
	
	void Update () 
	{
	
	}
	#endregion



	#region Implements
	public void Combo(int value)
	{
		//labelCombo.text = "[ff00ff]" + value.ToString () +"[-]" + " Combo";
		labelCombo.text = value.ToString () + " Combo";
		labelCombo.gameObject.SetActive (value > 0 ? true : false);
	}

	public void MaxCombo(int value)
	{
		labelMaxCombo.text = "Max Combo : " + value.ToString ();
		labelMaxCombo.gameObject.SetActive (value > 0 ? true : false);
	}

	public void Score(int value)
	{
		labelScore.text = "Score : " + value.ToString ();
	}

	public void Multiplay(int value)
	{
		labelMultiply.text = "X " + value.ToString ();
	}

	public void TimeBar(float scrollValue)
	{
		scrollBarMusicTime.scrollValue = scrollValue;
	}
	#endregion
}
