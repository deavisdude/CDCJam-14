using UnityEngine;
using System.Collections;

public class HIVCollision : MonoBehaviour {
	float speed = 80f;//150
	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce(new Vector2((-speed),0));

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			Destroy (gameObject);
			//will remove when new interaction is placed
			Debug.Log ("Been hit");
		}
		if (col.gameObject.name == "Antibody") {
			Destroy (gameObject);
			Debug.Log ("enemy destroy");

			Destroy (col.gameObject);
		}
	}
}
