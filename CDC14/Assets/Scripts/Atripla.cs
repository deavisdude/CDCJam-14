using UnityEngine;
using System.Collections;

public class Atripla : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Good"){
			PurchaseHolder.AtriplaTime = 17f;
			//GameObject.Find("AudioMananger").GetComponent<AudioManager>().PlayPowerUp();
			Destroy(gameObject);
		}
	}
}
