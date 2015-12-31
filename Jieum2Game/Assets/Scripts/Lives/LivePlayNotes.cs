using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using LitJson;


public class PlayNoteInfo
{
	public bool played		{ get; set; }
	public bool prePlayed	{ get; set; }
	public float playTime	{ get; set; }
	public int effectIndex	{ get; set; } // [0~3]
	public int groupIndex	{ get; set; }
	public bool cloned		{ get; set; }
}



public class LivePlayNotes 
{
	public string soundName;
	public float bpm;
	public int cloneNoteMoveCount;
	public int noteCounts;				// playable note, effectType != divide && effectType != linetype.cutin
	public float preListenTime;

	public List<PlayNoteInfo> playableNoteList = new List<PlayNoteInfo>();
	public List<PlayNoteInfo> divideNoteList = new List<PlayNoteInfo>();
	public List<PlayNoteInfo> cutinNoteList = new List<PlayNoteInfo>();


	public LivePlayNotes()
	{
		
	}

//	static int CompareByTime(PlayNoteInfo a, PlayNoteInfo b)
//	{
//		if (a.playTime == b.playTime)
//			return 0;
//		else if (a.playTime > b.playTime)
//			return 1;
//		else 
//			return -1;
//	}

	public void Reset()
	{
		for(int i=0; i<playableNoteList.Count; i++)
		{
			playableNoteList[i].prePlayed = false;
			playableNoteList[i].played = false;
		}
	}

	public void Clear()
	{
		noteCounts = 0;
		if(playableNoteList != null)	playableNoteList.Clear ();
		if(divideNoteList != null)		divideNoteList.Clear ();
		if(cutinNoteList != null)		cutinNoteList.Clear ();
	}

	public void Load(string filename)
	{
		Clear ();
		
		TextAsset textAsset = (TextAsset)Resources.Load ("Stages/" + filename, typeof(TextAsset));
		JsonData json = JsonMapper.ToObject (textAsset.text);
		
		JsonData jsonSoundName = json ["soundname"];
		soundName = jsonSoundName.ToString ();

		JsonData jsonBpm = json ["bpm"];
		string strBpm = jsonBpm.ToJson();
		bpm = (float)Convert.ToDouble (strBpm);

		JsonData jsonCloneNoteMoveCount = json ["clonenotemovecount"];
		string strCloneNoteMoveCount = jsonCloneNoteMoveCount.ToJson();
		cloneNoteMoveCount = Convert.ToInt32 (strCloneNoteMoveCount);

		JsonData jsonNoteCounts = json ["notecount"];
		string strNoteCounts = jsonNoteCounts.ToJson();
		noteCounts = Convert.ToInt32 (strNoteCounts);

		JsonData jsonNotes = json["notes"];
		for(int i=0; i<jsonNotes.Count; i++)
		{
			JsonData jsonNote = jsonNotes[i];

			PlayNoteInfo playNoteInfo = new PlayNoteInfo();

			string strTime = jsonNote["time"].ToJson();
			playNoteInfo.playTime = (float)Convert.ToDouble(strTime);

			string strEffectIndex = jsonNote["effectindex"].ToJson();
			playNoteInfo.effectIndex = Convert.ToInt32(strEffectIndex);

			string strGroupIndex = jsonNote["groupindex"].ToJson();
			playNoteInfo.groupIndex = Convert.ToInt32(strGroupIndex);

			string strCloned = jsonNote["cloned"].ToJson();
			playNoteInfo.cloned = Convert.ToBoolean(strCloned);


//			if(playNoteInfo.effectIndex == (int)LineType.LT_LineDivide)
//			{
//				divideNoteList.Add (playNoteInfo);
//			}
//			else if(playNoteInfo.effectIndex == (int)LineType.LT_LineCutin)
//			{
//				cutinNoteList.Add (playNoteInfo);
//			}
//			else
//			{
				playableNoteList.Add (playNoteInfo);
//			}
		}
	}

//	public bool IsPlayEffectSound(float flowTime)
//	{
//		for(int i=0; i<playableNoteList.Count; i++)
//		{
//			if(!playableNoteList[i].played)
//			{
//				if(playableNoteList[i].playTime < flowTime)
//				{
//					playableNoteList[i].played = true;
//					return true;
//				}
//			}
//		}
//
//		return false;
//	}
//
//	public int FindStartBeatIndex(


	public PlayNoteInfo GetPlayableNoteInfo(float flowTime)
	{
		for(int i=0; i<playableNoteList.Count; i++)
		{
			if(!playableNoteList[i].prePlayed &&
			   playableNoteList[i].effectIndex < 4 &&
			   playableNoteList[i].cloned == false)
			{
				if(playableNoteList[i].playTime-preListenTime < flowTime)
				{
					return playableNoteList[i];
				}
			}
		}
		
		return null;
	}

	public int TotalPlayableNoteCount()
	{
		int count = 0;
		for(int i=0; i<playableNoteList.Count; i++)
		{
			if(playableNoteList[i].cloned == false)
			{
				count++;
			}
		}

		return count;
	}
}





