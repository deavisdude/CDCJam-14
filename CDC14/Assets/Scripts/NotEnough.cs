using UnityEngine;
using System.Collections;

public class NotEnough : MonoBehaviour {
	TextMesh texts;
	// Use this for initialization
	void Start () {
		texts = gameObject.GetComponent<TextMesh>();
		Font Arial = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);
		
		texts.font = Arial;
		texts.fontSize = 17;
		texts.text = "Not Enough Funds";
	}
	
	// Update is called once per frame
	void tomuch(){
		Invoke ("on", 0.1f);
		}

	void on(){
		renderer.enabled = true;
		Invoke ("off", 3.0f);
	}
	void off(){
		renderer.enabled = false;
		}

	void Update ()
	{

	}
}

