using UnityEngine;
using System.Collections;

public class Paused : MonoBehaviour {
	// Use this for initialization
	public GameObject ContinuePrefab;
	public GameObject MainMenuPrefab;
	public GameObject QuitPrefab;
	public Texture texture;
	void Start () {
		if (GetComponent<GUITexture> ().texture == null){
			GetComponent<GUITexture> ().texture = texture;	
		}
		GetComponent<GUITexture>().enabled = true;

		ContinuePrefab.SetActive (true);
		MainMenuPrefab.SetActive (true);
		QuitPrefab.SetActive (true);
		Time.timeScale = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Player.gamepause == false) {
			Destroy(gameObject);
			Time.timeScale = 1.0f;
		}
	
	}
}
