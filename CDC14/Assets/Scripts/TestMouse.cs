using UnityEngine;
using System.Collections;

public class TestMouse : MonoBehaviour {
	public Texture texture;
	public GameObject Menu;
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
			Destroy(Menu);


		}
		if (gameObject.name == "MainMenu") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
			Application.LoadLevel("Menu");
			GameObject.Find("Menu").SetActive(false);
			GameObject.Find("Continue").SetActive(false);
			GameObject.Find("MainMenu").SetActive(false);
			GameObject.Find("Quit").SetActive(false);
		}
		if (gameObject.name == "Quit") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
			Application.Quit();

		}
	}
	void OnMouseExit(){
		if (GetComponent<GUITexture> ().texture == texture) {
			GetComponent<GUITexture> ().texture = null;	
		}
	}
}
