﻿using UnityEngine;
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
	public GameObject PauseMenu;
    public GameObject QuitMenu;
    public GameObject MainMenu;
    public GameObject Tutorial;
    public GameObject Tutorial2;
    public static bool gamepause;

	public static bool dead = false;
	public static bool invincible = true;

	public GameObject bcell;

	public GameObject[] pews = new GameObject[3];
	public int currIndex;
	public Sprite[] weapons = new Sprite[3];
	public Texture[] canister = new Texture[3];

	public static ArrayList delayPos = new ArrayList();
	public float speed = 5;
	Vector3 acc;

	public GameObject prefab;

	float dist;
	float leftLimitation;
	float rightLimitation;
	float upLimitation;
	float downLimitation;
	float health = 10;
	float scaleFactor;

	void Start(){
		GameObject lb = GameObject.Find("LifeBar");
		scaleFactor = lb.transform.localScale.x/health;

		if(PurchaseHolder.HasBCell){
			Instantiate(bcell,new Vector3(transform.position.x+2f, transform.position.y, 0),Quaternion.identity);
		}
		invincible = true;
		dead = false;
		gamepause = true;
		acc = new Vector3();

		dist = (transform.position.z - Camera.main.transform.position.z);
		leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0.03f,0,dist)).x;
		rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(.97f,0,dist)).x;
		upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,.97f,dist)).y;
		downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,.03f,dist)).y;

		Invoke("vulnerable", 4f);
	}

	void vulnerable(){
		invincible = false;
	}

	void CycleWeapon(){
		if(currIndex<2){
			currIndex++;
		}else{
			currIndex = 0;
		}
		GetComponent<Gun>().projectile = pews[currIndex];
		GameObject.Find("PlayerWeapon").GetComponent<SpriteRenderer>().sprite = weapons[currIndex];
		GameObject.Find("WeaponIcon").GetComponent<GUITexture>().texture = canister[currIndex];
		GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayWeaponChange();
	}

	void SwapColor(){
		if(gameObject.GetComponent<SpriteRenderer>().color == Color.gray){
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}else{
			gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
		}
	}

	void Update () {
		if(invincible){
			SwapColor();
		}else{
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}

		if(PurchaseHolder.AtriplaTime > 0){
			GetComponent<SpriteRenderer>().color = Color.yellow;
		}else{
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		if (Application.loadedLevelName != "Menu") {
            
			if (!dead) {
				acc = new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0);
				transform.position += acc;
				Vector3 pos = transform.position;

				pos.x = Mathf.Clamp (pos.x, leftLimitation, rightLimitation);
				pos.y = Mathf.Clamp (pos.y, downLimitation, upLimitation);

				transform.position = pos;

				Vector3 newPos = new Vector3 (transform.position.x + 1.5f, transform.position.y, 0);
				delayPos.Add (new PosOb (newPos, Time.time));
				if(Input.GetKeyDown(KeyCode.Escape)){
                    if (Tutorial.activeSelf == false && Tutorial2.activeSelf == false)
                    {
                        if (Time.timeScale != 0.0f)
                        {
                            PauseMenu.SetActive(true);
                            Time.timeScale = 0.0f;
                        }
                        else if(Time.timeScale == 0.0f && QuitMenu.activeSelf == false && MainMenu.activeSelf == false)
                        {
                            Time.timeScale = 1.0f;
                            PauseMenu.SetActive(false);
                        }
                    }
				}
			}
		}
		if(Input.GetMouseButtonDown(1)){
			if(!dead && PurchaseHolder.vitamin){
				CycleWeapon();
			}else{
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayNeedMoney();
			}
		}

		GameObject lb = GameObject.Find("LifeBar");
		lb.transform.localScale = new Vector3(scaleFactor*health, lb.transform.localScale.y, lb.transform.localScale.z);



	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Good" && col.gameObject.tag != "Antibody" && col.gameObject.tag != "Pew" && col.gameObject.tag != "Border" && !invincible){
			health--;
			if(health<1){
				dead = true;
				GameObject smoke = (GameObject)Instantiate(smokePrefab, transform.position, transform.rotation);
				smoke.transform.parent = transform;
				GetComponent<SpriteRenderer>().enabled = false;
				GetComponent<CircleCollider2D>().enabled = false;
				GameObject.Find("PlayerWeapon").GetComponent<Rigidbody2D>().gravityScale = 1;
				Invoke("Kill", 2f);
				GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayPlayerDeath();
				GameObject.Find("AudioManager").GetComponent<AudioManager>().invokeMenu();
			}
		}
	}

	void Kill(){  
		LivesManager.lives--;
		PurchaseHolder.HasBCell = false;
		if(LivesManager.lives < 0){
			dead = true;
			GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMainLoop();
			GameObject.Find("AudioManager").GetComponent<AudioManager>().StopBossLoop();
			GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayDeathMusic();
			Application.LoadLevel("death");
		}else{
            dead = true;
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
	
	void OnTriggerEnter2D(Collision2D col){
		if(col.gameObject.tag == "Border"){
			Debug.Log("HitWall");
		}
	}
}
