using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour {
    
	// Use this for initialization
	void Awake () {
        Advertisement.Initialize("1082397");
        
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
