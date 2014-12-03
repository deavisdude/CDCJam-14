using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ButtonTest : MonoBehaviour {
    Button button;

	void OnMouseEnter(){
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
	}
	void OnMouseDown()
    {	
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
    }
	void OnMouseExit(
      ){
	}
}
