using UnityEngine;
using System.Collections;

public class mudardecena : MonoBehaviour {
    public Camera cam; 
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
    private void click()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var ray = cam.ScreenPointToRay(Input.GetTouch(0).position);

            // RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.x, ray.y), Vector2.zero, Mathf.Infinity);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "creditos")
                {
                    Application.LoadLevel("creditos");
                    Debug.Log("acerto");
                }
                if (hit.transform.gameObject.tag == "menu")
                {
                    Application.LoadLevel("menu");
                    Debug.Log("volto");
                }
                if (hit.transform.gameObject.tag == "play")
                {
                    Application.LoadLevel("GrandeGame");
                    Debug.Log("volto");
                }
            
            }


        }

    }
}
