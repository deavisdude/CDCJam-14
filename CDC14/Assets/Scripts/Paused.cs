using UnityEngine;
using System.Collections;

public class Paused : MonoBehaviour {
	// Use this for initialization
	public GameObject ContinuePrefab;
	public GameObject MainMenuPrefab;
	public GameObject QuitPrefab;
	void Start () {
		//GetComponent<GUITexture>().enabled = true;
		Instantiate (ContinuePrefab);
		Instantiate (MainMenuPrefab);
		Instantiate (QuitPrefab);
		Time.timeScale = 0.0f;
		Debug.Log ("paused");

	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
