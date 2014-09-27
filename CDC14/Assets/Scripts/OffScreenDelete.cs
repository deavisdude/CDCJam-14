using UnityEngine;
using System.Collections;

public class OffScreenDelete : MonoBehaviour {
	
	void Update () {
		if(Camera.main.WorldToScreenPoint(transform.position).x > Screen.width){
			Destroy(gameObject);
		}
	}
}
