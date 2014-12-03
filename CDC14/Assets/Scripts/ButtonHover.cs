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
            LivesManager.lives = 3;
			if(gameObject.name == "QuitButton"){
				Application.Quit();
			}
			if(scene != "Credits"){
				GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();
				SpawnManager.enemyMultiplier = difficulty;
			}
		
		}
	}
}
