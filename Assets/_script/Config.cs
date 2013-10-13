using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {
	
	public UIPanel loadingPanel;
	//选择参与活动的好友页面
	public UIPanel chooseFriendPanel;
	//选择一个活动或者新建立活动内容页面
	public UIPanel chooseActivePanel;
	//好友列表页
	public UIPanel friendListPanel;
	//活动列表页（主页面）
	public UIPanel meetingListPanel;
	//创建一个活动页面
	public UIPanel createMeetingPanel;
	//活动广场页面
	public UIPanel meetingBroastPanel;
	
	private static Config config = new Config();
	
	public static Config getInstance() {
		return config;
	}
	
	// Use this for initialization
	void Start () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = new Vector3(1,1,1);
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void load() {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = new Vector3(1,1,1);
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToMeetingListPanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = new Vector3(1,1,1);
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToFriendListPanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = new Vector3(1,1,1);
		meetingListPanel.transform.localScale = Vector3.zero;
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToChooseFriendPanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = new Vector3(1,1,1);
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = Vector3.zero;
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToChooseActivePanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = new Vector3(1,1,1);
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = Vector3.zero;
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToCreateMeetingPanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = Vector3.zero;
		createMeetingPanel.transform.localScale = new Vector3(1,1,1);
		meetingBroastPanel.transform.localScale = Vector3.zero;
	}
	
	void changeToMeetingBroastPanel () {
		loadingPanel.transform.localScale = Vector3.zero;
		chooseFriendPanel.transform.localScale = Vector3.zero;
		chooseActivePanel.transform.localScale = Vector3.zero;
		friendListPanel.transform.localScale = Vector3.zero;
		meetingListPanel.transform.localScale = Vector3.zero;
		createMeetingPanel.transform.localScale = Vector3.zero;
		meetingBroastPanel.transform.localScale = new Vector3(1,1,1);
	}
}
