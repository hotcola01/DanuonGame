using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;




public class StageInfo
{
	public int index;
	public int stagenumber;
	public string name;
	public int star;
	public string thumbnail;
	public string desc;
}


public class LiveStages : LiveBase
{
	public List<StageInfo> stageInfos = new List<StageInfo> ();



	public LiveStages ()
	{
	}

	public void Load()
	{
		JsonData json = LoadJson ("stages");
		int count = json.Count;
		
		for(int i=0; i<count; i++)
		{
			string row = json[i].ToJson();
			StageInfo stageInfo = JsonMapper.ToObject<StageInfo>(row);
			stageInfos.Add(stageInfo);
		}
	}
}










