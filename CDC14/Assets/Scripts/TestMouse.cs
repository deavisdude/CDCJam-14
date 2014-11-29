using UnityEngine;
using System.Collections;

public class TestMouse : MonoBehaviour {
	public Texture texture;
	//public GameObject PauseMenu;
	//public GameObject QuitPrompt;
	//public GameObject MenuPrompt;
	// Use this for initialization

	void OnMouseEnter(){
		if (GetComponent<GUITexture> ().texture == null) {
			GetComponent<GUITexture> ().texture = texture;	
		}
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
		
	}
	void OnMouseDown(){

		if (gameObject.name == "Continue") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
			Time.timeScale = 1.0f;
		}

		if (gameObject.name == "MainMenu") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
			//send message to pausehandler and pausebuthandler

		}


		/*

		if (MenuPrompt.activeSelf == true) {
			if (gameObject.name == "YesButton"){
				Application.LoadLevel("Menu");
			}
			if (gameObject.name == "NoButton"){
				//send message to pausehandler
			}
		}
		if (QuitPrompt.activeSelf == true) {
			if (gameObject.name == "YesButton"){
				Application.Quit();
			}
			if (gameObject.name == "NoButton"){
				//send message to pausehandler
			}
		}
		*/
	}
	void OnMouseExit(){
		if (GetComponent<GUITexture> ().texture == texture) {
			GetComponent<GUITexture> ().texture = null;	
		}
	}
}
