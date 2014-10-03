using UnityEngine;
using System.Collections;

public class ShopMouse : MonoBehaviour {
	
	public bool highlighted = false;
	public bool bought = false;
	private int num;
	public bool leave = false;

	//public GameObject item;
	//public Texture texture;
	void OnMouseEnter(){
		//gameObject.GetComponent<GUITexture>().texture = texture;
		GetComponent<SpriteRenderer>().enabled = true;
		highlighted = true;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void Update(){
		if (name == "Continue") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
				leave =true;
				//Debug.Log ("Bug");
				//if(SpawnManager.prevLevel == "noBoss")Application.LoadLevel("lvl1");
				//else Application.LoadLevel("lvl1");

			}else{
				leave =false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(SpawnManager.prevLevel == "noBoss")Application.LoadLevel("lvl1");
			else Application.LoadLevel("lvl1");
		}
		//button 1
		if (gameObject.name == "Vitamin") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
			}else{
				bought = false;
			}
		}
		//button 2
		if (gameObject.name == "Test") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
			}else{
				bought = false;
			}
		}
		//button 3
		if (gameObject.name == "BCell") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
				PurchaseHolder.HasBCell = true;
			}else{
				bought = false;
			}
		}
		//button 4
		if (gameObject.name == "ExtraLife") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
			}else{
				bought = false;
			}
		}


	}
	
	
	
	void OnMouseExit(){
		GetComponent<SpriteRenderer>().enabled = false;
		highlighted = false;
		//gameObject.GetComponent<GUITexture>().texture = null;
	}
	
	//	void OnMouseDown(){
	//bought = true;
	
	//	}
	
}
