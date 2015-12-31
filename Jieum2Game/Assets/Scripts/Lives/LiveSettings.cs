using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using LitJson;


public class LiveSettings
{
	public bool blindMode = false;		// true:blind, false:none blind
	public bool vibrate = true;


	public bool Load()
	{
/*		string path = JieumCommon.PathForDocumentsFile ("gamesettings.txt");
		Debug.Log ("path " + path);

		FileInfo info = new FileInfo(path);
		if(!info.Exists)
		{
			return false;
		}
//		if(!File.Exists(path))
//		{
//			return false;
//		}
		
		StreamReader reader = new StreamReader(path);
		
		JsonData json = JsonMapper.ToObject (reader.ReadToEnd());
		
		
		string strJson;
		JsonData jsonData;


		jsonData = json ["blindMode"];
		strJson = jsonData.ToString ();
		blindMode = Convert.ToBoolean (strJson);

		jsonData = json ["vibrate"];
		strJson = jsonData.ToString ();
		vibrate = Convert.ToBoolean (strJson);
*/

		return true;
	}

	public void Save()
	{
/*		StringBuilder sb = new StringBuilder();
		JsonWriter writer = new JsonWriter(sb);
		writer.PrettyPrint = true;

		
		writer.WriteObjectStart();
		
		
		writer.WritePropertyName("blindMode");
		writer.Write (blindMode);

		writer.WritePropertyName("vibrate");
		writer.Write (vibrate);



		writer.WriteObjectEnd ();

		string path = JieumCommon.PathForDocumentsFile ("gamesettings.txt");
		Debug.Log ("path " + path);

		string dir = Path.GetDirectoryName (path);
		Debug.Log("Dir : " + dir);
		DirectoryInfo di = new DirectoryInfo(dir);
		if(!di.Exists)
		{
			di.Create();
		}

		StreamWriter sw = new StreamWriter (path);
		sw.Write(sb.ToString());
		sw.Close();
*/	}

	public void ResponseData(JsonData json)
	{
		string strJson;
		JsonData jsonData;
		
		if(LiveDefines.JsonDataContainsKey(json, "blindMode"))
		{
			jsonData = json ["blindMode"];
			strJson = jsonData.ToString ();
			blindMode = Convert.ToBoolean(Convert.ToInt32 (strJson));
		}
		
		if(LiveDefines.JsonDataContainsKey(json, "vibrate"))
		{
			jsonData = json ["vibrate"];
			strJson = jsonData.ToString ();
			vibrate = Convert.ToBoolean(Convert.ToInt32 (strJson));
		}
	}
}















