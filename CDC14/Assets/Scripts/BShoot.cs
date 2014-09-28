using UnityEngine;
using System.Collections;

public class BShoot : MonoBehaviour {

	public float speed = .15f;
	public float elapsedT = 0f;
	public GameObject prefab;
	
	void Update () {
		if(elapsedT >= speed){
			GameObject go = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
			go.rigidbody2D.AddForce(new Vector2(1000f, 0f));
			//GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayPewPew();
			elapsedT = 0f;
		}
		elapsedT += Time.deltaTime;
	}
}
