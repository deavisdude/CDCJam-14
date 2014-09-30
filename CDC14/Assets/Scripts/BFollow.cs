using UnityEngine;
using System.Collections;

public class BFollow : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Good" && col.gameObject.tag != "Antibody" && col.gameObject.tag != "Pew"){
			Destroy(gameObject);
		}
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
