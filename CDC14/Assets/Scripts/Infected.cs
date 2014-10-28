using UnityEngine;
using System.Collections;

public class Infected : MonoBehaviour {

	public bool early;


	public int health = 10;
	int target = 1;
	Vector3 target1;
	Vector3 target2;
	float speed = 10f;
	public float firespeed = 1.4f;
	public GameObject prefab;

	void Start () {
		target1 = GameObject.Find("Waypoint1").transform.position;
		target2 = GameObject.Find("Waypoint2").transform.position;

		InvokeRepeating("SwitchTarget", 0f, 7f);
		InvokeRepeating("Shoot", 3f, firespeed);
	}

	void Update () {
		if(target == 1)rigidbody2D.velocity = (target1 - transform.position)*speed*Time.deltaTime;
		else if(target == 2)rigidbody2D.velocity = (target2 - transform.position)*speed*Time.deltaTime;

		if(health<1){
			Destroy(gameObject);
		}
	}

	void Shoot(){
		GameObject[] go = new GameObject[5];
		for(int i=0; i<5; i++){
			go[i] = Instantiate(prefab, transform.position, transform.rotation)as GameObject;
		}
		go[0].rigidbody2D.AddForce((GameObject.Find("Target1").transform.position-transform.position)*HIVPilot.speed);
		go[1].rigidbody2D.AddForce((GameObject.Find("Target2").transform.position-transform.position)*HIVPilot.speed);
		go[2].rigidbody2D.AddForce((GameObject.Find("Target3").transform.position-transform.position)*HIVPilot.speed);
		go[3].rigidbody2D.AddForce((GameObject.Find("Target4").transform.position-transform.position)*HIVPilot.speed);
		go[4].rigidbody2D.AddForce((GameObject.Find("Target5").transform.position-transform.position)*HIVPilot.speed);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody"){
			health--;
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
			Color c = renderer.material.color;
			c.a = c.a/2;
			gameObject.GetComponent<SpriteRenderer>().color = c;
			Invoke("normalizeColor", 0.2f);
		}

		if(col.gameObject.tag == "Pew" && early){
			if(col.GetComponent<DamageControl>().getType() == 3){
				gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				Invoke("normalizeColor", 0.2f);
			}else{
				Color c = renderer.material.color;
				c.a = c.a/2;
				gameObject.GetComponent<SpriteRenderer>().color = c;
				Invoke("normalizeColor", 0.2f);
			}
			health -= (int)col.GetComponent<DamageControl>().getDmgEarly();
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}

		if(col.gameObject.tag == "Pew" && !early){

			if(col.GetComponent<DamageControl>().getType() == 2){
				gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				Invoke("normalizeColor", 0.2f);
			}else{
				Color c = renderer.material.color;
				c.a = c.a/2;
				gameObject.GetComponent<SpriteRenderer>().color = c;
				Invoke("normalizeColor", 0.2f);
			}
			health -= (int)col.GetComponent<DamageControl>().getDmgLate();
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}
	}

	void normalizeColor(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}

	void SwitchTarget(){
		if(target==1)target=2;
		else if(target==2)target=1;
	}
}
