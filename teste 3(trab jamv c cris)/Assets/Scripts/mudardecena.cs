using UnityEngine;
using System.Collections;

public class mudardecena : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown(){
		if (gameObject.tag == "creditos") {
			Application.LoadLevel("creditos");
			Debug.Log ("acerto");
		}
		if (gameObject.tag == "menu") {
			Application.LoadLevel("menu");
			Debug.Log ("volto");
		}
        if (gameObject.tag == "play")
        {
            Application.LoadLevel("GrandeGame");
            Debug.Log("volto");
        }
	}
}
