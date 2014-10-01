using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {
	public string scene;
	public int difficulty;
	
	//public Texture texture;
	void OnMouseEnter(){
		//gameObject.GetComponent<GUITexture>().texture = texture;
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//gameObject.GetComponent<GUITexture>().texture = null;
	}

	void OnMouseDown(){
		Application.LoadLevel(scene);
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
		GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();
		SpawnManager.enemyMultiplier = difficulty;
	}
}
