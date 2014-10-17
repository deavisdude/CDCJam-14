using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = "Menu";
			GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
		}
	}
}
