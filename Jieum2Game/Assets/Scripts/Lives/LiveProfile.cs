using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using LitJson;



public class LiveProfile
{
////	public string facebookId;
//	public string facebook_First_Name;
////	public string facebook_Access_Token;
//	public Texture2D facebookMyPicture;
//
//	public int chapterNumber = 1;
//	public int stageNumber = 1;
//	public int coin;
//	public int cash;
//	public int userNo;
//	public string userID;
//	public int selectPlayerNo;
//	public int tutorial = 1;	// tutorial : 1, normal : 0
//	public PlayerType[] myPlayers = new PlayerType[JieumDefines.MaxPlayerCount];
//	public AbilityValue[] myAbilities = new AbilityValue[JieumDefines.MaxPlayerCount];
//
//	public SNSType loginedSnsType { get; set; }
//	public string guestId { get; set; }
//
//	public LiveProfile()
//	{
//		tutorial = 0;
//		for(int i=0; i<myAbilities.Length; i++)
//		{
//			myAbilities[i] = new AbilityValue();
//		}
//
//		ResetPlayer ();
//	}
//
//	public void ResetPlayer()
//	{
////		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
////		{
////			myPlayers[i] = PlayerType.PT_None;
////		}
////		
////		myPlayers [0] = PlayerType.PT_Leader;
//
//
//
//
//
//
//		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//		{
//			myPlayers[i] = (PlayerType)((int)PlayerType.PT_None + 1 + i);
//		}
//	}
//
//	public void DefaultPlayer()
//	{
//		LivePlayers livePlayers = LiveManager.Instance.livePlayers;
//
////		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
////		{
////			myPlayers[i] = (PlayerType)((int)PlayerType.PT_None + 1 + i);
////		}
//
//		myPlayers [0] = (PlayerType)0;
//
//		//for(int i=0; i<livePlayers.dataList.Count; i++)
//		for(int i=0; i<1; i++)
//		{
//			myAbilities[i].propertyType1 = livePlayers.dataList[i].propertyType1;
//			myAbilities[i].propertyValue1 = livePlayers.dataList[i].propertyValue1;
//			myAbilities[i].propertyType2 = livePlayers.dataList[i].propertyType2;
//			myAbilities[i].propertyValue2 = livePlayers.dataList[i].propertyValue2;
//			myAbilities[i].propertyType3 = livePlayers.dataList[i].propertyType3;
//			myAbilities[i].propertyValue3 = livePlayers.dataList[i].propertyValue3;
//		}
//	}
//
//
//	public bool Load()
//	{
///*		string path = JieumCommon.PathForDocumentsFile ("gamedata.txt");
//		Debug.Log ("path " + path);
//		FileInfo info = new FileInfo(path);
//		if(!info.Exists)
//		{
//			return false;
//		}
////		if(!File.Exists(path))
////		{
////			return false;
////		}
//
//
//		StreamReader reader = new StreamReader(path);
//
//		JsonData json = JsonMapper.ToObject (reader.ReadToEnd());
//		
//		
//		string strJson;
//		JsonData jsonData;
//		
//		jsonData = json ["chapternumber"];
//		strJson = jsonData.ToString ();
//		chapterNumber = Convert.ToInt32 (strJson);
//		
//		jsonData = json ["stagenumber"];
//		strJson = jsonData.ToString ();
//		stageNumber = Convert.ToInt32 (strJson);
//		
//		jsonData = json ["coin"];
//		strJson = jsonData.ToString ();
//		coin = Convert.ToInt32 (strJson);
//		
//		jsonData = json ["cash"];
//		strJson = jsonData.ToString ();
//		cash = Convert.ToInt32 (strJson);
//		
//		jsonData = json ["myplayers"];
//		for(int i=0; i<jsonData.Count; i++)
//		{
//			strJson = jsonData[i]["playertype"].ToString ();
//			myPlayers[i] = (PlayerType)Convert.ToInt32 (strJson);
//		}
//
//
//		jsonData = json ["myabilities"];
//		for(int i=0; i<jsonData.Count; i++)
//		{
//			if(myPlayers[i] != PlayerType.PT_None)
//			{
//				strJson = jsonData[i]["propertytype1"].ToString ();
//				myAbilities[i].propertyType1 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//				strJson = jsonData[i]["propertyvalue1"].ToString ();
//				myAbilities[i].propertyValue1 = (float)Convert.ToDouble (strJson);
//
//				strJson = jsonData[i]["propertytype2"].ToString ();
//				myAbilities[i].propertyType2 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//				strJson = jsonData[i]["propertyvalue2"].ToString ();
//				myAbilities[i].propertyValue2 = (float)Convert.ToDouble (strJson);
//
//				strJson = jsonData[i]["propertytype3"].ToString ();
//				myAbilities[i].propertyType3 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//				strJson = jsonData[i]["propertyvalue3"].ToString ();
//				myAbilities[i].propertyValue3 = (float)Convert.ToDouble (strJson);
//			}
//		}
//
//*/
//		return true;
//	}
//
//
//	public void Save()
//	{
///*		StringBuilder sb = new StringBuilder();
//		JsonWriter writer = new JsonWriter(sb);
//		writer.PrettyPrint = true;
//
//
//		writer.WriteObjectStart();
//
//
//		writer.WritePropertyName("chapternumber");
//		writer.Write (chapterNumber);
//
//		writer.WritePropertyName("stagenumber");
//		writer.Write (stageNumber);
//
//		writer.WritePropertyName("coin");
//		writer.Write (coin);
//
//		writer.WritePropertyName("cash");
//		writer.Write (cash);
//
//
//		writer.WritePropertyName ("myplayers");
//		writer.WriteArrayStart ();
//
//		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//		{
//			writer.WriteObjectStart();
//			writer.WritePropertyName("playertype");
//			writer.Write((int)myPlayers[i]);
//			writer.WriteObjectEnd();
//		}
//
//		writer.WriteArrayEnd ();
//
//
//		writer.WritePropertyName ("myabilities");
//		writer.WriteArrayStart ();
//
//		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//		{
//			if(myPlayers[i] != PlayerType.PT_None)
//			{
//				writer.WriteObjectStart();
//
//				writer.WritePropertyName("propertytype1");
//				writer.Write((int)myAbilities[i].propertyType1);
//				writer.WritePropertyName("propertyvalue1");
//				writer.Write(myAbilities[i].propertyValue1);
//
//				writer.WritePropertyName("propertytype2");
//				writer.Write((int)myAbilities[i].propertyType2);
//				writer.WritePropertyName("propertyvalue2");
//				writer.Write(myAbilities[i].propertyValue2);
//
//				writer.WritePropertyName("propertytype3");
//				writer.Write((int)myAbilities[i].propertyType3);
//				writer.WritePropertyName("propertyvalue3");
//				writer.Write(myAbilities[i].propertyValue3);
//
//				writer.WriteObjectEnd();
//			}
//		}
//
//		writer.WriteArrayEnd ();
//
//
//
//		writer.WriteObjectEnd ();
//
//
//
//		string path = JieumCommon.PathForDocumentsFile ("gamedata.txt");
//		Debug.Log ("path " + path);
//		StreamWriter sw = new StreamWriter (path);
//		sw.Write(sb);
//		sw.Close();
//*/	}
//
//	public void AddCoin(int add)
//	{
//		coin += add;
//		Save (); 
//	}
//
//	public string GetMyPlayersString()
//	{
//		StringBuilder sb = new StringBuilder();
//		JsonWriter writer = new JsonWriter(sb);
//		writer.PrettyPrint = true;
//		
//
//		writer.WriteArrayStart ();
//		
//		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//		{
//			writer.WriteObjectStart();
//			writer.WritePropertyName("playertype");
//			writer.Write((int)myPlayers[i]);
//			writer.WriteObjectEnd();
//		}
//		
//		writer.WriteArrayEnd ();
//
//		return sb.ToString ();
//	}
//
//	public string GetMyPropertiesString()
//	{
//		StringBuilder sb = new StringBuilder();
//		JsonWriter writer = new JsonWriter(sb);
//		writer.PrettyPrint = true;
//		
//
//		writer.WriteArrayStart ();
//		
//		for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//		{
//			if(myPlayers[i] != PlayerType.PT_None)
//			{
//				writer.WriteObjectStart();
//				
//				writer.WritePropertyName("propertytype1");
//				writer.Write((int)myAbilities[i].propertyType1);
//				writer.WritePropertyName("propertyvalue1");
//				writer.Write(myAbilities[i].propertyValue1);
//				
//				writer.WritePropertyName("propertytype2");
//				writer.Write((int)myAbilities[i].propertyType2);
//				writer.WritePropertyName("propertyvalue2");
//				writer.Write(myAbilities[i].propertyValue2);
//				
//				writer.WritePropertyName("propertytype3");
//				writer.Write((int)myAbilities[i].propertyType3);
//				writer.WritePropertyName("propertyvalue3");
//				writer.Write(myAbilities[i].propertyValue3);
//				
//				writer.WriteObjectEnd();
//			}
//		}
//		
//		writer.WriteArrayEnd ();
//
//		
//		
//		
//		return sb.ToString ();
//	}
//
//	public void ResponseData(JsonData json)
//	{
//		string strJson;
//		JsonData jsonData;
//
//		if(LiveDefines.JsonDataContainsKey(json, "coin"))
//		{
//			jsonData = json ["coin"];
//			strJson = jsonData.ToString ();
//			coin = Convert.ToInt32 (strJson);
//		}
//
//		if(LiveDefines.JsonDataContainsKey(json, "cash"))
//		{
//			jsonData = json ["cash"];
//			strJson = jsonData.ToString ();
//			cash = Convert.ToInt32 (strJson);
//		}
//
//
//		if(LiveDefines.JsonDataContainsKey(json, "userNo"))
//		{
//			jsonData = json ["userNo"];
//			strJson = jsonData.ToString ();
//			userNo = Convert.ToInt32 (strJson);
//		}
//
//
//		if(LiveDefines.JsonDataContainsKey(json, "userID"))
//		{
//			jsonData = json ["userID"];
//			userID = jsonData.ToString ();
//		}
//
//
//		if(LiveDefines.JsonDataContainsKey(json, "selectPlayerNo"))
//		{
//			jsonData = json ["selectPlayerNo"];
//			strJson = jsonData.ToString ();
//			selectPlayerNo = Convert.ToInt32 (strJson);
//		}
//
//
//		if(LiveDefines.JsonDataContainsKey(json, "tutorial"))
//		{
//			jsonData = json ["tutorial"];
//			strJson = jsonData.ToString ();
//			tutorial = Convert.ToInt32 (strJson);
//		}
//
//
//		if(LiveDefines.JsonDataContainsKey(json, "myplayers"))
//		{
//			jsonData = json ["myplayers"];
//
//			for(int i=0; i<JieumDefines.MaxPlayerCount; i++)
//			{
//				myPlayers[i] = PlayerType.PT_None;
//			}
//
//			for(int i=0; i<jsonData.Count; i++)
//			{
//				strJson = jsonData[i]["playertype"].ToString ();
//				myPlayers[i] = (PlayerType)Convert.ToInt32 (strJson);
//			}
//		}
//		
//
//		if(LiveDefines.JsonDataContainsKey(json, "myabilities"))
//		{
//			jsonData = json ["myabilities"];
//
//			for(int i=0; i<jsonData.Count; i++)
//			{
//				myAbilities[i].propertyType1 = PlayerPropertyType.PPT_None;
//				myAbilities[i].propertyValue1 = 0f;
//				
//				myAbilities[i].propertyType2 = PlayerPropertyType.PPT_None;
//				myAbilities[i].propertyValue2 = 0f;
//				
//				myAbilities[i].propertyType3 = PlayerPropertyType.PPT_None;
//				myAbilities[i].propertyValue3 = 0f;
//			}
//
//			for(int i=0; i<jsonData.Count; i++)
//			{
//				if(myPlayers[i] != PlayerType.PT_None)
//				{
//					strJson = jsonData[i]["propertytype1"].ToString ();
//					myAbilities[i].propertyType1 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//					strJson = jsonData[i]["propertyvalue1"].ToString ();
//					myAbilities[i].propertyValue1 = (float)Convert.ToDouble (strJson);
//					
//					strJson = jsonData[i]["propertytype2"].ToString ();
//					myAbilities[i].propertyType2 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//					strJson = jsonData[i]["propertyvalue2"].ToString ();
//					myAbilities[i].propertyValue2 = (float)Convert.ToDouble (strJson);
//					
//					strJson = jsonData[i]["propertytype3"].ToString ();
//					myAbilities[i].propertyType3 = (PlayerPropertyType)Convert.ToInt32 (strJson);
//					strJson = jsonData[i]["propertyvalue3"].ToString ();
//					myAbilities[i].propertyValue3 = (float)Convert.ToDouble (strJson);
//				}
//			}
//		}
//	}
}
