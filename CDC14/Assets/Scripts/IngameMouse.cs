using UnityEngine;
using System.Collections;

public class IngameMouse : MonoBehaviour {

	public bool highlighted = false;
	public Texture sprite;
	
	//public GameObject item;
	//public Texture texture;
	void OnMouseEnter(){
		//gameObject.GetComponent<GUITexture>().texture = texture;
		if (GetComponent<GUITexture> () != null) {
			GetComponent<GUITexture> ().texture = sprite;
		}
		GetComponent<SpriteRenderer>().enabled = true;
		Debug.Log("box");
		highlighted = true;
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void Update(){
			if (name == "Continue") {
				if (Input.GetMouseButtonDown (0)) {
					Debug.Log("continue");

					GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
				}
			}
	
			//button 1
			if (gameObject.name == "MainMenu") {
				if (Input.GetMouseButtonDown (0)) {
					GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
				}
			}
			//button 2
			if (gameObject.name == "Quit") {
				if (Input.GetMouseButtonDown (0)) {
					GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
				}
			}

		
		
	}
	
	
	void OnMouseExit(){
		GetComponent<GUITexture>().enabled = false;
		highlighted = false;
		//gameObject.GetComponent<GUITexture>().texture = null;
	}
	
	//	void OnMouseDown(){
	//bought = true;
	
	//	}

}
