using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public class PosOb{
		public Vector3 position;
		public float time;

		public PosOb(Vector3 pos, float t){
			position = pos;
			time = t;
		}
	}



	public static ArrayList delayPos = new ArrayList();
	public float speed = 5;
	Vector3 acc;

	void Start(){
		acc = new Vector3();
	}

	void Update () {
		acc = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime,0);
		transform.position += acc;
		Vector3 newPos = new Vector3(transform.position.x+1.5f, transform.position.y, 0);
		delayPos.Add(new PosOb(newPos, Time.time));
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Good" && col.gameObject.tag != "Antibody"){
			Destroy(gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayPlayerDeath();
		}
	}

	void OnDisable(){
		Application.LoadLevel("lvl1");
	}
}
