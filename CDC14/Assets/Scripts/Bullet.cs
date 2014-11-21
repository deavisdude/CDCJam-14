using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector3 camStart;
	void Start(){
		camStart = Camera.main.GetComponent<ObjectUtil> ().startPos;
	}
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "HIV"){
			//Destroy(col.gameObject);

			col.gameObject.GetComponent<HIVPilot>().enabled = false;
			col.rigidbody2D.velocity = new Vector3(Random.Range(5,8),Random.Range(-5,-19),0);
			col.collider2D.enabled = false;
			col.GetComponent<ObjectUtil>().shrink = true;

			//Camera.main.transform.position = new Vector3(camStart.x + Random.Range(-1f,1f),camStart.y + Random.Range(-1f,1f));
			//Invoke("RevertCam", .1f);

			Destroy(gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}

	}

	void RevertCam(){
		Camera.main.transform.position = Camera.main.GetComponent<ObjectUtil>().startPos;
	}
}
