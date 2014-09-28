using UnityEngine;
using System.Collections;

public class SrtuctureShow : MonoBehaviour {

	public GameObject controller;
	ShopMouse sm;

	void Start(){
		sm = controller.GetComponent<ShopMouse>();
	}

	void Update(){
		if(sm.highlighted){
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}else gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}
