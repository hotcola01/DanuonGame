using UnityEngine;
using System.Collections;

public class UIMover : MonoBehaviour 
{
	#region Variables
	public enum MoveDirectionType
	{
		MDT_Left = 0,
		MDT_Right,
		MDT_Top,
		MDT_Bottom
	}
	public MoveDirectionType moveDirectionType = MoveDirectionType.MDT_Left;



	private Vector3 originalPosition;
	public float moveValue;
	public float moveTime;
	public bool disappear;


	#endregion
	
	
	
	#region MonoBehaviour
	void Start () 
	{
		originalPosition = gameObject.transform.position;
	}
	
	void Update () 
	{
		
	}
	#endregion
	
	
	
	#region Implements
	public void Play()
	{
		Debug.Log ("Play");

		StopCoroutine ("ContinueMove");
		iTween.Stop (gameObject);
		gameObject.SetActive (true);

		StopCoroutine ("PlayMove");
		StartCoroutine ("PlayMove");
	}

	IEnumerator PlayMove()
	{
		yield return null;

		gameObject.transform.position = originalPosition;



		float x = originalPosition.x;
		float y = originalPosition.y;

		if(moveDirectionType == MoveDirectionType.MDT_Left)
		{
			x -= moveValue;
		}
		else if(moveDirectionType == MoveDirectionType.MDT_Right)
		{
			x += moveValue;
		}
		else if(moveDirectionType == MoveDirectionType.MDT_Top)
		{
			y += moveValue;
		}
		else if(moveDirectionType == MoveDirectionType.MDT_Bottom)
		{
			y -= moveValue;
		}

		iTween.MoveTo
		(
			gameObject,
			iTween.Hash
			(
				"x", x,
				"y", y,
				"easetype",
				iTween.EaseType.easeOutBack,
				"time",
				moveTime
			)
		);
		
		
		if(disappear)
		{
			StartCoroutine ("ContinueMove");
		}
	}

	IEnumerator ContinueMove()
	{
		yield return new WaitForSeconds(1f);
		CompleteClose ();
	}

	void CompleteClose()
	{
		Debug.Log ("CompleteClose");
		gameObject.SetActive (false);
	}
	#endregion
}
