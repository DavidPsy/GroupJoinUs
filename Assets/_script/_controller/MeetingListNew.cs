using UnityEngine;
using System.Collections;

public class MeetingListNew : MonoBehaviour {
	
	public UIPanel meetingListPanel;
	public UIDraggablePanel meetingsPanel;
	public GameObject meetingGridGameObject;
	public GameObject meetingWarningGridGameObject;
	
	private UIGrid meetingGrid;
	
	// Use this for initialization
	void Start () {
		Debug.Log("MeetingList create");
		meetingGrid = meetingGridGameObject.GetComponentInChildren<UIGrid>();
		//meetingWarningGrid = meetingWarningGridGameObject.GetComponentInChildren<UIGrid>();
		destroyChilds(meetingGridGameObject);
		destroyChilds(meetingWarningGridGameObject);
		initMeetingData();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private void destroyChilds(GameObject gameObject) {
		for(int i=0; i<gameObject.transform.childCount; i++) {
			Debug.Log("delete");
			Destroy(gameObject.transform.GetChild(i).gameObject);
		}
	}
	
	private void initMeetingData() {
		ACTUnit messageOne = ACTUnit.createACTUnit("created by me","今天晚上魏公村麦颂KTV唱歌\n19:00见面，活动人员:lilly,mary,diff","");
		DataCenter.instance.actList.Add(messageOne);
		
		ACTUnit messageTwo = ACTUnit.createACTUnit("created by me","今天麦颂KTV唱歌\n20:00见面，活动人员:lilly,mary,diff","");
		DataCenter.instance.actList.Add(messageTwo);
		
		ACTUnit messageThree = ACTUnit.createACTUnit("created by me","晚上KTV唱歌\n21:00见面，活动人员:lilly,mary,diff","");
		DataCenter.instance.actList.Add(messageThree);
		
		
		//warning
		ACTUnit messageWarning = ACTUnit.createACTUnit("messageWarning","18点 有年度会议报告","");
		DataCenter.instance.meetingWarningList.Add(messageWarning);
		
		foreach(ACTUnit unit in DataCenter.instance.actList){
			GameObject o  =(GameObject) Instantiate(Resources.Load("message"));
			//UILabel label = o.GetComponentInChildren<UILabel>();
			UILabel[] labels = o.GetComponentsInChildren<UILabel>();
			for(int i=0; labels!=null&&i<labels.Length; i++) {
				if(labels[i].transform.parent == o.transform)
					labels[i].text = unit.content;
			}
			o.transform.parent = meetingGrid.transform;			
			o.transform.localPosition = new Vector3(0,0,0);
			o.transform.localScale= new Vector3(0.004167f,0.004167f,0.004167f);
			
			BoxCollider boxCollider = NGUITools.AddWidgetCollider(o);
			boxCollider.center = new Vector3(6f, -15.9814f, -8.478243f);
			boxCollider.size = new Vector3(566f, 100f, 0f);
			
			UIDragPanelContents dragPanelContents = o.AddComponent<UIDragPanelContents>();
			dragPanelContents.draggablePanel = meetingsPanel;
			
		}
		
		meetingGrid.repositionNow = true;
		
		foreach(ACTUnit unit in DataCenter.instance.meetingWarningList){
			GameObject o  =(GameObject) Instantiate(Resources.Load("MessageWarning"));
			UILabel label = o.GetComponentInChildren<UILabel>();
			label.text = unit.content;
			o.transform.parent = meetingWarningGridGameObject.transform;			
			o.transform.localPosition = new Vector3(0,0,0);
			o.transform.localScale= new Vector3(1,1,1);
		}
	}
}
