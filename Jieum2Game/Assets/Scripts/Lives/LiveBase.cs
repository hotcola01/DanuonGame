using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using LitJson;


public class LiveBase 
{
	public JsonData LoadJson(string fileName)
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
}
