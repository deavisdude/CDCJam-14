using UnityEngine;
using System.Collections;

public class MenuPrompt : MonoBehaviour {

	// Use this for initialization
	// Use this for initialization
	public GameObject YesPrefab;
	public GameObject NoPrefab;

	void Start () {
		YesPrefab.SetActive (true);
		NoPrefab.SetActive (true);
	}
}

