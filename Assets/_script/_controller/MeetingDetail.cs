using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MeetingDetail : MonoBehaviour {
	public UIInput  titleInputl;
	public UIInput contentInput;
	public UILabel  datelabel;
	
	public UIPanel homePanel;
	
	private UIPanel meetingDetailPage;
	
	private UISlider dateSlider;
	
	public UIGrid refGrid;
	
	
	// Use this for initialization
	void Start () {
		meetingDetailPage = GameObject.Find("startMeetingPannel").GetComponent<UIPanel>();
		dateSlider = meetingDetailPage.GetComponentInChildren<UISlider>();
	}
	
	void OnSliderChange() 
    { 
		datelabel.text = System.DateTime.Now.ToShortDateString();
		
		long dTime = System.DateTime.Now.Ticks;
		dTime += (long)(dateSlider.sliderValue * 1000000000000);
		DateTime nTime = new DateTime(dTime);
		datelabel.text = nTime.ToString();
        
    } 
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void onCreate() {
		ACTUnit newUnit = ACTUnit.createACTUnit(titleInputl.text,contentInput.text,datelabel.text);
		newUnit.type = 1;
		DataCenter.instance.actList.Add(newUnit);
		
		
		GameObject []items =  GameObject.FindGameObjectsWithTag("Player");
		foreach(ACTUnit unit in DataCenter.instance.actList){
			GameObject o  =(GameObject) Instantiate(Resources.Load("messageItem"));
			o.name = "item";
			o.transform.parent = refGrid.transform;
			
			o.transform.localPosition = new Vector3(0,0,0);
			o.transform.localScale= new Vector3(1,1,1);
			
		}
		
		refGrid.repositionNow = true;
	}
}
