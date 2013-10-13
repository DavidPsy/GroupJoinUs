using UnityEngine;
using System.Collections;

public class MsgItem : MonoBehaviour {
	
	public UILabel label;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void setText (string text) {
		UILabel label = GetComponentInChildren<UILabel>();
		label.text = text;
		
	}
	
	void OnClick()
	{
		Debug.Log("------got it ");
			
		/**
		 UISprite ui = GetComponentsInChildren<UISprite>()[1];
		 ui.spriteName = "button_msg_cbg";
		
		 UILabel label = GetComponentInChildren<UILabel>();
		 label.text = "new label after clicked";
		 
		 */
		
				/**  code that create a cprite
		UIAtlas atlas = Resources.Load("Atlas/Test Atlas", typeof(UIAtlas)) as UIAtlas;
            GameObject parent = GameObject.Find("point");
            UISprite sprite = NGUITools.AddSprite(parent,atlas,"1");
            sprite.MakePixelPerfect();
            parent.GetComponent<UIGrid>().repositionNow = true;
            
            */
	}
}
