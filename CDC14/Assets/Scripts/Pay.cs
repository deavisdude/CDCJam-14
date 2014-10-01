using UnityEngine;
using System.Collections;

public class Pay : MonoBehaviour {
	public GameObject controller1;
	public int cost1 = 981;
	public GameObject controller2;
	public int cost2 = 452;
	public GameObject controller3;
	public int cost3 = 543;
	public GameObject controller4;
	public int cost4 = 651;
	public GameObject controller5;
	public int cost5 = 651;
	public GameObject balance;
	TextMesh texts;
	MeshRenderer mesh;
		// Use this for initialization
	void Start () {
		 //mesh = renderer

		texts = gameObject.GetComponent<TextMesh>();
		Font Arial = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);

		texts.font = Arial;
		texts.fontSize = 17;
		texts.text = "Cost: "+0;
	}
	
	// Update is called once per frame
	void Update () {
		//button 1
		if (controller1.GetComponent<ShopMouse> ().highlighted) {
			renderer.enabled = true;
			//Emtricitabine
			texts.text="Cost: "+ cost1;
			if (controller1.GetComponent<ShopMouse> ().bought) {	
				balance.SendMessage ("BuyEfavir",cost1, SendMessageOptions.DontRequireReceiver);
			}
		}  else {
			texts.text="Cost: "+0;
		}
	//button2
		if (controller2.GetComponent<ShopMouse> ().highlighted) {
			renderer.enabled = true;
			//Emtricitabine
			texts.text="Cost: "+ cost2;

			if (controller2.GetComponent<ShopMouse> ().bought) {	
					balance.SendMessage ("BuyEmtric",cost2, SendMessageOptions.DontRequireReceiver);
			}
		} 
		//button2
		if (controller3.GetComponent<ShopMouse> ().highlighted) {
			//gameObject.GetComponent<MeshRenderer> ().enabled = true;			
			//Emtricitabine
			texts.text="Cost: "+ cost3;

			if (controller3.GetComponent<ShopMouse> ().bought) {	
				balance.SendMessage("BuyTenofiv",cost3,SendMessageOptions.DontRequireReceiver);
			}
		}
	//button2
		if (controller4.GetComponent<ShopMouse> ().highlighted) {
			//GetComponent<MeshRenderer> ().enabled = true;
			//Emtricitabine
			texts.text="Cost: "+ cost4;

			if (controller4.GetComponent<ShopMouse> ().bought) {	
				balance.SendMessage("BuyAtrip",cost4,SendMessageOptions.DontRequireReceiver);
			}
		}
		if (controller5.GetComponent<ShopMouse> ().highlighted) {
			//GetComponent<MeshRenderer> ().enabled = true;
			//Emtricitabine
			texts.text="Cost: "+ cost5;
			
			if (controller4.GetComponent<ShopMouse> ().bought) {	
				balance.SendMessage("BuyTest",cost5,SendMessageOptions.DontRequireReceiver);
			}
		}

	}
}



