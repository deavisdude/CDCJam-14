using UnityEngine;
using System.Collections;

public class DeleteHIV : MonoBehaviour {
	
	void Update () {
		if(Camera.main.WorldToScreenPoint(transform.position).x < 0){
			Destroy(gameObject);
		}
	}
}
