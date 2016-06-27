using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Gameover : MonoBehaviour {
    public Text score, highscore;
    bool restartgame, gomenu;
    public GameObject hsnew;
    int antigohighscore;
    bool AdShow;
    public Camera cam;
    public Canvas cav; 
	// Use this for initialization
    void Awake()
    {
        Advertisement.Initialize("1082397");
       
      
    }
	void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        restartgame = false ;
        gomenu = false;
        Debug.Log(antigohighscore);
        antigohighscore=  antigohighscore ==null ? 0:  PlayerPrefs.GetInt("antigohigh");
        if (antigohighscore < PlayerPrefs.GetInt("highscore"))
        {
            antigohighscore = PlayerPrefs.GetInt("highscore");
           hsnew.SetActive(true);
        }
        PlayerPrefs.SetInt("antigohigh", antigohighscore);
	}
	
	// Update is called once per frame
	void Update () {
        if(!AdShow)
        {
        if (gomenu)
        {
            if (mudardecena.fadeeout()) Application.LoadLevel("Menu");
        }
        if (restartgame)
        {
            if (mudardecena.fadeeout()) Application.LoadLevel("load");
        }
        }
	
	}
    public void btreload()
    {
        restartgame = true;
        int rand = Random.Range(0, 6);
        Debug.Log(rand);
        if (rand == 3)
        {
            Debug.Log("propagana");
            StartCoroutine(ShowAdWhenReady());
        }
    }
    public void voltaMenu()
    {
        gomenu = true;
        int rand = Random.Range(0, 5);
        Debug.Log(rand);
        if (rand == 1)
        {
            StartCoroutine(ShowAdWhenReady());
        }
    }
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show("",options);
        AdShow = true  ; 
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:                               
                AdShow= false;
                Debug.Log("foi");
                break;
            case ShowResult.Skipped:
                Debug.Log("eita");
                AdShow= false;
                break;
            case ShowResult.Failed:
                Debug.Log("ah");
                AdShow= false;
                break;
        }
    }
    public void ranking()
    {
        cam.depth = 3;
        cav.gameObject.SetActive(false); 

    }
}
