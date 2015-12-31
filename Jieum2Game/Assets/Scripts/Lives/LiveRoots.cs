using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;




public class LiveRoots<T>
{
	public List<T> dataList = new List<T> ();
	
	
	
	JsonData LoadJson(string fileName)
	{
		TextAsset textAsset = Resources.Load("Tables/"+fileName) as TextAsset;
		if(textAsset == null)
		{
			Debug.Log("Table load error");
			return null;
		}
		
		string json_text = textAsset.text;
		
		Debug.Log ("fileName text: " + json_text);
		JsonData json = JsonMapper.ToObject (json_text);
		
		return json;
	}
	
	public void Load(string path)
	{
		JsonData json = LoadJson (path);
		int count = json.Count;
		
		for(int i=0; i<count; i++)
		{
			string row = json[i].ToJson();
			T dataInfo = JsonMapper.ToObject<T>(row);
			dataList.Add(dataInfo);
		}
	}
}
