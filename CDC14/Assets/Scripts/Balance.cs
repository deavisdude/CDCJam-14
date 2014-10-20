﻿using UnityEngine;
using System.Collections;

public class Balance : MonoBehaviour {
	GUIText texts;
	private int total;
	private int wcount = 0;
	private int hcount = 0;
	private int price;
	public static bool hasVitamin = false;
	public static bool hasTest = false;
	public static bool hasBCell = false;
	public static int hasExtraLife = 0;
	// Use this for initialization
	void Start () {
		total = 500;
		texts = gameObject.GetComponent<GUIText>();
		texts.color = Color.white;
		//Font Agency = (Font)Resources.Load("Assets/Sprites/Font/4822485673.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);
		texts.text = total + " P";
		//texts.font = Agency;
		texts.fontStyle = FontStyle.Normal;
		texts.fontSize = 29;
	
	}

	void Buy(string item){
		switch(item){
			case "Vitamin":
				price = 200;
				if(!hasVitamin){
					if (total > price) {
						total -= price;
						hasVitamin = true;
					} else {
						StartCoroutine(FlashWarning());
						wcount = 0;
					}
				}else{
					StartCoroutine(FlashHave());
					hcount = 0;
				}
			break;
			case "Test":
				price = 200;
				if(!hasTest){
					if (total > price) {
						total -= price;
						hasTest = true;
					} else {
						StartCoroutine(FlashWarning());
						wcount = 0;
					}
				}else{
					StartCoroutine(FlashHave());
					hcount = 0;
				}
			break;
			case "BCell":
				price = 350;
				if(!hasBCell){
					if (total > price) {
						total -= price;
						hasBCell = true;
						PurchaseHolder.HasBCell = true; 
					} else {
						StartCoroutine(FlashWarning());
						wcount = 0;
					}
				}else{
					StartCoroutine(FlashHave());
					hcount = 0;
				}
				break;
			case "ExtraLife":
				price = 150;
					if (total > price) {
						total -= price;
						PurchaseHolder.NewLives++;
						//hasExtraLife++;
					} else {
						StartCoroutine(FlashWarning());
						wcount = 0;
					}
			break;
		}
	}
	IEnumerator FlashWarning(){
		while (wcount < 2){
			GameObject.Find ("Warning").GetComponent<GUIText> ().enabled = true;
			GameObject.Find ("Warning").GetComponent<GUIText> ().color = Color.red;
			yield return new WaitForSeconds (.5f);
			GameObject.Find ("Warning").GetComponent<GUIText> ().color = Color.white;
			yield return new WaitForSeconds (.5f);
			wcount++;
		}
		GameObject.Find ("Warning").GetComponent<GUIText> ().enabled = false;
	}	
	IEnumerator FlashHave(){
		while (hcount < 2){
			GameObject.Find ("Have").GetComponent<GUIText> ().enabled = true;
			GameObject.Find ("Have").GetComponent<GUIText> ().color = Color.red;
			yield return new WaitForSeconds (1);
			GameObject.Find ("Have").GetComponent<GUIText> ().color = Color.white;
			yield return new WaitForSeconds (1);
			hcount++;
		}
		GameObject.Find ("Have").GetComponent<GUIText> ().enabled = false;
	}	

	void Update(){
		texts.text = total+" P";
	}
}


