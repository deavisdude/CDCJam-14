using UnityEngine;
using System.Collections;

public class LivesManager : MonoBehaviour {
	
	public static int lives = 3;

	void Start () {
		Debug.Log(PurchaseHolder.NewLives);
		lives += PurchaseHolder.NewLives;
		PurchaseHolder.NewLives = 0;
		GetComponent<GUIText>().text = lives.ToString();
	}

	public void UpdateLives () {
		GetComponent<GUIText>().text = lives.ToString();
	}
}
