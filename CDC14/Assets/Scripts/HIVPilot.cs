using UnityEngine;
using System.Collections;

public class HIVPilot : MonoBehaviour {

	float speed = 8f;//150
	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce((GameObject.Find("Player").transform.position-transform.position)*speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
