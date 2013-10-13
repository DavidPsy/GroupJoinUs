using UnityEngine;
using System.Collections;
using System.Globalization;
using System;

public class CalendarControl : MonoBehaviour {
	
	public GameObject calendarObject;
	public UIFont uiFont;
	public UIAtlas altas;
	public UILabel calendarLabel;
	public GameObject calendarPanel;
	public UICamera camera;
	
	private DateTime currentDateTime;
	
	private float[] positionX = {-1.060278f,-0.7141955f,-0.2901423f,0.1051842f,0.4374313f,0.7754955f,1.114396f};
	//private float[] positionY = {0.2945928f,0.02920634f,-0.2334051f,-0.4892746f,-0.7245484f};
	private float[] positionY = {0.2502162f,0.02215627f,-0.2086624f,-0.4333756f,-0.6493607f,-0.8590516f};
	private float[] scale = {0.07f, 0.07f, 0f};
	
	// Use this for initialization
	void Start () {
		DateTime now = getCurrentTime();
		currentDateTime = now;
		init (currentDateTime);
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private void destroyChilds(GameObject gameObject) {
		Debug.Log("clear childs....");
		UILabel[] uiLabels = gameObject.GetComponentsInChildren<UILabel>();
		if(uiLabels==null)
			Debug.LogError("uilabels is null");
		else
			Debug.Log(uiLabels.Length);
		for(int i=0; uiLabels!=null&&i<uiLabels.Length; i++)
			Destroy(uiLabels[i]);
	}
	
	void init(DateTime dateTime) {
		destroyChilds(calendarObject);
		//当月有多少天
		int days = getDaysOfMonth(dateTime.Year, dateTime.Month);
		Debug.Log("当月有"+days+"天");
		//当月第一天是星期几
		int startOffset = getDayNOOfWeek(dateTime.Year, dateTime.Month);
		Debug.Log("当月第一天是"+startOffset);
		
		Calendar cal = CultureInfo.InvariantCulture.Calendar;
		int dayNo = cal.GetDayOfMonth(dateTime);
		
		int currentYear = dateTime.Year;
		int currentMonth = dateTime.Month;
		
		//当月第一天在星期的偏移值:0-星期一，6-星期日（类推）
		int offset = startOffset;
		for(int i=1; i<=days; i++) {
			DateTime selectDay = new DateTime(currentYear, currentMonth, i, new GregorianCalendar());
			//UILabel label = NGUITools.AddWidget<UILabel>(calendarObject);
			//GameObject dayObject = label.gameObject;
			GameObject dayObject = NGUITools.AddChild(calendarObject);
			UIButton button = dayObject.AddComponent<UIButton>();
			UILabel label = NGUITools.AddWidget<UILabel>(dayObject);
			UISprite sprite = NGUITools.AddWidget<UISprite>(dayObject);
			
			sprite.type = UISprite.Type.Sliced;  
	        sprite.name = "Background";  
	        sprite.depth = -9;  
	        //背景图片使用的图集  
	        sprite.atlas = altas;  
	        //图集中使用的精灵名字
	        sprite.spriteName = "sprite_"+selectDay.Year+"-"+selectDay.Month+"-"+selectDay.Day;  
	        sprite.transform.localScale = new Vector3(scale[0],scale[1],scale[2]); 
			
			string no = i+"";
			label.text = no;
			label.color = Color.black;
			if(i == dayNo)
				label.color = Color.blue;
			label.font = uiFont;
			int yNo = (i-1+offset)/7;
			int xNo = ((i+offset)%7-1)<0?(positionX.Length-1):((i+offset)%7-1);
			//Debug.Log(xNo+":"+yNo);
			
			label.transform.localScale = new Vector3(1f,1f,-9f);
			dayObject.transform.localPosition = new Vector3(positionX[xNo],positionY[yNo],0f);
			dayObject.transform.localScale = new Vector3(scale[0],scale[1],scale[2]);
			
			 //添加碰撞（有碰撞才能接收鼠标/触摸），大小与Button背景一致  
       		BoxCollider box = NGUITools.AddWidgetCollider(label.gameObject);  
        	box.center = new Vector3(0,0,-1);  
        	//box.size = new Vector3(sprite.transform.localScale.x, sprite.transform.localScale.y, 0);
			box.size = new Vector3(label.transform.localScale.x, label.transform.localScale.y, 0);
			
			//添加UIButton触发事件的必要组件，并关联之前生成的UISprite  
	        dayObject.AddComponent<UIButton>().tweenTarget = label.gameObject;  
	        //添加动态效果组件（大小、位移、音效）。（可选）  
	        dayObject.AddComponent<UIButtonScale>();  
	        dayObject.AddComponent<UIButtonOffset>();  
	        dayObject.AddComponent<UIButtonSound>(); 
			
			UIButtonMessage uiButtonMsg = label.gameObject.AddComponent<UIButtonMessage>();
			uiButtonMsg.target = calendarPanel;
			uiButtonMsg.functionName = "dayButtonClick";
			//uiButtonMsg.parameterStr = "";
		}
		
		//更新日历年月显示
		int month = cal.GetMonth(dateTime);
		int year = cal.GetYear(dateTime);
		
		calendarLabel.text = year+"/"+month;
	}
	
	/*
	 * 获取当前系统时间
	 */
	private DateTime getCurrentTime() {
		return DateTime.Now;
	}
	
	/*
	 * 获取某个月有多少天
	 */
	private int getDaysOfMonth(int year, int month) {
		Calendar cal = CultureInfo.InvariantCulture.Calendar;
		return cal.GetDaysInMonth(year, month);
	}
	
	/*
	 * 获取某年某月第一天是星期几(0-星期一，6-星期天）
	 */ 
	private int getDayNOOfWeek(int year, int month) {
		DateTime startDay = new DateTime(year, month, 01, new GregorianCalendar());
		Calendar cal = CultureInfo.InvariantCulture.Calendar;
		DayOfWeek dayOfWeek = cal.GetDayOfWeek(startDay);
		return getDayWeekOffset(dayOfWeek);
	}
	
	private int getDayWeekOffset(DayOfWeek dayOfWeek) {
		if(dayOfWeek == null)
			return 0;
		if(dayOfWeek == DayOfWeek.Monday)
			return 0;
		else if(dayOfWeek == DayOfWeek.Tuesday)
			return 1;
		else if(dayOfWeek == DayOfWeek.Wednesday)
			return 2;
		else if(dayOfWeek == DayOfWeek.Thursday)
			return 3;
		else if(dayOfWeek == DayOfWeek.Friday)
			return 4;
		else if(dayOfWeek == DayOfWeek.Saturday)
			return 5;
		else if(dayOfWeek == DayOfWeek.Sunday)
			return 6;
		return 0;
	}
	
	private DateTime addMonth(DateTime dateTime,int offset) {
		Calendar cal = CultureInfo.InvariantCulture.Calendar;
		return cal.AddMonths(dateTime, offset);
	}
	
	private DateTime addYears(DateTime dateTime, int offset) {
		Calendar cal = CultureInfo.InvariantCulture.Calendar;
		return cal.AddYears(dateTime, offset);
	}
	
	public void onMonthLeftClick() {
		DateTime newDay = addMonth(currentDateTime, -1);
		currentDateTime = newDay;
		init(newDay);
	}
	
	public void onMonthRightClick() {
		DateTime newDay = addMonth(currentDateTime, 1);
		currentDateTime = newDay;
		init(newDay);
	}
	
	public void onYearLeftClick() {
		DateTime newDay = addYears(currentDateTime, -1);
		currentDateTime = newDay;
		init(newDay);
	}
	
	public void onYearRightClick() {
		DateTime newDay = addYears(currentDateTime, 1);
		currentDateTime = newDay;
		init(newDay);
	}
	
	public void dayButtonClick() {
		GameObject currentClickObject = UICamera.currentTouch.current;
		UISprite uiSprite = currentClickObject.transform.parent.GetComponentInChildren<UISprite>();
		Debug.Log("click:"+uiSprite.spriteName);
		String time = uiSprite.spriteName;
		String[] array = time.Split(new char[]{'_'});
		if(array==null || array.Length<2)
			return;
		for(int i=0; i<array.Length; i++) {
			Debug.Log(array[i]);
		}
	}
}
