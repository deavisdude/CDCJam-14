using UnityEngine;
using System.Collections;

public class DeathSplat : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(Player.dead){
			anim.SetBool("dead", true);
			Invoke("Stand", 0.1f);
		}
	}

	void Stand(){
		anim.Play("Splat_Stand");
	}
}
