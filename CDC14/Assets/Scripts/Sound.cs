using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        if (Player.dead == true)
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMainLoop();
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayDeathMusic();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopDeathMusic();
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMenuLoop();
        }
    }
	
	
}
