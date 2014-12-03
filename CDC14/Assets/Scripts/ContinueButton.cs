using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void OnClick () {
        Player.gamepause = false;
	}

}
