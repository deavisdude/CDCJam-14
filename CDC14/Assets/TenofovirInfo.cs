using UnityEngine;
using System.Collections;

public class TenofovirInfo : MonoBehaviour {
	public string decription;
	// Use this for initialization

		//decription = GUI.TextArea (new Rect (200, 200, 500, 20), decription, 100);



	void Start () {
		guiText.fontSize = 19;
		guiText.text = decription;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
