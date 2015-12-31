using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;


public static class Common
{
	public static GameManager GetGameManager()
	{
		GameObject mgr = GameObject.Find ("GameManager");
		if(mgr == null)
		{
			return null;
		}

		return mgr.GetComponent<GameManager> ();
	}


	public static string PathForDocumentsFile( string filename ) 
	{ 
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
			//string path = Application.persistentDataPath.Substring( 0, Application.persistentDataPath.Length - 5 );
			path = path.Substring( 0, path.LastIndexOf( '/' ) );
			Debug.Log("iOS Path : " + Path.Combine( Path.Combine( path, "Documents" ), filename ));
			return Path.Combine( Path.Combine( path, "Documents" ), filename );
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			string path = Application.persistentDataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) ); 
			Debug.Log("Android Path : " + Path.Combine (path, filename));
			return Path.Combine (path, filename);
		} 
		else 
		{
			string path = Application.dataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}
	
	public static string CommaFormat(int money)
	{
		return string.Format ("{0:n0}", money);
	}
	
	/**
	 * 벡터를 쿼터니언으로 리턴. 
	 */ 
	public static Quaternion GetVectorToQuat(Vector3 from, Vector3 to)
	{
		Vector3 dir = from - to;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	/**
	 * prefeb으로 gameObject 생성.
	 */
	public static GameObject CreatePrefebToGameObject(string prefebName, Transform parent=null)
	{
		GameObject prefeb = Resources.Load (prefebName) as GameObject;
		GameObject gameobject = MonoBehaviour.Instantiate (prefeb) as GameObject;
		if(parent != null)		gameobject.transform.parent = parent;
		gameobject.transform.localScale = prefeb.transform.localScale;
		return gameobject;
	}
	
	public static GameObject CreatePrefebToGameObject(string prefebName, Vector3 pos, Quaternion rot, Transform parent)
	{
		GameObject prefeb = Resources.Load (prefebName) as GameObject;
		GameObject gameobject = MonoBehaviour.Instantiate (prefeb, pos, rot) as GameObject;
		if(parent != null)		gameobject.transform.localScale = prefeb.transform.localScale;
		return gameobject;
	}
	
	public static void ChangeTextureNGUI(UISprite obj, string textureName, string atlasName)
	{
		obj.atlas = Resources.Load(atlasName, typeof(UIAtlas)) as UIAtlas;
		obj.spriteName = textureName;
	}
	
	public static void Vibration(bool vib)
	{
		#if UNITY_ANDROID || UNITY_IPHONE
		if(vib)
		{
			Handheld.Vibrate();
		}
		#endif
	}

	public static GameController GetGamePlayController()
	{
		GameObject gc = GameObject.Find ("GameController");
		if(gc == null)
		{
			return null;
		}
		
		return gc.GetComponent<GameController> ();
	}
	
//	public static void MakeFadeObject(Transform parent, UIFadeEvent.DelegateFade delegateFade, bool fadeInOut)
//	{
//		GameObject uiFade = CreatePrefebToGameObject ("Prefabs/UI/UIFadeEvent", parent);
//		if(uiFade)
//		{
//			//uiFade.transform.parent = parent;
//			uiFade.transform.localPosition = new Vector3(0f, 0f, -2f);
//			//uiFade.transform.localScale = uiFadeEvent.transform.localScale;
//			uiFade.GetComponent<UIFadeEvent>().SetDelegateFade (delegateFade);
//			if(fadeInOut)
//			{
//				uiFade.GetComponent<UIFadeEvent>().PlayFadeIn ();
//			}
//			else
//			{
//				uiFade.GetComponent<UIFadeEvent>().PlayFadeOut ();
//			}
//		}
//	}
//	
//	public static GameObject MakeBalloon(string text, float viewTime, Transform parent, string soundFileName="")
//	{
//		GameObject uiBalloon = CreatePrefebToGameObject ("Prefabs/UI/UIBalloon", parent);
//		uiBalloon.GetComponent<UIBalloon> ().MakeBalloon (text, viewTime, 0.5f, soundFileName);
//		//JieumCommon.PlayVoiceOver (text);
//		return uiBalloon;
//	}
	
	public static void SetResolution()
	{
		#if UNITY_ANDROID
		Screen.SetResolution (Screen.width, (Screen.width / 16) * 9, true);
		#elif UNITY_IOS
		float width = 1280f / Screen.width;
		float height = 720f / Screen.height;
		float orthoSize = width / height;
		orthographicSize = orthoSize;	// save
		
		
		UICamera.mainCamera.orthographicSize = orthoSize;
		//		float org = Camera.main.orthographicSize;
		//		Camera.main.orthographicSize *= orthoSize;
		
		if(Camera.main.GetComponent<FollowCamera>())
		{
			Camera.main.GetComponent<FollowCamera>().beatRect.UpdateRectPosition(UICamera.mainCamera.orthographicSize);
		}
		#endif
	}
	
	public static void PlayEffectSound(AudioSource effectSound, string soundFileName)
	{
		effectSound.clip = Resources.Load("AudioClips/"+soundFileName) as AudioClip;
		effectSound.loop = false;
		effectSound.Play();
	}
	
	/// <summary>
	/// Gets the major iOS version, eg 4, 5, 6, 7, 8, 9.
	/// </summary>
	public static float iOSVersion
	{
		get
		{
			// SystemInfo.operatingSystem returns something like iPhone OS 6.1
			float osVersion = -1f;
			string versionString = SystemInfo.operatingSystem.Replace("iPhone OS ", "");
			float.TryParse(versionString.Substring(0, 1), out osVersion);
			
			return osVersion;
		}
	}
	
	public static string GetUniqueID()
	{
		string key = "ID";
		
		var random = new System.Random();                     
		DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
		
		string uniqueID = Application.systemLanguage                            //Language
			+"-"+Application.platform                                            //Device    
				+"-"+string.Format("{0:X}", Convert.ToInt32(timestamp))                //Time
				+"-"+string.Format("{0:X}", Convert.ToInt32(Time.time*1000000))        //Time in game
				+"-"+string.Format("{0:X}", random.Next(1000000000));                //random number
		
		MD5 md5 = System.Security.Cryptography.MD5.Create();
		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(uniqueID);
		byte[] hash = md5.ComputeHash(inputBytes);
		
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < hash.Length; i++)
		{
			sb.Append(hash[i].ToString("X2"));
		}
		
		uniqueID = sb.ToString ();
		Debug.Log("Generated Unique ID: "+sb.ToString());
		
		if(PlayerPrefs.HasKey(key)){
			uniqueID = PlayerPrefs.GetString(key);            
		} else {            
			PlayerPrefs.SetString(key, sb.ToString());
			PlayerPrefs.Save();    
		}
		
		return uniqueID;
	}
	
	
	public static bool IsVersionUpgrade()
	{
		string currentVersion = Defines.BUNDLE_VERSION;
		string upgradeVersion = Defines.BUNDLE_VERSION;
		
		if(Convert.ToInt32 (upgradeVersion [0]) > Convert.ToInt32 (currentVersion [0]))
		{
			return true;
		}
		
		if(Convert.ToInt32 (upgradeVersion [2]) > Convert.ToInt32 (currentVersion [2]))
		{
			return true;
		}
		
		if(Convert.ToInt32 (upgradeVersion [4]) > Convert.ToInt32 (currentVersion [4]))
		{
			return true;
		}
		
		return false;
	}

	public static float GetFontWidthNGUI(UILabel label)
	{
		Vector2 v = label.relativeSize; 
		int fontsize = label.font.size; 
		return v.x * (float)fontsize; 
	}
}













