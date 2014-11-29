using UnityEngine;
using System.Collections;

public class PauseButHandler : MonoBehaviour {
	public GameObject ContinueButton;
	public GameObject QuitButton;
	public GameObject MenuButton;
	public GameObject YesButton;
	public GameObject NoButton;

	// Use this for initialization
	void Awake(){
		ContinueButton.SetActive (true);
		QuitButton.SetActive (true);
		MenuButton.SetActive (true);
		//GameObject.Find ("MenuPrompt").;
	}
	void Update(){
		if (Player.gamepause == false) {
			Destroy(gameObject);
		}
	}
}
