using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {
	public string scene;
	public int difficulty;
	public Texture sprite;

	void Start(){
		if(SpawnManager.levelCount == 1 && Application.loadedLevelName != "Menu"){
			Time.timeScale = 0.0f;
			GameObject.Find("Prompt").GetComponent<GUITexture>().enabled = true;
		}else if(Application.loadedLevelName != "Menu"){
			Destroy(GameObject.Find("Prompt"));
			Destroy(GameObject.Find("NO"));
			Destroy(GameObject.Find("OK"));
			Destroy(GameObject.Find("Info"));
			Destroy(GameObject.Find("Return"));
		}
	}

	//public Texture texture;
	void OnMouseEnter(){
		if(gameObject.GetComponent<GUITexture>() != null){
			gameObject.GetComponent<GUITexture>().texture = sprite;
		}else{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void OnMouseExit(){
		if(gameObject.GetComponent<GUITexture>() != null){
			gameObject.GetComponent<GUITexture>().texture = null;
		}else{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	void OnMouseDown(){
		if(Application.loadedLevelName == "Menu"){
			Application.LoadLevel(scene);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
			GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();
			SpawnManager.enemyMultiplier = difficulty;
		}else{
			if(gameObject.name == "Return"){
				Destroy(GameObject.Find("Info"));
				Destroy(gameObject);
				Time.timeScale = 1.0f;
			}
			if(gameObject.name == "OK"){
				Destroy(GameObject.Find("Prompt"));
				Destroy(gameObject);
				Destroy(GameObject.Find("NO"));
				GameObject.Find("Info").GetComponent<GUITexture>().enabled = true;
				GameObject.Find("Return").GetComponent<BoxCollider>().enabled = true;
			}
			if(gameObject.name == "NO"){
				Destroy(GameObject.Find("Prompt"));
				Destroy(gameObject);
				Destroy(GameObject.Find("OK"));
				Destroy(GameObject.Find("Info"));
				Destroy(GameObject.Find("Return"));
				Time.timeScale = 1.0f;
			}
		}
	}
}
