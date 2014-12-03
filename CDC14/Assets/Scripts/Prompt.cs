using UnityEngine;
using System.Collections;

public class Prompt : MonoBehaviour {
	public GameObject ContinueButton;
	public GameObject MainMenuButton;
	public GameObject QuitButton;
	void Awake(){
		ContinueButton.SetActive (true);
		MainMenuButton.SetActive (true);
		QuitButton.SetActive (true);
	}
	void Update(){
		if (Player.gamepause == false) {
			ContinueButton.SetActive (false);
			MainMenuButton.SetActive (false);
			QuitButton.SetActive (false);
		}
	}
}
