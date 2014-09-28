using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip MainLoop;
	public AudioSource MainLoopSrc;

	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);

		MainLoopSrc = gameObject.AddComponent<AudioSource>();
		MainLoopSrc.clip = MainLoop;
		MainLoopSrc.loop = true;

		PlayMainLoop();
		Application.LoadLevel("lvl1");
	}
	
	void PlayMainLoop(){
		MainLoopSrc.Play();
	}
}