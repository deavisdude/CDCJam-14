using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision (Player.collider, collider);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
