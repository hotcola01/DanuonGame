using UnityEngine;
using System.Collections;
using System;
using LitJson;






public enum LiveErrorType
{
	LET_Success = 0,
	
	LET_Login_UserIdNull = 101,
	LET_Login_TockenNull,
	LET_Login_SnsTypeNull,
	
	LET_Result_UserNoNull = 301,
	LET_Result_UserIdNull,
	LET_Result_UserAddCoinNull,
	LET_Result_ScoreNull,
	LET_Result_UserNull,
	
	LET_Ranking_UserNoNull = 401,
	LET_Ranking_UserIdNull,
	LET_Ranking_ResetNone,
	LET_Ranking_NoneRakingInfo,
	LET_Ranking_NotRakingInfoError,
	
	
	LET_Coin_FreeAddCoin = 700,		// coin add
	LET_Coin_UserNoNull,
	LET_Coin_UserIdNull,
	LET_Coin_NoneProfile,
	LET_Coin_NoneUserInfo,
	LET_Coin_NotFreeAddCoin,
	
	LET_Option_UserNoNull = 901,
	LET_Option_UserIdNull,
	LET_Option_SoundNull,
	LET_Option_BlindModeNull,
	LET_Option_VibrateNull,
	LET_Option_NoneProfile,
	
	NumberOfLiveErrorType
}



public enum LivePageType
{
	LPT_Login = 100,
	LPT_PlayerChange,
	LPT_Profiles,
	LPT_Ranking,
	LPT_Settings,
	LPT_Result,
	LPT_Tutorial,
	LPT_UseCoin,
	NumberOfLivePageType
}


public enum SNSType
{
	ST_Guest = 0,
	ST_Facebook,
	NumberOfSNSType
}


public static class LiveDefines
{
	public static string DefaultURL = "http://bfapps.net/_AppGames/jieum1/";

	public static string Page_Login = "login.php";
	public static string Page_PlayerChange = "character_info.php";
	public static string Page_Profile = "profiles.php";
	public static string Page_Ranking = "ranking.php";
	public static string Page_Settings = "setting.php";
	public static string Page_Result = "player_info.php";
	public static string Page_Tutorial = "tutorial.php";
	public static string Page_UseCoin = "buy_coin.php";




	static public  bool JsonDataContainsKey(JsonData data, string key)
	{
		bool result = false;
		if(data == null)
			return result;
		
		if(!data.IsObject)
		{
			return result;
		}
		
		IDictionary dictionary = data as IDictionary;
		if(dictionary == null)
			return result;
		
		if(dictionary.Contains(key))
		{
			result = true;
		}
		
		return result;
	}


	public static bool IsSuccess(JsonData json)
	{
		if (LiveDefines.JsonDataContainsKey (json, "responseValue")) 
		{
			string responseValue = json ["responseValue"].ToString ();
			LiveErrorType errorCode = (LiveErrorType)Convert.ToInt32 (responseValue);


			if(errorCode == LiveErrorType.LET_Success ||
			   errorCode == LiveErrorType.LET_Coin_FreeAddCoin)
			{
				//Debug.Log("responseValue == success");
				return true;
			}
		}

		return false;
	}

	public static bool IsSuccess_AddCoin(JsonData json)
	{
		if (LiveDefines.JsonDataContainsKey (json, "responseValue")) 
		{
			string responseValue = json ["responseValue"].ToString ();
			LiveErrorType errorCode = (LiveErrorType)Convert.ToInt32 (responseValue);
			
			
			if(errorCode == LiveErrorType.LET_Coin_FreeAddCoin)
			{
				//Debug.Log("responseValue == success");
				return true;
			}
		}
		
		return false;
	}

	public static string ErrorMessage(JsonData json, string defaultString)
	{
		if (LiveDefines.JsonDataContainsKey (json, "responseValue")) 
		{
			string responseValue = json ["responseValue"].ToString ();
			LiveErrorType errorCode = (LiveErrorType)Convert.ToInt32 (responseValue);
			
			
			
			if(errorCode == LiveErrorType.LET_Login_UserIdNull)					defaultString = "Facebook Login failed.";				
			else if(errorCode == LiveErrorType.LET_Login_TockenNull)			defaultString = "Facebook Login failed.";
			else if(errorCode == LiveErrorType.LET_Login_SnsTypeNull)			defaultString = "Facebook Login failed.";
			
			else if(errorCode == LiveErrorType.LET_Result_UserNoNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Result_UserIdNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Result_UserAddCoinNull)		defaultString = "there is no coin to be added.";
			else if(errorCode == LiveErrorType.LET_Result_ScoreNull)			defaultString = "There is no score to be added.";
			else if(errorCode == LiveErrorType.LET_Result_UserNull)				defaultString = "There is no user information.";
			
			else if(errorCode == LiveErrorType.LET_Ranking_UserNoNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Ranking_UserIdNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Ranking_ResetNone)			defaultString = "Ranking reset error";
			else if(errorCode == LiveErrorType.LET_Ranking_NoneRakingInfo)		defaultString = "No information Ranking.";
			else if(errorCode == LiveErrorType.LET_Ranking_NotRakingInfoError)	defaultString = "My Ranking imformation is not resetting.";
			
			else if(errorCode == LiveErrorType.LET_Coin_FreeAddCoin)			defaultString = "you added 1,000 free coins.";
			else if(errorCode == LiveErrorType.LET_Coin_UserNoNull)				defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Coin_UserIdNull)				defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Coin_NoneProfile)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Coin_NoneUserInfo)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Coin_NotFreeAddCoin)			defaultString = "You can not charge any more.";
			
			else if(errorCode == LiveErrorType.LET_Option_UserNoNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Option_UserIdNull)			defaultString = "There is no user information.";
			else if(errorCode == LiveErrorType.LET_Option_SoundNull)			defaultString = "Sound settings fail.";
			else if(errorCode == LiveErrorType.LET_Option_BlindModeNull)		defaultString = "Voice-over settings fail.";
			else if(errorCode == LiveErrorType.LET_Option_VibrateNull)			defaultString = "Vibration settings fail.";
			else if(errorCode == LiveErrorType.LET_Option_NoneProfile)			defaultString = "There is no user information.";
		}
		
		return defaultString;
	}

	public static string JsonToString(JsonData json)
	{
		return json == null ? "0" : json.ToString ();
	}
}





