using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int HIVKills = 0;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "HIV"){
			//Destroy(col.gameObject);

			col.gameObject.GetComponent<HIVPilot>().enabled = false;
			col.rigidbody2D.velocity = new Vector3(Random.Range(5,8),Random.Range(-5,-19),0);
			col.collider2D.enabled = false;
			col.GetComponent<ObjectUtil>().shrink = true;
			HIVKills++;

			if(HIVKills > GetComponent<DamageControl>().getDmgHIV()){
				Destroy(gameObject);
			}
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEnemyHit();
		}

	}
}
