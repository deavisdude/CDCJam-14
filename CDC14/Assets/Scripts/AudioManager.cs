using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public AudioClip MainLoop;
	public AudioSource MainLoopSrc;
	
	public AudioClip EnemyHit;
	public AudioSource EnemyHitSrc;
	
	public AudioClip BossRumble;
	public AudioSource BossrumbleSrc;
	
	public AudioClip LargeExplosion;
	public AudioSource LargeExplosionSrc;
	
	public AudioClip SmallExplosion;
	public AudioSource SmallExplosionSrc;
	
	public AudioClip GameStart;
	public AudioSource GameStartSrc;
	
	public AudioClip ItemPurchase;
	public AudioSource ItemPurchaseSrc;
	
	public AudioClip PewPew;
	public AudioSource PewPewSrc;
	
	public AudioClip PlayerDeath;
	public AudioSource PlayerDeathSrc;
	
	public AudioClip PowerUp;
	public AudioSource PowerUpSrc;
	
	public AudioClip Toggle;
	public AudioSource ToggleSrc;
	
	public AudioClip WeaponChange;
	public AudioSource WeaponChangeSrc;
	
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
		
		MainLoopSrc = gameObject.AddComponent<AudioSource>();
		MainLoopSrc.clip = MainLoop;
		MainLoopSrc.volume = .8f;
		MainLoopSrc.loop = true;
		
		EnemyHitSrc = gameObject.AddComponent<AudioSource>();
		EnemyHitSrc.clip = EnemyHit;
		EnemyHitSrc.loop = false;

		PewPewSrc = gameObject.AddComponent<AudioSource>();
		PewPewSrc.clip = PewPew;
		PewPewSrc.volume = .4f;
		PewPewSrc.loop = false;
		
		PlayMainLoop();
		Application.LoadLevel("lvl1");
	}
	
	public void PlayEnemyHit(){
		EnemyHitSrc.Play();
	}

	public void PlayPewPew(){
		PewPewSrc.Play ();
	}
	
	public void PlayMainLoop(){
		MainLoopSrc.Play();
	}
}