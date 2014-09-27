using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public class Enemy {
		public string Type;
		public GameObject GOB;

		public enum types  {HIV, EarlyInfected, LateInfected, ForeignParticle};

		public Enemy(types type, GameObject gameOB){
			Type = type.ToString();
			GOB = gameOB;
		}

		void GenDir(){
			GOB.rigidbody2D.AddForce((GOB.transform.position - GameObject.Find("Player").transform.position)*500f);
		}
	}

	public List<Enemy> spawnQueue = new List<Enemy>();
	public int enemyMultiplier;
	public GameObject[] prefabs;

	void Start () {
		enemyMultiplier = Application.levelCount*10;
		for(int i=0; i<enemyMultiplier; i++){
			spawnQueue.Add(new Enemy(Enemy.types.HIV, prefabs[0])); 
		}
		InvokeRepeating("Sender", 0f, 1f);
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

	void Update () {
	}
}
