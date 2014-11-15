using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	float elapsedT = 0f;
	public float shootSpeed = 0.05f;

	void Update () {
		if(GameObject.Find("Muzzle Flash").GetComponent<SpriteRenderer>().enabled){
			GameObject.Find("Muzzle Flash").GetComponent<SpriteRenderer>().enabled = false;
		}

		if (Application.loadedLevelName != "Menu" && !Player.dead) {
			if (Input.GetButton ("Fire1") && elapsedT >= shootSpeed) {//!pause.activeSelf
				GameObject go = (GameObject)Instantiate (projectile, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
				float miss =Random.Range(-.04f,.04f);
				GameObject.Find("Muzzle Flash").GetComponent<SpriteRenderer>().enabled = true;
				go.transform.localRotation = new Quaternion(go.transform.localRotation.x,go.transform.localRotation.y,go.transform.localRotation.z+miss,go.transform.localRotation.w);
				go.rigidbody2D.AddRelativeForce (new Vector2 (1000f, 0f));
				GameObject.Find ("AudioManager").GetComponent<AudioManager> ().PlayPewPew ();
				elapsedT = 0f;
				transform.position = new Vector3(transform.position.x-.1f,transform.position.y,transform.position.z);
			}
			elapsedT += Time.deltaTime;
		}
	}
}
