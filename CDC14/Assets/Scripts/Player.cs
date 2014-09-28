using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public class PosOb{
		public Vector3 position;
		public float time;

		public PosOb(Vector3 pos, float t){
			position = pos;
			time = t;
		}
	}



	public GameObject[] pews = new GameObject[3];
	public int currIndex;
	public Sprite[] weapons = new Sprite[3];


	public static ArrayList delayPos = new ArrayList();
	public float speed = 5;
	Vector3 acc;

	void Start(){
		acc = new Vector3();
	}

	void CycleWeapon(){
		if(currIndex<2){
			currIndex++;
		}else{
			currIndex = 0;
		}
		GetComponent<Gun>().projectile = pews[currIndex];
		GameObject.Find("PlayerWeapon").GetComponent<SpriteRenderer>().sprite = weapons[currIndex];
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayWeaponChange();
	}

	void Update () {
		acc = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime,0);
		transform.position += acc;
		Vector3 newPos = new Vector3(transform.position.x+1.5f, transform.position.y, 0);
		delayPos.Add(new PosOb(newPos, Time.time));

		if(Input.GetMouseButtonDown(1)){
			CycleWeapon();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Good" && col.gameObject.tag != "Antibody" && col.gameObject.tag != "Border"){
			Destroy(gameObject);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayPlayerDeath();
		}
	}

	void OnDisable(){
		//Application.LoadLevel("lvl1");
	}
}
