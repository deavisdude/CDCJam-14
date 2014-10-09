using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Application.loadedLevelName == "Menu") {


			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			mousePosition += new Vector3(.5f,-.5f,0);
			//transform.RotateAround(mousePosition,Vector3.forward,5 * 10*Time.deltaTime);
			transform.position = Vector2.Lerp(transform.position,mousePosition,moveSpeed);
		}
	}
}
