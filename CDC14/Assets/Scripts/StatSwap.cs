using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatSwap : MonoBehaviour {
	public Sprite[] stats = new Sprite[9];

	void Start () {
		GetComponent<SpriteRenderer>().sprite = stats[Random.Range(0,8)];
	}
}
