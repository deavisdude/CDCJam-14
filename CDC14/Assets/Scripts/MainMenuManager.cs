using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
    public float EasyDifficulty = 1;
    public float MediumDifficulty = 2;
    public float HardDifficulty = 3;
  
    void Easy()
    {
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = "noBoss";
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
        LivesManager.lives = 3;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
		Invoke("mainplay", 1.7f);
        SpawnManager.enemyMultiplier = EasyDifficulty;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
    }
    void Medium()
    {
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = "noBoss";
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
        LivesManager.lives = 3;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
		Invoke("mainplay", 1.7f);
        SpawnManager.enemyMultiplier = MediumDifficulty;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
    }

    void Hard()
    {
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = "noBoss";
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
        LivesManager.lives = 3;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMenuLoop();
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
		Invoke("mainplay", 1.7f);
        SpawnManager.enemyMultiplier = HardDifficulty;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayGameStart();
    }

	void mainplay(){GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMainLoop();}

    void Credits()
    {
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().scene = "Credits";
        GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>().end = true;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
    }

    void QuitButton()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
        Application.Quit();
    }

    void Toggle()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayToggle();
    }
}
