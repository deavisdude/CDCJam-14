using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	// Use this for initialization

	void Start () {
		//addOffset();
	}

	public GameObject leader;
	Vector3 offset;

	// Update is called once per frame
	void FixedUpdate () {
		if(Application.loadedLevelName == "Menu") {


			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//mousePosition += new Vector3(.5f,-.5f,0);
			if(gameObject == leader){
				transform.position = Vector2.Lerp(transform.position,mousePosition,moveSpeed);
			}else{
				offset = leader.transform.position - gameObject.transform.position;
				transform.position = Vector2.Lerp(transform.position,mousePosition-offset,moveSpeed);
			}
		}
	}

	void addOffset(){
		moveSpeed += Random.Range(0.01f, 0.1f);
	}

}
