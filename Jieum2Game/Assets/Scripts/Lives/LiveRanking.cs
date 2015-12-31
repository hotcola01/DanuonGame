using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using LitJson;


public class LiveRankinfo
{
	public int rank;
	public string name;
	public int distance;
	public int score;
}


public class LiveRanking
{
	public LiveRankinfo myRankInfo = new LiveRankinfo();
	public List<LiveRankinfo> rankInfoList = new List<LiveRankinfo>();


	/*
	public string RequestData()
	{
		StringBuilder sb = new StringBuilder();
		JsonWriter writer = new JsonWriter(sb);
		writer.PrettyPrint = true;
		
		
		writer.WriteObjectStart();


		// my rank
		writer.WritePropertyName("rank");
		writer.Write (myRankInfo.rank);

		writer.WritePropertyName("distance");
		writer.Write (myRankInfo.distance);

		writer.WritePropertyName("point");
		writer.Write (myRankInfo.point);


		// rank list
		writer.WritePropertyName ("ranklist");

		writer.WriteArrayStart ();

		for(int i=0; i<rankInfoList.Count; i++)
		{
			writer.WriteObjectStart();

			writer.WritePropertyName("rank");
			writer.Write(rankInfoList[i].rank);

			writer.WritePropertyName("name");
			writer.Write(rankInfoList[i].name);

			writer.WritePropertyName("distance");
			writer.Write(rankInfoList[i].distance);

			writer.WritePropertyName("point");
			writer.Write(rankInfoList[i].point);

			writer.WriteObjectEnd();
		}

		writer.WriteArrayEnd ();


		writer.WriteObjectEnd ();



		return writer.ToString ();

	}
*/

	public void ResponseData(JsonData json)
	{
		string strJson;
		JsonData jsonData;



		// my rank
		if(LiveDefines.JsonDataContainsKey(json, "rank"))
		{
			strJson = LiveDefines.JsonToString(json["rank"]);
			myRankInfo.rank = Convert.ToInt32 (strJson);
		}

		if(LiveDefines.JsonDataContainsKey(json, "distance"))
		{
			strJson = LiveDefines.JsonToString(json["distance"]);
			myRankInfo.distance = Convert.ToInt32 (strJson);
		}

		if(LiveDefines.JsonDataContainsKey(json, "score"))
		{
			strJson = LiveDefines.JsonToString(json["score"]);
			myRankInfo.score = Convert.ToInt32 (strJson);
		}



		// rank list
		rankInfoList.Clear ();

		if(LiveDefines.JsonDataContainsKey(json, "ranklist"))
		{
			jsonData = json["ranklist"];
			for(int i=0; i<jsonData.Count; i++)
			{
				LiveRankinfo rankInfo = new LiveRankinfo();

				if(LiveDefines.JsonDataContainsKey(jsonData[i], "rank"))
				{
					strJson = LiveDefines.JsonToString(jsonData[i]["rank"]);
					rankInfo.rank = Convert.ToInt32 (strJson);
				}

				if(LiveDefines.JsonDataContainsKey(jsonData[i], "name"))
				{
					strJson = LiveDefines.JsonToString(jsonData[i]["name"]);
					rankInfo.name = strJson;
				}

				if(LiveDefines.JsonDataContainsKey(jsonData[i], "distance"))
				{
					strJson = LiveDefines.JsonToString(jsonData[i]["distance"]);
					rankInfo.distance = Convert.ToInt32 (strJson);
				}

				if(LiveDefines.JsonDataContainsKey(jsonData[i], "score"))
				{
					strJson = LiveDefines.JsonToString(jsonData[i]["score"]);
					rankInfo.score = Convert.ToInt32 (strJson);
				}


				rankInfoList.Add(rankInfo);
			}
		}
	}
}











