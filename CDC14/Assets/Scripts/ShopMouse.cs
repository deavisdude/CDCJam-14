using UnityEngine;
using System.Collections;

public class ShopMouse : MonoBehaviour {

	public Texture texture;
	public GameObject balance;
	public bool highlighted = false;
	public bool bought = false;
	private GUITexture appear;
	public bool leave = false;

	void OnMouseEnter(){
		if (GetComponent<GUITexture> ().texture == null) {
			GetComponent<GUITexture> ().texture = texture;	
		}
		//GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
		if (gameObject.name == "Vitamin") {
			GameObject.Find ("VitaminDec").GetComponent<GUITexture> ().enabled = true;
			GameObject.Find ("VitaminPre").GetComponent<GUITexture> ().enabled = true;
		}
		if (gameObject.name == "Test") {
			GameObject.Find ("TestDec").GetComponent<GUITexture> ().enabled = true;
			GameObject.Find ("TestPre").GetComponent<GUITexture> ().enabled = true;
		}
		if (gameObject.name == "BCell") {
			GameObject.Find ("BCellDec").GetComponent<GUITexture> ().enabled = true;
			GameObject.Find ("BCellPre").GetComponent<GUITexture> ().enabled = true;
		}
		if (gameObject.name == "ExtraLife") {
			GameObject.Find ("ExtraLifeDec").GetComponent<GUITexture> ().enabled = true;
			GameObject.Find ("ExtraLifePre").GetComponent<GUITexture> ().enabled = true;
		}
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}

	void OnMouseDown(){
		if (gameObject.name == "Continue") {
			GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayToggle ();
			if(SpawnManager.prevLevel == "noBoss")Application.LoadLevel("lvl1");
			else Application.LoadLevel("lvl1");
		}

		if (gameObject.name == "Vitamin") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
			balance.SendMessage("Buy","Vitamin",SendMessageOptions.DontRequireReceiver);
		}
		if (gameObject.name == "Test") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
			balance.SendMessage("Buy","Test",SendMessageOptions.DontRequireReceiver);
		}
		if (gameObject.name == "BCell") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
			balance.SendMessage("Buy","BCell",SendMessageOptions.DontRequireReceiver);
		}
		if (gameObject.name == "ExtraLife") {
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayItemPurchase();
			balance.SendMessage("Buy","ExtraLife",SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnMouseExit(){
		if (GetComponent<GUITexture> ().texture == texture) {
			GetComponent<GUITexture> ().texture = null;	
		}
		if (gameObject.name == "Vitamin") {
			GameObject.Find ("VitaminDec").GetComponent<GUITexture> ().enabled = false;
			GameObject.Find ("VitaminPre").GetComponent<GUITexture> ().enabled = false;
		}
		if (gameObject.name == "Test") {
			GameObject.Find ("TestDec").GetComponent<GUITexture> ().enabled = false;
			GameObject.Find ("TestPre").GetComponent<GUITexture> ().enabled = false;
		}
		if (gameObject.name == "BCell") {
			GameObject.Find ("BCellDec").GetComponent<GUITexture> ().enabled = false;
			GameObject.Find ("BCellPre").GetComponent<GUITexture> ().enabled = false;
		}
		if (gameObject.name == "ExtraLife") {
			GameObject.Find ("ExtraLifeDec").GetComponent<GUITexture> ().enabled = false;
			GameObject.Find ("ExtraLifePre").GetComponent<GUITexture> ().enabled = false;
		}
	}
}
