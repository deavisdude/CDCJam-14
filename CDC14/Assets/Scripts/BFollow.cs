using UnityEngine;
using System.Collections;

public class BFollow : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		for(int i=0; i<Player.delayPos.Count; i++){
			Player.PosOb poso = (Player.PosOb) Player.delayPos[i];
			if((Time.time - poso.time) <= 0.3f && (Time.time - poso.time) >= 0.25f){
				transform.position = poso.position;
				Player.delayPos.Remove(poso);
			}
		}
	}
}
