using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	public GameObject target;
	public float speed;
	public static bool bosstime=false;
	public static int health;
	public GameObject prefab;

	void Start(){
		health = SpawnManager.enemyMultiplier*4;
		InvokeRepeating("SpawnEnemy", 1f, 1.5f);
	}

	void Update () {
		if(bosstime){
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayBossRumble();
			rigidbody2D.velocity = (target.transform.position - transform.position)*speed*Time.deltaTime;
			//Debug.Log(target.transform.position - transform.position);
		}
		if(health < 1){Destroy(gameObject); bosstime =false;}
		//Debug.Log(health);
	}

	void SpawnEnemy(){
		if(bosstime){
			Instantiate(prefab, GameObject.Find("NeedleSpawner").transform.position, GameObject.Find("NeedleSpawner").transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody" || col.gameObject.tag == "Pew"){
			health--;
			Destroy(col.gameObject);
		}
	}
}
