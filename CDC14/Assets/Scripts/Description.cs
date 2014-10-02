using UnityEngine;
using System.Collections;

public class Description : MonoBehaviour {
	private SpriteRenderer sr;
	public GameObject controller;
	
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller.GetComponent<ShopMouse>().highlighted){
			GetComponent<SpriteRenderer>().enabled = true;
		}else GetComponent<SpriteRenderer>().enabled = false;
	}
}
