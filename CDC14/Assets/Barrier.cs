using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

	void OnCollisionEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			col.gameObject.rigidbody2D.velocity = new Vector3(0f,0f,0f);
		}
	}
}
