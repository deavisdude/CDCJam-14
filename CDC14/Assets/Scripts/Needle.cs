using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	public GameObject target;
	public float speed;
	public static bool bosstime=false;
	public static int health;

	void Start(){
		health = SpawnManager.enemyMultiplier*4;
	}

	void Update () {
		if(bosstime){
			rigidbody2D.velocity = (target.transform.position - transform.position)*speed*Time.deltaTime;
		}
		if(health < 1)Destroy(gameObject);
		Debug.Log(health);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody"){
			health--;
			Destroy(col.gameObject);
		}
	}
}
