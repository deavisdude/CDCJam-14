using UnityEngine;
using System.Collections;

public class DamageControl : MonoBehaviour {

	public int ARType;
	float dmgHIV;
	float dmgEarly;
	float dmgLate;
	float dmgFor;

	public static bool atripla;

	public float getDmgHIV(){
		return dmgHIV;
	}

	public float getDmgEarly(){
		return dmgEarly;
	}

	public float getDmgLate(){
		return dmgLate;
	}

	public float getDmgFor(){
		return dmgFor;
	}

	public int getType(){
		return ARType;
	}

	void Start () {
		switch(ARType){
		case 1:
			dmgHIV = 2;
			dmgEarly = 1;
			dmgLate = 1;
			dmgFor = 2;
			break;
		case 2:
			dmgHIV = 1;
			dmgEarly = 1;
			dmgLate = 2;
			dmgFor = 1;
			break;
		case 3:
			dmgHIV = 1;
			dmgEarly = 2;
			dmgLate = 1;//0.5f;
			dmgFor = 1;
			break;
		}
		}

	void Update(){
		if(PurchaseHolder.AtriplaTime >0f){
			switch(ARType){
				case 1:
					dmgHIV = 4;
					dmgEarly = 1.5f;
					dmgLate = 1.5f;
					dmgFor = 2.5f;
					break;
				case 2:
					dmgHIV = 2;
					dmgEarly = 1.5f;
					dmgLate = 2.5f;
					dmgFor = 1.5f;
					break;
				case 3:
					dmgHIV = 2;
					dmgEarly = 2.5f;
					dmgLate = 1;
					dmgFor = 1.5f;
					break;
			}
			PurchaseHolder.AtriplaTime-=Time.deltaTime;
		}
	}

}

