using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using LitJson;



public class NoteInfo
{
	public float playTime	{ get; set; }
	public int groupNumber	{ get; set; }
	public int createNumber	{ get; set; }
	public int leftOrRight	{ get; set; }		// [0:left, 1:right]
}


public class LiveNotes
{
	public string soundName;
	public int noteGroupCount;
	public float hitTime;
	//public List<List<NoteInfo> > noteGroupList = new List<List<NoteInfo> >();
	public Dictionary<int, List<NoteInfo> > noteDictionary = new Dictionary<int, List<NoteInfo> > ();
	public int noteCounts;


	public LiveNotes()
	{

	}

	public void Clear()
	{
/*		for(int i=0; i<noteGroupList.Count; i++)
		{
			List<NoteInfo> noteGroup = noteGroupList[i];
			noteGroup.Clear();
		}
		noteGroupList.Clear ();
*/
		foreach (KeyValuePair<int, List<NoteInfo> > item in noteDictionary)
		{
			item.Value.Clear();
		}
		noteDictionary.Clear ();

		noteCounts = 0;
	}

	static int CompareByTime(NoteInfo a, NoteInfo b)
	{
		if (a.playTime == b.playTime)
			return 0;
		else if (a.playTime > b.playTime)
			return 1;
		else 
			return -1;
	}

	public void Load(string filename)
	{
		Clear ();

		TextAsset textAsset = (TextAsset) Resources.Load("Stages/"+filename, typeof(TextAsset));
		JsonData json = JsonMapper.ToObject (textAsset.text);

		JsonData jsonSoundName = json["soundname"];
		soundName = jsonSoundName.ToString();

		JsonData jsonNotes = json["notes"];
		string strCount = jsonNotes.ToJson();
		noteGroupCount = Convert.ToInt32 (strCount);


		JsonData jsonHitTime = json["hittime"];
		string strHitTime = jsonHitTime.ToString();
		hitTime = (float)Convert.ToDouble(strHitTime);



		/*
		JsonData jsonNoteGroups = json["notegroups"];
		for(int i=0; i<noteGroupCount; i++)
		{
			JsonData jsonNoteList = jsonNoteGroups[i];
			int count2 = jsonNoteList.Count;

			List<NoteInfo> noteGroup = new List<NoteInfo>();

			for(int j=0; j<count2; j++)
			{
				string strTime = jsonNoteList[j]["time"].ToJson();
				float time = (float)Convert.ToDouble(strTime);

				string strCreateNumber = jsonNoteList[j]["createnumber"].ToJson();
				int createNumber = Convert.ToInt32(strCreateNumber);

				NoteInfo note = new NoteInfo();
				note.prePlayed = false;
				note.playTime = time;
				note.createNumber = createNumber;

				noteGroup.Add(note);
			}

			noteGroupList.Add(noteGroup);
		}
		*/

		JsonData jsonNoteGroups = json["notegroups"];
		for(int i=0; i<noteGroupCount; i++)
		{
			JsonData jsonNoteList = jsonNoteGroups[i];
			int count2 = jsonNoteList.Count;
			for(int j=0; j<count2; j++)
			{
				string strTime = jsonNoteList[j]["time"].ToJson();
				float time = (float)Convert.ToDouble(strTime);

				string strGroupNumber = jsonNoteList[j]["groupnumber"].ToJson();
				int groupNumber = Convert.ToInt32(strGroupNumber);
				
				string strCreateNumber = jsonNoteList[j]["createnumber"].ToJson();
				int createNumber = Convert.ToInt32(strCreateNumber);

				string strLeftOrRight = jsonNoteList[j]["leftorright"].ToJson();
				int leftOrRight = Convert.ToInt32(strLeftOrRight);

				NoteInfo note = new NoteInfo();
				note.playTime = time;
				note.groupNumber = groupNumber;
				note.createNumber = createNumber;
				note.leftOrRight = leftOrRight;


				if(groupNumber != -1000)
				{
					if(noteDictionary.ContainsKey(groupNumber))
					{
						List<NoteInfo> noteGroup = noteDictionary[groupNumber];
						noteGroup.Add(note);
						noteGroup.Sort(CompareByTime);
					}
					else
					{
						List<NoteInfo> noteGroup = new List<NoteInfo>();
						noteGroup.Add(note);
						noteGroup.Sort(CompareByTime);
						noteDictionary[groupNumber] = noteGroup;
					}
				}
			}
		}

		JsonData jsonNoteCounts = json["notecounts"];
		string strNoteCount = jsonNoteCounts.ToJson();
		noteCounts = Convert.ToInt32 (strNoteCount);
	}

	public void Reset()
	{
		/*
		for(int i=0; i<noteGroupList.Count; i++)
		{
			List<NoteInfo> noteGroup = noteGroupList[i];

			for(int j=0; j<noteGroup.Count; j++)
			{
				noteGroup[j].prePlayed = false;
			}
		}
		*/

		/*
		foreach (KeyValuePair<int, List<NoteInfo> > item in noteDictionary)
		{
			for(int j=0; j<item.Value.Count; j++)
			{
				item.Value[j].prePlayed = false;
			}
		}
		*/
	}
}
