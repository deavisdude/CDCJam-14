using UnityEngine;
using System.Collections;

public class ForeignParticle : MonoBehaviour {
	public int health = 50;
	float speed = 5f;
	public float spawnSpeed = 1.4f;
	public GameObject prefab;

	GameObject restSpot;


	void Start(){
		restSpot = GameObject.Find("ForeignSpot");
		InvokeRepeating("SpawnCell", 3f, spawnSpeed);
	}

	void Update(){
		rigidbody2D.velocity = (restSpot.transform.position - transform.position)*speed*Time.deltaTime;
	}

	void SpawnCell(){
		Instantiate(prefab, transform.position, transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody"){
			health--;
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
			if(health<1){
				Destroy(gameObject);
				Destroy(col.gameObject);
			}
		}
	}
}
