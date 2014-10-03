using UnityEngine;
using System.Collections;

public class TenofovirInfo : MonoBehaviour {
	public string decription;
	// Use this for initialization

		//decription = GUI.TextArea (new Rect (200, 200, 500, 20), decription, 100);



	void Start () {
		TextMesh tm = gameObject.GetComponent<TextMesh>();
		tm.fontSize = 15;
		tm.text = decription;

		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		tm.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
