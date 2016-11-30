using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Screen.currentResolution.width > 800 && Screen.currentResolution.height > 480&&( Application.platform.Equals(RuntimePlatform.Android) || Application.platform.Equals(RuntimePlatform.IPhonePlayer))) {
			Screen.SetResolution (800, 480, true);
			Handheld.PlayFullScreenMovie ("intro.mp4", Color.white, FullScreenMovieControlMode.CancelOnInput,FullScreenMovieScalingMode.Fill);
		}	


	}
	
	// Update is called once per frame
	void Update () {
		if (mudardecena.fadeeout()) {
			Application.LoadLevel ("Menu");
		}
	}

}
