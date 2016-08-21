using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour {
    
	// Use this for initialization
	void Awake () {
		if (Application.platform == RuntimePlatform.Android)  Advertisement.Initialize("1082397");
		else if (Application.platform == RuntimePlatform.IPhonePlayer) Advertisement.Initialize("1082398");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        Advertisement.Show();
    }
}
