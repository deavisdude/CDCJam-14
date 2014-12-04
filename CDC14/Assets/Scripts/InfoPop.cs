using UnityEngine;
using System.Collections;

public class InfoPop : MonoBehaviour {

	public GameObject target;
	public Vector3 currTarget;
	public float speed;
	public Vector3 startPos;

	void Start(){
		startPos = transform.position;
		currTarget = startPos;
	}
	
	void Update () {
		if(Needle.bosstime && currTarget == startPos){
			currTarget = target.transform.position;
		}
		rigidbody2D.velocity = (currTarget - transform.position)*speed*Time.deltaTime;
		if(Mathf.Abs(this.transform.position.y - this.target.transform.position.y)<0.2 || GameObject.FindGameObjectWithTag("Boss") == null)currTarget = startPos;
	}
}
