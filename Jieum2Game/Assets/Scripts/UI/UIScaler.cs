using UnityEngine;
using System.Collections;

public class UIScaler : MonoBehaviour 
{
	#region Variables
	public bool disapper;
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
	public void Play()
	{
		Debug.Log ("Play");

		StopCoroutine ("ContinueScale");
		iTween.Stop (gameObject);
		gameObject.SetActive (true);

		StopCoroutine ("PlayScale");
		StartCoroutine ("PlayScale");
	}

	IEnumerator PlayScale()
	{
		yield return null;

		gameObject.transform.localScale = new Vector3 (0.01f, 0.01f, 1f);
		iTween.ScaleTo
		(
			gameObject,
			iTween.Hash
			(
				"x", 1f,
				"y", 1f,
				"easetype",
				iTween.EaseType.easeOutBack,
				"time",
				0.2f
			)
		);
		
		
		if(disapper)
		{
			StartCoroutine ("ContinueScale");
		}
	}

	IEnumerator ContinueScale()
	{
		yield return new WaitForSeconds(1f);
		CompleteClose ();
	}

	public void Close()
	{
		Debug.Log ("Close");

		gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
		iTween.ScaleTo
		(
			gameObject,
			iTween.Hash
			(
				"x", 0.01f,
				"y", 0.01f,
				"easetype",
				iTween.EaseType.easeOutBack,
				"time",
				0.2f,
				"oncomplete",
				"CompleteClose",
				"oncompletetarget",
				gameObject
			)
		);
	}

	void CompleteClose()
	{
		Debug.Log ("CompleteClose");
		gameObject.SetActive (false);
	}
	#endregion
}
