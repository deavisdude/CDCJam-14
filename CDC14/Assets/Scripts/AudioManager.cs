using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class AudioManager : MonoBehaviour {
	
	public AudioClip MainLoop;
	public AudioSource MainLoopSrc;
	
	public AudioClip EnemyHit;
	public AudioSource EnemyHitSrc;
	
	public AudioClip BossRumble;
	public AudioSource BossRumbleSrc;
	
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

	public AudioClip MenuLoop;
	public AudioSource MenuLoopSrc;

	public AudioClip BossLoop;
	public AudioSource BossLoopSrc;

    public AudioClip DeathMusic;
    public AudioSource DeathMusicSrc;

	public AudioClip NeedMoney;
	public AudioSource NeedMoneySrc;

	public AudioClip HitWeakness;
	public AudioSource HitWeaknessSrc;


	AudioSource current;
	
	void Start () {

		GameObject audioManager = GameObject.Find("AudioManager");
		if(audioManager != null && audioManager != gameObject)
		{
			Destroy(gameObject);
		}

		GameObject.DontDestroyOnLoad (gameObject);
		
		MainLoopSrc = gameObject.AddComponent<AudioSource>();
		MainLoopSrc.clip = MainLoop;
		MainLoopSrc.loop = true;
		MainLoopSrc.volume = 1f;
		
		EnemyHitSrc = gameObject.AddComponent<AudioSource>();
		EnemyHitSrc.clip = EnemyHit;
		EnemyHitSrc.loop = false;

		PewPewSrc = gameObject.AddComponent<AudioSource>();
		PewPewSrc.clip = PewPew;
		PewPewSrc.volume = .4f;
		PewPewSrc.loop = false;

		PlayerDeathSrc = gameObject.AddComponent<AudioSource>();
		PlayerDeathSrc.clip = PlayerDeath;
		PlayerDeathSrc.loop = false;

		GameStartSrc = gameObject.AddComponent<AudioSource>();
		GameStartSrc.clip = GameStart;
		GameStartSrc.loop = false;

		ToggleSrc = gameObject.AddComponent<AudioSource>();
		ToggleSrc.clip=Toggle;
		ToggleSrc.loop = false;

		ItemPurchaseSrc = gameObject.AddComponent<AudioSource>();
		ItemPurchaseSrc.clip=ItemPurchase;
		ItemPurchaseSrc.loop = false;

		BossRumbleSrc = gameObject.AddComponent<AudioSource>();
		BossRumbleSrc.clip=BossRumble;
		BossRumbleSrc.loop = false;

		NeedMoneySrc = gameObject.AddComponent<AudioSource>();
		NeedMoneySrc.clip=NeedMoney;
		NeedMoneySrc.loop = false;

		PowerUpSrc = gameObject.AddComponent<AudioSource>();
		PowerUpSrc.clip = PowerUp;
		PowerUpSrc.loop = false;

		HitWeaknessSrc = gameObject.AddComponent<AudioSource>();
		HitWeaknessSrc.clip = HitWeakness;
		HitWeaknessSrc.loop = false;

		MenuLoopSrc = gameObject.AddComponent<AudioSource>();
		MenuLoopSrc.clip=MenuLoop;
		MenuLoopSrc.loop = true;
		MenuLoopSrc.volume = 0f;

		WeaponChangeSrc = gameObject.AddComponent<AudioSource>();
		WeaponChangeSrc.clip = WeaponChange;
		WeaponChangeSrc.loop = false;

		BossLoopSrc = gameObject.AddComponent<AudioSource>();
		BossLoopSrc.clip=BossLoop;
		BossLoopSrc.loop = true;
		BossLoopSrc.volume = 0f;

        DeathMusicSrc = gameObject.AddComponent<AudioSource>();
        DeathMusicSrc.clip = DeathMusic;
        DeathMusicSrc.loop = false;
        DeathMusicSrc.volume = 0f;

		//PlayGameStart();
		PlayMenuLoop();
		//Application.LoadLevel("lvl1");
	}

	public AudioSource CurrentSrc(){
		return current;
	}

	public void PlayPowerUp(){
		PowerUpSrc.Play();
	}

	public void PlayHitWeakness(){
		HitWeaknessSrc.Play();
	}

	public void PlayNeedMoney(){
		NeedMoneySrc.Play();
	}


	public void PlayBossLoop(){
		//HOTween.To(BossLoopSrc, 1,"volume", 1);
		BossLoopSrc.Play();
		current = BossLoopSrc;
	}

	public void StopBossLoop(){
		//HOTween.To(BossLoopSrc, 1,"volume", 0);
		BossLoopSrc.Stop();
	}
	
	public void PlayEnemyHit(){
		EnemyHitSrc.Play();
	}

	public void PlayWeaponChange(){
		WeaponChangeSrc.Play();
	}

	public void PlayMenuLoop(){
		//HOTween.To(MenuLoopSrc, 1,"volume", 1);
		MenuLoopSrc.Play();
		current = MenuLoopSrc;
	}

	public void PlayBossRumble(){
		BossRumbleSrc.Play();
	}

	public void PlayItemPurchase(){
		ItemPurchaseSrc.Play();
	}

	public void PlayToggle(){
		ToggleSrc.Play();
	}

	public void PlayGameStart(){
		GameStartSrc.Play();
	}

	public void PlayPlayerDeath(){
		PlayerDeathSrc.Play();
	}

	public void PlayPewPew(){
		PewPewSrc.Play ();
	}
	
	public void PlayMainLoop(){
		//HOTween.To(MainLoopSrc, 1,"volume", 1);
		MainLoopSrc.Play();
		current = MainLoopSrc;
	}

	public void StopMainLoop(){
		//HOTween.To(MainLoopSrc, 1,"volume", 0);
		MainLoopSrc.Pause();
	}

	public void StopMenuLoop(){
		//HOTween.To(MenuLoopSrc, 1,"volume", 0);
		MenuLoopSrc.Stop();
	}

    public void PlayDeathMusic()
    {
        //HOTween.To(BossLoopSrc, 1,"volume", 1);
        DeathMusicSrc.Play();
    }

    public void StopDeathMusic()
    {
        //HOTween.To(BossLoopSrc, 1,"volume", 0);
        DeathMusicSrc.Stop();
    }
}