using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {
	public string scene;
	public int difficulty;
	public Texture sprite;

	void Start(){
		if(SpawnManager.levelCount == 1 && Application.loadedLevelName == "noBoss"){
			Time.timeScale = 0.0f;
			GameObject.Find("Prompt").GetComponent<GUITexture>().enabled = true;
		}else if(Application.loadedLevelName == "noBoss"){
			Destroy(GameObject.Find("Prompt"));
			Destroy(GameObject.Find("NO"));
			Destroy(GameObject.Find("OK"));
			Destroy(GameObject.Find("InfoTut"));
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
			GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = scene;
			GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
			if(scene != "Credits"){
				GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();
				SpawnManager.enemyMultiplier = difficulty;
			}
		}else{
			if(gameObject.name == "Return"){
				Destroy(GameObject.Find("InfoTut"));
				Destroy(gameObject);
				Time.timeScale = 1.0f;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
			}
			if(gameObject.name == "OK"){
				Destroy(GameObject.Find("Prompt"));
				Destroy(gameObject);
				Destroy(GameObject.Find("NO"));
				GameObject.Find("InfoTut").GetComponent<GUITexture>().enabled = true;
				GameObject.Find("Return").GetComponent<BoxCollider>().enabled = true;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
			}
			if(gameObject.name == "NO"){
				Destroy(GameObject.Find("Prompt"));
				Destroy(gameObject);
				Destroy(GameObject.Find("OK"));
				Destroy(GameObject.Find("InfoTut"));
				Destroy(GameObject.Find("Return"));
				Time.timeScale = 1.0f;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
			}
		}
	}
}
