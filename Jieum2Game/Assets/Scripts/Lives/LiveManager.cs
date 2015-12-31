using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using LitJson;




public class LiveManager
{
	public LiveNotes liveNotes = new LiveNotes();
	public LivePlayNotes livePlayNotes = new LivePlayNotes();
	public LiveProfile liveProfile = new LiveProfile();
	public LiveStages liveStages = new LiveStages();
	public LivePlayers livePlayers = new LivePlayers ();
	public LiveSettings liveSettings = new LiveSettings ();
	public LiveRanking liveRanking = new LiveRanking ();
	//public LiveTutorials liveTutorials = new LiveTutorials();


	private bool loginedGuest;
	private bool loginedFacebook;


	private static LiveManager instance;  
	public static LiveManager Instance
	{  
		get 
		{
			if( instance == null )
			{ 
				instance = new LiveManager();
			}
			
			return instance; 
		}
	}


	public LiveManager()
	{
/*		livePlayers.Load ("players");
		
		if(!liveProfile.Load ())
		{
			liveProfile.DefaultPlayer();
		}

		if(!liveSettings.Load ())
		{
			liveSettings.Save();
		}
		*/



	}


	public void LoadNoteData(string filename)
	{
		liveNotes.Load (filename);
	}



	public bool LoginedGuest
	{
		set { loginedGuest = value; }
		get { return loginedGuest;  }
	}
	
	public bool LoginedFacebook
	{
		set { loginedFacebook = value; }
		get { return loginedFacebook;  }
	}


#region Implements
//	Dictionary<string, string> DefaultMyData()
//	{
//		Dictionary<string, string> data = new Dictionary<string, string>();
//		data.Add("uuid", liveProfile.guestId);
//		data.Add("userID", FB.UserId);
//		data.Add("tocken", FB.AccessToken);
//
//		return data;
//	}
//
//	Dictionary<string, string> DefaultGuestData()
//	{
//		Dictionary<string, string> data = new Dictionary<string, string>();
//		liveProfile.guestId = JieumCommon.GetUniqueID ();
//		data.Add("uuid", liveProfile.guestId);
//		data.Add("userID", liveProfile.guestId);
//		data.Add("tocken", liveProfile.guestId);
//		
//		return data;
//	}
//
//
//
//	Dictionary<string, string> DefaultLoginedMyData()
//	{
//		Dictionary<string, string> data = new Dictionary<string, string>();
//		data.Add("userNo", liveProfile.userNo.ToString());
//		data.Add("userID", FB.UserId);
//		
//		return data;
//	}
//
//	Dictionary<string, string> DefaultLoginedGuestData()
//	{
//		Dictionary<string, string> data = new Dictionary<string, string>();
//		if(liveProfile.userNo != null)
//		{
//			data.Add("userNo", liveProfile.userNo.ToString());
//			data.Add("userID", liveProfile.userID != null ? liveProfile.userID : liveProfile.guestId);
//		}
//		
//		return data;
//	}
//
//
//	Dictionary<string, string> DefaultLoginedData()
//	{
//		Dictionary<string, string> data = new Dictionary<string, string>();
//		if(liveProfile.loginedSnsType == SNSType.ST_Guest)
//		{
//			data = DefaultLoginedGuestData ();
//		}
//		else if(liveProfile.loginedSnsType == SNSType.ST_Facebook)
//		{
//			data = DefaultLoginedMyData ();
//		}
//		
//		return data;
//	}
//
//
//	public void RequestLogin(SNSType snsType, WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = null;
//		if(snsType == SNSType.ST_Guest)
//		{
//			data = DefaultGuestData ();
//			data.Add("characterName", "Guest");
//			data.Add("snsType", "_GUEST_");
//		}
//		else if(snsType == SNSType.ST_Facebook)
//		{
//			data = DefaultMyData ();
//			data.Add("characterName", liveProfile.facebook_First_Name);
//			data.Add("snsType", "FACEBOOK");
//		}
//		
//		liveProfile.loginedSnsType = snsType;
//
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_Login, LiveDefines.Page_Login, data, callback);
//	}
//
//	public void RequestPlayerChange(WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData();
//		data.Add("characterType", ((int)liveProfile.selectPlayerNo).ToString());
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_PlayerChange, LiveDefines.Page_PlayerChange, data, callback);
//	}
//
//	public void ResponseProfile (JsonData json)
//	{
//		if(liveProfile != null)		liveProfile.ResponseData (json);
//	}
//
//	public void RequestSettingsChange(WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData ();
//		data.Add("blindMode", (Convert.ToInt32(liveSettings.blindMode)).ToString());
//		data.Add("vibrate", (Convert.ToInt32(liveSettings.vibrate)).ToString());
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_Settings, LiveDefines.Page_Settings, data, callback);
//	}
//
//	public void RequestRanking(WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData ();
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_Ranking, LiveDefines.Page_Ranking, data, callback);
//	}
//
//	public void ResponseRanking(JsonData json)
//	{
//		if(liveRanking != null)		liveRanking.ResponseData (json);
//	}
//
//	public void RequestResult(int characterNumber, int addCoin, int distance, int score, WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData ();
//		data.Add("addCoin", addCoin.ToString());
//		data.Add("characterType", characterNumber.ToString());
//		data.Add("distance", distance.ToString());
//		data.Add("score", score.ToString());
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_Result, LiveDefines.Page_Result, data, callback);
//	}
//
//	public void ResponseResult(JsonData json)
//	{
//		if(liveProfile != null)		liveProfile.ResponseData (json);
//	}
//
//	public void RequestCompleteTutorial(WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData ();
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_Tutorial, LiveDefines.Page_Tutorial, data, callback);
//	}
//
//	public void ResponseCompleteTutorial()
//	{
//		if(liveProfile != null)		liveProfile.tutorial = 0;	// always 0 setting.
//	}
//
//	public void RequestUseCoin(int coin, WWWHelper.HttpRequestDelegate callback)
//	{
//		Dictionary<string, string> data = DefaultLoginedData ();
//		data.Add("coin", coin.ToString());
//		WWWHelper.Instance.RequestPost((int)LivePageType.LPT_UseCoin, LiveDefines.Page_UseCoin, data, callback);
//	}
//
//	public void ResponseUseCoin(JsonData json)
//	{
//		if(liveProfile != null)		liveProfile.ResponseData (json);
//	}
//
//
//
//	public bool IsTutorialMode()
//	{
//		return liveProfile.tutorial == 0;
//	}
#endregion
}








