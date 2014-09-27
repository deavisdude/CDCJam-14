using UnityEngine;
using System.Collections;

public class Infected : MonoBehaviour {

	int target = 1;
	Vector3 target1;
	Vector3 target2;
	float speed = 10f;
	public GameObject prefab;

	void Start () {
		target1 = GameObject.Find("Waypoint1").transform.position;
		target2 = GameObject.Find("Waypoint2").transform.position;

		InvokeRepeating("SwitchTarget", 0f, 7f);
		InvokeRepeating("Shoot", 4f, 3.5f);
	}

	void Update () {
		if(target == 1)rigidbody2D.velocity = (target1 - transform.position)*speed*Time.deltaTime;
		else if(target == 2)rigidbody2D.velocity = (target2 - transform.position)*speed*Time.deltaTime;
	}

	void Shoot(){
		GameObject go = Instantiate(prefab, transform.position, transform.rotation)as GameObject;
		go.rigidbody2D.AddForce((GameObject.Find("Player").transform.position-transform.position)*HIVPilot.speed);
	}

	void SwitchTarget(){
		if(target==1)target=2;
		else if(target==2)target=1;
	}
}
