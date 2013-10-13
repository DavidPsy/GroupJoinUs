using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ACTUnit {
	public string title;
	public string content;
	public string time;
	
	public int id;
	public int type;// 0 title 1 normal
	
	public static ACTUnit createACTUnit(string atitle ,string acontent, string atime) {
		ACTUnit unit = new ACTUnit();
		unit.title = atitle;
		unit.content = acontent;
		unit.time = atime;
		return unit;
	}
}

public class MeetingWarning {
	public string content;
}

public class DataCenter : MonoBehaviour {
	
	public	IList<ACTUnit>	actList = new List<ACTUnit>();
	public IList<ACTUnit> meetingWarningList = new List<ACTUnit>();
	public	IList<ACTUnit>	inviteList = new List<ACTUnit>();
	
	public static DataCenter instance = new DataCenter();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}



