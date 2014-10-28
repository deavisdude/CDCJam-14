using UnityEngine;
using System.Collections;

public class Atripla : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Good"){
			PurchaseHolder.AtriplaTime = 7f;
			Destroy(gameObject);
		}
	}
}
