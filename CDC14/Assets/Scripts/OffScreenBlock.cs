using UnityEngine;
using System.Collections;

public class OffScreenBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.WorldToScreenPoint(transform.position).x > Screen.width || Camera.main.WorldToScreenPoint(transform.position).x < 0){
			{
				this.transform.position = Vector2.zero;
			}
		}
	}
}
