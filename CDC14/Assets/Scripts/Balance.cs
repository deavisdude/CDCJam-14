using UnityEngine;
using System.Collections;

public class Balance : MonoBehaviour {
	TextMesh texts;
	private int total;
	public GameObject noteno;
	public GameObject controller1;
	public GameObject controller2;
	public GameObject controller3;
	public GameObject controller4;
	public GameObject controller5;

	public static bool hasVitamin = false;
	public static bool hasTest = false;
	public static bool hasBCell = false;
	public static int hasExtraLife = 0;

	// Use this for initialization
	void Start () {
		total = 500;
		texts = gameObject.GetComponent<TextMesh>();
		Font Arial = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);
		texts.text = total + " P";
		texts.font = Arial;
		texts.fontStyle = FontStyle.Normal;
		texts.fontSize = 35;
	
	}


	void BuyVitamin(int cost){
		if (total > cost && !hasVitamin == true) {
			total -= cost;
			hasVitamin = true;
		}else{
			noteno.SendMessage ("tomuch", SendMessageOptions.DontRequireReceiver);
		}
	}	
	void BuyTest(int cost){
		if (total > cost && !hasTest == true) {
			total -= cost;
			hasTest = true;
		}else {
			noteno.SendMessage ("tomuch", SendMessageOptions.DontRequireReceiver);
		}
	}
	void BuyBCell(int cost){
		if (total > cost && !hasBCell == true) {
			total -= cost;
			hasBCell = true;
		} else {
			noteno.SendMessage ("tomuch", SendMessageOptions.DontRequireReceiver);
		}
	}

	void BuyExtraLife(int cost){
		if (total > cost){
			total -= cost;
			hasExtraLife++;
		}else{
			noteno.SendMessage ("tomuch", SendMessageOptions.DontRequireReceiver);
		}
	}
		// Update is called once per frame
	void Update () {
		texts.text = total +" P";

		if (controller1.GetComponent<ShopMouse> ().highlighted) {
			//Vitamin
			if (controller1.GetComponent<ShopMouse> ().bought) {	
				BuyVitamin (200);
			}
		}
		//button2
		if (controller2.GetComponent<ShopMouse> ().highlighted) {
			//Test
			if (controller2.GetComponent<ShopMouse> ().bought) {	
				BuyTest(200);
			}
		} 
		//button2
		if (controller3.GetComponent<ShopMouse> ().highlighted) {
			//BCell
			if (controller3.GetComponent<ShopMouse> ().bought) {	
				BuyBCell(350);
			}
		}
		//button2
		if (controller4.GetComponent<ShopMouse> ().highlighted) {
			//ExtraLife
			if (controller4.GetComponent<ShopMouse> ().bought) {	
				BuyExtraLife(150);
			}
		}
		if (controller5.GetComponent<ShopMouse> ().highlighted) {
			//ExtraLife
			if (controller5.GetComponent<ShopMouse> ().leave) {	
				if(SpawnManager.prevLevel == "noBoss" && Player.dead != true)Application.LoadLevel("lvl1");
				else Application.LoadLevel("lvl1");
			}
		}
	}
}


