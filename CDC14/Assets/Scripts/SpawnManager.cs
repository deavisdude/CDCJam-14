using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public class Enemy {
		public string Type;
		public GameObject GOB;
		public enum types  {HIV, EarlyInfected, LateInfected, ForeignParticle, oneUp};

		public Enemy(types type, GameObject gameOB){
			Type = type.ToString();
			GOB = gameOB;
		}

		void GenDir(){
			GOB.rigidbody2D.AddForce((GOB.transform.position - GameObject.Find("Player").transform.position)*500f);
		}
	}

	public GameObject oneUp;

	public static List<Enemy> spawnQueue = new List<Enemy>();
	public static int levelCount = 1;
	public static int enemyMultiplier;
	public int enemies;
	public GameObject[] prefabs;

	void Start () {
		enemies = levelCount*enemyMultiplier;
		float rand;
		for(int i=0; i<enemies; i++){
			Enemy.types type;
			int index;
			rand = Random.value;
			if(rand <= .70f){type = Enemy.types.HIV; index=0;}
			else if(rand <=.80){type = Enemy.types.EarlyInfected; index=1;}
			else if(rand <=.95){type = Enemy.types.LateInfected; index=2;}
			else {type = Enemy.types.ForeignParticle; index=3;}

			spawnQueue.Add(new Enemy(type, prefabs[index])); 
		}

		rand = Random.value;
		if(rand <= .5f){
			spawnQueue.Add(new Enemy(Enemy.types.oneUp, oneUp));
			Debug.Log("ONE UP");
		}

		InvokeRepeating("Sender", 0f, 1f);
		InvokeRepeating("CheckForWin", 10f, 2f);
	}

	void Sender(){
		try{
			Send(spawnQueue[0]);
		}catch{
			CancelInvoke("Send");
		}
	}
	
	void Send(Enemy g){
		GameObject spawner;
		if(Random.value <0.5f) spawner = GameObject.Find("Spawn1");
		else spawner = GameObject.Find("Spawn2");

		GameObject go = (GameObject) Instantiate(g.GOB, spawner.transform.position, spawner.transform.rotation);
		spawnQueue.Remove(g);
	}

	void CheckForWin () {
		if(GameObject.FindGameObjectsWithTag("HIV").GetLength(0) < 1 &&
		   GameObject.FindGameObjectsWithTag("EarlyInfected").GetLength(0) < 1 &&
		   GameObject.FindGameObjectsWithTag("LateInfected").GetLength(0) < 1 &&
		   GameObject.FindGameObjectsWithTag("ForeignParticle").GetLength(0) < 1){
			Needle.bosstime = true;
			if(GameObject.FindGameObjectsWithTag("Boss").GetLength(0) < 1)EndLevel();
			
		}
	}

	void EndLevel(){
		levelCount++;
		Application.LoadLevel("Shop");
	}
}
