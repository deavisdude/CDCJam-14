using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Balance : MonoBehaviour {
	Text texts;
	private int total;
	private int wcount = 0;
	private int hcount = 0;
	private int price;
	public static bool hasVitamin = false;
	public static bool hasTest = false;
	public static bool hasBCell = false;
	public static int hasExtraLife = 0;
	public Sprite box;
    public Sprite box2;
    SpriteState spritestate;
    //public GameObject level;
	// Use this for initialization
	void Start () {
        PurchaseHolder.vitamin = true;
        total = 500;
		texts = gameObject.GetComponent<Text>();
		texts.color = Color.white;
		//Font Agency = (Font)Resources.Load("Assets/Sprites/Font/4822485673.ttf");
		
		texts.text = total + " P";
		//texts.font = Agency;
		texts.fontStyle = FontStyle.Normal;
        texts.fontSize = 20;
	}
    void Continue()
    {
        if (SpawnManager.prevLevel == "noBoss")
        {
            Application.LoadLevel("lvl1");
        }
        if (SpawnManager.prevLevel == "lvl1") 
        {
            Application.LoadLevel("noBoss2");
        }
        if (SpawnManager.prevLevel == "noBoss2") 
        {
            Application.LoadLevel("lvl2");
        }
        if (SpawnManager.prevLevel == "lvl2") 
        {
            Application.LoadLevel("lvl2");
        }
    }



	void BuyTherapy(){
		if (total>150){
			price = 150;
			if(!hasVitamin){
				if (total >= price) {
					total -= price;
					hasVitamin = true;
                    PurchaseHolder.vitamin = false;
				} else {
					StartCoroutine(FlashWarning());
					wcount = 0;
				}
			}else{
				StartCoroutine(FlashHave());
				hcount = 0;
			}
        }

    }
    void BuyNRTI()
    {
        price = 350;
        if (!hasBCell)
        {
            if (total >= price)
            {
                total -= price;
                hasBCell = true;
                PurchaseHolder.HasBCell = true;
            }
            else
            {
                StartCoroutine(FlashWarning());
                wcount = 0;
            }
        }
        else
        {
            StartCoroutine(FlashHave());
            hcount = 0;
        }
    }
    void BuyExtraLife()
    {
		price = 150;
		if (total >= price) {
			total -= price;
			//PurchaseHolder.NewLives++;
            LivesManager.lives++;
		}else{
		StartCoroutine(NotEnough());
		wcount = 0;
		}
    }
	
    IEnumerator FlashWarning(){
		while (wcount < 3){
            GameObject.Find("Warning").GetComponent<Text>().enabled = true;
            GameObject.Find("Warning").GetComponent<Text>().color = Color.red;
			yield return new WaitForSeconds (.5f);
            GameObject.Find("Warning").GetComponent<Text>().color = Color.white;
			yield return new WaitForSeconds (.5f);
			wcount++;
		}
        GameObject.Find("Warning").GetComponent<Text>().enabled = false;
	}	
	IEnumerator FlashHave(){
		while (hcount < 2){
            GameObject.Find("AlreadyHave").GetComponent<Text>().enabled = true;
            GameObject.Find("AlreadyHave").GetComponent<Text>().color = Color.red;
			yield return new WaitForSeconds (.5f);
            GameObject.Find("AlreadyHave").GetComponent<Text>().color = Color.white;
			yield return new WaitForSeconds (.5f);
			hcount++;
		}
        GameObject.Find("AlreadyHave").GetComponent<Text>().enabled = false;
	}	
	IEnumerator NotEnough(){
		while (hcount < 3){
            GameObject.Find("ContineButton").GetComponent<Image>().sprite = box;
			yield return new WaitForSeconds (.5f);
            GameObject.Find("ContineButton").GetComponent<Image>().sprite = box2;
			yield return new WaitForSeconds (.5f);
			hcount++;
		}
	}

	void Update(){
        texts.text = total+" P";
	}
}


