using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//Physics2D.IgnoreCollision(Player.collider2D, collider2D);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "HIV"){
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
