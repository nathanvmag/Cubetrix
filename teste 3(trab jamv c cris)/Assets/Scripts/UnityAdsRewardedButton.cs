using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsRewardedButton : MonoBehaviour
{
    public string zoneId;
    public int rewardQty = 250;
    private Score score; 
    // zone id é a forma q é a propaganda !
    void Start()
    {
        score = Camera.main.GetComponent<Score>();
    }
    void OnGUI()

    {
        if (string.IsNullOrEmpty(zoneId)) zoneId = null;

        Rect buttonRect = new Rect(10, 10, 150, 50);
        string buttonText = Advertisement.IsReady(zoneId) ? "Show Ad" : "Waiting...";

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        if (GUI.Button(buttonRect, buttonText))
        {
            Advertisement.Show(zoneId, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                score.setVidas = 1;
                Score.showbutton = false; 
                Debug.Log("foi");
                break;
            case ShowResult.Skipped:
                Score.showbutton = false;
                score.setVidas--;
                Debug.Log("sk");
                break;
            case ShowResult.Failed:
                Score.showbutton = false;
                score.setVidas--;
                Debug.Log("fail2");
                break;
        }
    }
}
