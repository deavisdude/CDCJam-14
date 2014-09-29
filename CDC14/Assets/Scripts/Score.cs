using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	TextMesh texts;

	// Use this for initialization
	void Start () {
		texts = gameObject.GetComponent<TextMesh>();
		Font Arial = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		float pixelRatio = (Camera.main.orthographicSize * 2.0f) / Camera.main.pixelHeight;
		texts.transform.localScale = new Vector3(pixelRatio * 10.0f, pixelRatio * 10.0f, pixelRatio * 0.1f);;
		texts.text = "Current balance";
		texts.font = Arial;
		texts.fontSize = 17;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
