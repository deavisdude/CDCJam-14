using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {
	public Texture texture;
	void OnMouseEnter(){
		gameObject.GetComponent<GUITexture>().texture = texture;
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void OnMouseExit(){
		gameObject.GetComponent<GUITexture>().texture = null;
	}

	void OnMouseDown(){
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
		Application.LoadLevel("lvl1");
	}
}
