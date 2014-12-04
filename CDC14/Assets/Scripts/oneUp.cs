using UnityEngine;
using System.Collections;

public class oneUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Good"){
			LivesManager.lives++;
			Destroy(gameObject);
			//GameObject.Find("AudioMananger").GetComponent<AudioManager>().PlayPowerUp();
			GameObject.Find("Lives").GetComponent<LivesManager>().UpdateLives();
		}
	}
}
