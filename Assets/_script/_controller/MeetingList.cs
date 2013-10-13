using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class MeetingList : MonoBehaviour {
	
	
	private UIPanel meetingListPage;
	private UIGrid grid;
	
	private bool hasInitData = false;
	
	// Use this for initialization
	void Start () {
		meetingListPage = GameObject.Find("mainPannel").GetComponent<UIPanel>();
		grid = meetingListPage.GetComponentInChildren<UIGrid>();
		
		this.initFakeData();
	}
	
	public void initFakeData() {
		// tmp create fake data
		ACTUnit titleInvit =  ACTUnit.createACTUnit("invite me","","");
		titleInvit.type = 0;
		DataCenter.instance.inviteList.Add(titleInvit);
		
		ACTUnit aInvit =  ACTUnit.createACTUnit("invite me to dinner","nothing","tomorrow?");
		aInvit.type = 1;
		DataCenter.instance.inviteList.Add(aInvit);
		
		//actlist created by myself
		ACTUnit titleMe =  ACTUnit.createACTUnit("created by me","","");
		titleMe.type = 0;
		DataCenter.instance.actList.Add(titleMe);
		
		GameObject []items =  GameObject.FindGameObjectsWithTag("Player");
		foreach(ACTUnit unit in DataCenter.instance.actList){
			GameObject o  =(GameObject) Instantiate(Resources.Load("messageItem"));
			o.name = "item";
			o.transform.parent = grid.transform;
			
			UILabel tmpLabel = o.GetComponentInChildren<UILabel>();
			tmpLabel.text = unit.title + " " + unit.time;
			
			o.transform.localPosition = new Vector3(0,0,0);
			o.transform.localScale= new Vector3(1,1,1);
		}
		
		grid.repositionNow = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
