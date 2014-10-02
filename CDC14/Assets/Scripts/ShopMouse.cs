using UnityEngine;
using System.Collections;

public class ShopMouse : MonoBehaviour {
	
	public bool highlighted = false;
	public bool bought = false;
	private int num;
	//public GameObject item;
	//public Texture texture;
	void OnMouseEnter(){
		//gameObject.GetComponent<GUITexture>().texture = texture;
		GetComponent<SpriteRenderer>().enabled = true;
		highlighted = true;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	
	void Update(){
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
			}else{
				bought = false;
			}
		}
		//button 4
		if (gameObject.name == "AddLife") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
			}else{
				bought = false;
			}
		}

		if (gameObject.name == "Continue") {
			if (Input.GetMouseButtonDown (0)) {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();

					

			}else{
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
