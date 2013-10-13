using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	
	public Config config;
	
	// Use this for initialization
	void Start () {
		Debug.Log("loading main");
		config.load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
