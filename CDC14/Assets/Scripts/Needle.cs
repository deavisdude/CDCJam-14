using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	public GameObject target;
	public float speed;
	public static bool bosstime=false;
	public static int health;
	public GameObject prefab;
	bool soundPlayed = false;
	float scaleFactor;

	void Start(){
		health = SpawnManager.enemyMultiplier*50;
		InvokeRepeating("SpawnEnemy", 1f, 3f);
	}

	void Update () {
		if(bosstime){
			if(soundPlayed == false){
				OnBossTime();
				soundPlayed = true;
			}
			rigidbody2D.velocity = (target.transform.position - transform.position)*speed*Time.deltaTime;
			//Debug.Log(target.transform.position - transform.position);
		}
		if(health < 1){
			Destroy(gameObject); bosstime =false;
			GameObject.Find("AudioManager").GetComponent<AudioManager>().StopBossLoop();
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();
		}
		//Debug.Log(health);


	}

	void SpawnEnemy(){
		if(bosstime){
			Instantiate(prefab, GameObject.Find("NeedleSpawner").transform.position, GameObject.Find("NeedleSpawner").transform.rotation);
		}
	}

	void OnBossTime(){
		AudioManager am= GameObject.Find("AudioManager").GetComponent<AudioManager>();
		am.PlayBossRumble();
		am.StopMainLoop();
		am.PlayBossLoop();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Antibody" || col.gameObject.tag == "Pew"){
			health--;
			Destroy(col.gameObject);
		}
	}
}
