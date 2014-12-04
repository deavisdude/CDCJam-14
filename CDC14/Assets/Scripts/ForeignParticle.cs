using UnityEngine;
using System.Collections;

public class ForeignParticle : MonoBehaviour {
	public int health = 50;
	float speed = 5f;
	public float spawnSpeed = 1.4f;
	public GameObject prefab;
	int spawnCount = 0;
	float scaleFactor;
	public Sprite hpbar;

	GameObject restSpot;


	void Start(){
		scaleFactor = transform.FindChild ("EnemyHp").GetComponent<Transform>().transform.localScale.x/health;
		restSpot = GameObject.Find("ForeignSpot");
		InvokeRepeating("SpawnCell", 3f, spawnSpeed);
	}

	void Update(){
		rigidbody2D.velocity = (restSpot.transform.position - transform.position)*speed*Time.deltaTime;
		if(health<1){
			Destroy(gameObject);
		}
		transform.FindChild ("EnemyHp").GetComponent<Transform>().transform.localScale = new Vector3(scaleFactor*health, transform.FindChild ("EnemyHp").GetComponent<Transform>().transform.localScale.y, transform.FindChild ("EnemyHp").GetComponent<Transform>().transform.localScale.z);
	}

	void SpawnCell(){
		if(spawnCount < 3){
			Instantiate(prefab, transform.position, transform.rotation);
			spawnCount++;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody"){
			health--;
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}

		if(col.gameObject.tag == "Pew"){
			
			if(col.GetComponent<DamageControl>().getType() == 1){
				gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayHitWeakness();
				Invoke("normalizeColor", 0.2f);
			}else{
				Color c = renderer.material.color;
				c.a = c.a/2;
				gameObject.GetComponent<SpriteRenderer>().color = c;
				Invoke("normalizeColor", 0.2f);
			}
			
			health -= (int)col.GetComponent<DamageControl>().getDmgFor();
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}

	}

	void normalizeColor(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
