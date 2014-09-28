using UnityEngine;
using System.Collections;

public class ShopMouse : MonoBehaviour {

	public bool highlighted = false;

	//public Texture texture;
	void OnMouseEnter(){
		//gameObject.GetComponent<GUITexture>().texture = texture;
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		highlighted = true;
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("lvl1");
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		highlighted = false;
		//gameObject.GetComponent<GUITexture>().texture = null;
	}
	
	void OnMouseDown(){
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
	}
}
