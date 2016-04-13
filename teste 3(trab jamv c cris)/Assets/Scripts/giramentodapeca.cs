using UnityEngine;
using System.Collections;

public class giramentodapeca : MonoBehaviour {
	private bool movimento = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (movimento) {
			transform.Rotate(Vector3.up);
			transform.Rotate(Vector3.right);
		}
	}
}