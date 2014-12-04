using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Balance : MonoBehaviour {
	GUIText texts;
	private int total;
	private int wcount = 0;
	private int hcount = 0;
	private int price;
	public static bool hasVitamin = false;
	public static bool hasTest = false;
	public static bool hasBCell = false;
	public static int hasExtraLife = 0;
	public Sprite box;
	// Use this for initialization
	void Start () {
		total = 500;
		texts = gameObject.GetComponent<GUIText>();
		texts.color = Color.white;
		//Font Agency = (Font)Resources.Load("Assets/Sprites/Font/4822485673.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);
		texts.text = total + " P";
		//texts.font = Agency;
		texts.fontStyle = FontStyle.Bold;
		texts.fontSize = 36;
	
	}

	void BuyTherapy(){
		if (total>150){
			price = 150;
			if(!hasVitamin){
				if (total >= price) {
					total -= price;
					hasVitamin = true;
				} else {
					//StartCoroutine(FlashWarning());
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
			PurchaseHolder.NewLives++;
			//hasExtraLife++;
		}else{
		StartCoroutine(NotEnough());
		wcount = 0;
		}
    }
	
    IEnumerator FlashWarning(){
		while (wcount < 3){
			GameObject.Find ("Warning").GetComponent<GUIText> ().enabled = true;
			GameObject.Find ("Warning").GetComponent<GUIText> ().color = Color.red;
			yield return new WaitForSeconds (.5f);
			GameObject.Find ("Warning").GetComponent<GUIText> ().color = Color.white;
			yield return new WaitForSeconds (.5f);
			wcount++;
		}
		GameObject.Find ("Warning").GetComponent<GUIText> ().enabled = false;
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
            GameObject.Find("ContineButton").GetComponent<Image>().sprite = null;
			yield return new WaitForSeconds (.5f);
			hcount++;
		}
	}

	void Update(){
        if (total < 150)
        {

        }
        texts.text = total+" P";
	}
}


