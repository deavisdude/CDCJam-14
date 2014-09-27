using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public class Enemy{
		string Type;
		GameObject GOB;

		public enum types  {HIV, EarlyInfected, LateInfected, ForeignParticle};

		public Enemy(types type, GameObject gameOB){
			Type = type.ToString();
			GOB = gameOB;
		}

		void GenDir(){
			GOB.rigidbody2D.AddForce((GOB.transform.position - GameObject.Find("Player").transform.position)*500f);
		}
	}

	public static IList spawnQueue;
	public int enemyMultiplier;
	public GameObject[] prefabs;

	void Start () {
		enemyMultiplier = Application.levelCount*10;
		for(int i=0; i<enemyMultiplier; i++){
			spawnQueue.Add(new Enemy(Enemy.types.HIV, Send())); 
		}
	}
	
	GameObject Send(){
		GameObject spawner;
		if(Random.value <0.5f) spawner = GameObject.Find("Spawn1");
		else spawner = GameObject.Find("Spawn2");

		GameObject go = (GameObject) Instantiate(prefabs[0], spawner.transform.position, spawner.transform.rotation);
		return go;
	}

	void Update () {
	
	}
}
