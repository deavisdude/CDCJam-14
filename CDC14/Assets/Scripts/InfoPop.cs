using UnityEngine;
using System.Collections;

public class InfoPop : MonoBehaviour {

	public GameObject target;
	public float speed;
	public Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}
	
	void Update () {
		if(Needle.bosstime){
			rigidbody2D.velocity = (target.transform.position - transform.position)*speed*Time.deltaTime;
		}
		if(Mathf.Abs(this.transform.position.y - this.target.transform.position.y)<0.2 || GameObject.FindGameObjectWithTag("Boss") == null)target.transform.position = startPos;
	}
}
