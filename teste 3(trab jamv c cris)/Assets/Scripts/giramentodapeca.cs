using UnityEngine;
using System.Collections;
public class giramentodapeca : MonoBehaviour {
	float[] ale = new float[2]{ -0.8f, 0.8f };
	float valor;
	Vector3 [] posi;
	Vector3 [] rot  ; 
	int controle ; 
	// Use this for initialization
	void Start () {
		controle = 0; 
		Debug.Log ("tenho " + transform.childCount);
		valor = ale [Random.Range (0, ale.Length)];
		if (transform.childCount > 0) {
			foreach (Transform t in transform) {
				Debug.Log ("bla");
				Debug.Log (t.transform.position);
			}
		}
	}
		
	

	void FixedUpdate(){
		transform.Rotate (new Vector3 (0, 0, valor));
		//transform.Rotate(Vector3.left);
		
	}
	// Update is called once per frame
	void Update () {
		

	}


}