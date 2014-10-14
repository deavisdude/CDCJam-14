using UnityEngine;
using System.Collections;

public class PauseDescription : MonoBehaviour {

	public GameObject controller;
	IngameMouse im;
	
	void Start(){
		im = controller.GetComponent<IngameMouse>();
	}
	
	void Update(){
		if(im.highlighted){
			gameObject.GetComponent<GUIText>().enabled = true;
		}else gameObject.GetComponent<GUIText>().enabled = false;
	}
}
