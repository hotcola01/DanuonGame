using UnityEngine;
using System.Collections;

public class PanelGame : MonoBehaviour 
{
	#region Variables
	public UILabel labelCombo;
	public UILabel labelComboCount;
	public UILabel labelMaxCombo;
	public UILabel labelMaxComboCount;
	public UILabel labelScore;
	public UILabel labelScoreCount;
	public UILabel labelMultiplyCount;
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
		labelComboCount.text = value.ToString ();
		labelComboCount.gameObject.SetActive (value > 0 ? true : false);
		labelCombo.gameObject.SetActive (value > 0 ? true : false);
	}

	public void MaxCombo(int value)
	{
		labelMaxComboCount.text = value.ToString ();

		float maxComboValueWidth = Common.GetFontWidthNGUI (labelMaxComboCount);
		float maxComboLabelWidth = Common.GetFontWidthNGUI (labelMaxCombo);
		Vector3 labelPos = labelMaxComboCount.transform.localPosition - new Vector3(maxComboValueWidth+10f, 0f, 0f);
		labelMaxCombo.transform.localPosition = labelPos;
	}

	public void Score(int value)
	{
		labelScoreCount.text = value.ToString ();

		float scoreValueWidth = Common.GetFontWidthNGUI (labelScoreCount);
		float scoreLabelWidth = Common.GetFontWidthNGUI (labelScore);
		Vector3 labelPos = labelScoreCount.transform.localPosition - new Vector3(scoreValueWidth+10f, 0f, 0f);
		labelScore.transform.localPosition = labelPos;
	}

	public void Multiplay(int value)
	{
		labelMultiplyCount.text = "x" + value.ToString ();
	}

	public void TimeBar(float scrollValue)
	{
		scrollBarMusicTime.scrollValue = scrollValue;
	}
	#endregion
}
