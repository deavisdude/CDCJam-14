using UnityEngine;
using System.Collections;

public class Description : MonoBehaviour {
	public string text;
	TextMesh tm;
	public GameObject controller;
	
	void Start () {
		tm = gameObject.GetComponent<TextMesh>();
		tm.fontSize = 25;
		
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		tm.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(controller.GetComponent<ShopMouse>().highlighted){
			GetComponent<MeshRenderer>().enabled = true;
		}else GetComponent<MeshRenderer>().enabled = false;
	}
}
