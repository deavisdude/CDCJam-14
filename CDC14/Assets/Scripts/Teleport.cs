using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//noBoss
		if (Input.GetKey ("1")) {
			Application.LoadLevel("noBoss");
		}
		//Shop
		if (Input.GetKey ("2")) {
			Application.LoadLevel("Shop");
		}
		//lvl1
		if (Input.GetKey ("3")) {
			Application.LoadLevel("lvl1");
		}
        if (Input.GetKey("4"))
        {
            Application.LoadLevel("Credits");
        }
	}
}
