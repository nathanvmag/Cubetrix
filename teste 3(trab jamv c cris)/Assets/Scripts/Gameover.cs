using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Gameover : MonoBehaviour {
    public Text score, highscore;
    bool restartgame, gomenu;
    public GameObject hsnew;
    int antigohighscore; 
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
        if (gomenu)
        {
            if (mudardecena.fadeeout()) Application.LoadLevel("Menu");
        }
        if (restartgame)
        {
            if (mudardecena.fadeeout()) Application.LoadLevel("GrandeGame");
        }
	
	}
    public void btreload()
    {
        restartgame = true;
        if (Random.Range(0, 10) == 10)
        {
            StartCoroutine(ShowAdWhenReady());
        }
    }
    public void voltaMenu()
    {
        gomenu = true;
        if (Random.Range(0, 10) == 10)
        {
            StartCoroutine(ShowAdWhenReady());
        }
    }
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        Advertisement.Show();
    }
}
