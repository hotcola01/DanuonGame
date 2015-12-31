using UnityEngine;
using System.Collections;

public class LeanTouchTester : MonoBehaviour 
{
	public delegate void TouchBeginEvent(Vector2 pos);
	TouchBeginEvent touchBeginEventFunc;


	#region MonoBehaviour
	void OnEnable()
	{
		Lean.LeanTouch.OnFingerDown     += OnFingerDown;
	}

	void OnDisable()
	{
		Lean.LeanTouch.OnFingerDown     -= OnFingerDown;
	}
	#endregion




	#region Implements
	public void OnFingerDown(Lean.LeanFinger finger)
	{
		if(touchBeginEventFunc != null)
		{
			Vector2 screenPosition = finger.ScreenPosition;
			touchBeginEventFunc(finger.ScreenPosition);
		}
	}
	#endregion




	#region Properties
	public TouchBeginEvent TouchEvent
	{
		set { touchBeginEventFunc = value; }
		get { return touchBeginEventFunc;  }
	}
	#endregion
}
