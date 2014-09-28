using UnityEngine;
using System.Collections;

public class ShopMouse : MonoBehaviour {
	public Texture texture;

	// Use this for initialization
	void OnMouseEnter(){
		gameObject.GetComponent<GUITexture>().texture = texture;
		Debug.Log("Test");
	}
	
	// Update is called once per frame
	void OnMouseExit(){
		gameObject.GetComponent<GUITexture>().texture = null;

	}

	void OnMouseDown(){

	}
}
