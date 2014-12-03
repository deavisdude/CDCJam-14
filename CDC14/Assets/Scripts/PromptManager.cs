using UnityEngine;
using System.Collections;

public class PromptManager : MonoBehaviour {

    public GameObject Tutorial;
    public GameObject Tutorial2;
    public GameObject player;
	// Use this for initialization
	void Start () 
    {
        if (Application.loadedLevelName == "noBoss") { 
            Tutorial.SetActive(true);
            Time.timeScale = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {

    }
    void CloseTutorial()
    {
        Time.timeScale = 1.0f;
    }
    void ToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
    void ToQuit()
    {
        Application.Quit();
    }
    void Beep()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
    }
    bool CanPause()
    {
        if (Tutorial.activeSelf == false && Tutorial2.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

