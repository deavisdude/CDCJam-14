using UnityEngine;
using System.Collections;

public class ObjectUtil : MonoBehaviour {
	public bool shrink = false;

	public Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}

	void Update(){
		if(shrink){
			Vector3 s = transform.localScale;
			transform.localScale = new Vector3(s.x - s.x*.1f,s.y - s.y*.1f,s.z - s.z*.1f);
		}

	}
}
