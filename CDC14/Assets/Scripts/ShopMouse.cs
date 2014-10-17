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
	
	void OnMouseDown(){
		if (name == "Continue") {
				GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
				leave =true;
				//Debug.Log ("Bug");
				//if(SpawnManager.prevLevel == "noBoss")Application.LoadLevel("lvl1");
				//else Application.LoadLevel("lvl1");
		}

		//button 1
		if (gameObject.name == "Vitamin") {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
			
		}
		//button 2
		if (gameObject.name == "Test") {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
		}
		//button 3
		if (gameObject.name == "BCell") {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
				PurchaseHolder.HasBCell = true;
		}
		//button 4
		if (gameObject.name == "ExtraLife") {
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
				bought = true;
				PurchaseHolder.NewLives++;
				//Debug.Log(PurchaseHolder.NewLives);
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
