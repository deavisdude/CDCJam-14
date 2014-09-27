using UnityEngine;
using System.Collections;

public class BFollow : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		for(int i=0; i<MoveT.delayPos.Count; i++){
			MoveT.PosOb poso = (MoveT.PosOb) MoveT.delayPos[i];
			if((Time.time - poso.time) <= 0.3f && (Time.time - poso.time) >= 0.25f){
				transform.position = poso.position;
				MoveT.delayPos.Remove(poso);
			}
		}
	}
}
