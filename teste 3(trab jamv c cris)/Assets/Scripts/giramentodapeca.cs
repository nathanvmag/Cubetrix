using UnityEngine;
using System.Collections;

public class giramentodapeca : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
			transform.Rotate(Vector3.up);
			transform.Rotate(Vector3.right);

	}
}