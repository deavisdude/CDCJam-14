using UnityEngine;
using System.Collections;

public class LivesManager : MonoBehaviour {
	
	public static int lives = 3;

	void Start () {
		GetComponent<GUIText>().text = lives.ToString();
	}

	public void UpdateLives () {
		GetComponent<GUIText>().text = lives.ToString();
	}
}
