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

	public GameObject smokePrefab;

	public static bool dead = false;

	public GameObject[] pews = new GameObject[3];
	public int currIndex;
	public Sprite[] weapons = new Sprite[3];


	public static ArrayList delayPos = new ArrayList();
	public float speed = 5;
	Vector3 acc;

	float dist;
	float leftLimitation;
	float rightLimitation;
	float upLimitation;
	float downLimitation;

	void Start(){
		acc = new Vector3();

		dist = (transform.position.z - Camera.main.transform.position.z);
		leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0.03f,0,dist)).x;
		rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(.97f,0,dist)).x;
		upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,.97f,dist)).y;
		downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,.03f,dist)).y;

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
		if(!dead){
			acc = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime,0);
			transform.position += acc;
			Vector3 pos = transform.position;

			pos.x = Mathf.Clamp(pos.x, leftLimitation, rightLimitation);
			pos.y = Mathf.Clamp(pos.y, downLimitation, upLimitation);

			transform.position = pos;

			Vector3 newPos = new Vector3(transform.position.x+1.5f, transform.position.y, 0);
			delayPos.Add(new PosOb(newPos, Time.time));
		}
		if(Input.GetMouseButtonDown(1)){
			CycleWeapon();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Good" && col.gameObject.tag != "Antibody" && col.gameObject.tag != "Pew" && col.gameObject.tag != "Border"){
			dead = true;
			GameObject smoke = (GameObject)Instantiate(smokePrefab, transform.position, transform.rotation);
			smoke.transform.parent = transform;
			GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("PlayerWeapon").GetComponent<Rigidbody2D>().gravityScale = 1;
			Invoke("Kill", 2f);
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayPlayerDeath();
		}
	}

	void Kill(){
		LivesManager.lives--;
		if(LivesManager.lives < 0){
			dead = false;
			Application.LoadLevel("Credits");
		}else{
			dead = false;
			Application.LoadLevel("Shop");
		}
	}
	

	void OnTriggerEnter2D(Collision2D col){
		if(col.gameObject.tag == "Border"){
			Debug.Log("HitWall");
		}
	}

}
