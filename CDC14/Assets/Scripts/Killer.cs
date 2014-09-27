using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Good"){
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
