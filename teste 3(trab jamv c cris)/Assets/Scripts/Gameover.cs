using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Gameover : MonoBehaviour {
    public Text score, highscore;
    bool restartgame, gomenu;
  
    int antigohighscore;
    bool AdShow;
    public Camera cam;
	bool newHs ;
	public GameObject[] locais; 
    public Canvas cav; 
	// Use this for initialization
    void Awake()
    {
		if (Application.platform == RuntimePlatform.Android)  Advertisement.Initialize("1082397");
		else if (Application.platform == RuntimePlatform.IPhonePlayer) Advertisement.Initialize("1082398");
       
      
    }
	void Start () {

		newHs = false; 
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        restartgame = false ;
        gomenu = false;
       /* if (mudardecena.sound) Camera.main.GetComponent<AudioListener>().enabled = false;
        else Camera.main.GetComponent<AudioListener>().enabled = false;*/
        antigohighscore=  antigohighscore ==null ? 0:  PlayerPrefs.GetInt("antigohigh");
        if (antigohighscore < PlayerPrefs.GetInt("highscore"))
        {
            antigohighscore = PlayerPrefs.GetInt("highscore");
			Debug.Log ("é hs");

			newHs = true; 
        }
        PlayerPrefs.SetInt("antigohigh", antigohighscore);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("bts").GetComponent<RectTransform> ().localPosition = Vector3.MoveTowards (GameObject.Find ("bts").GetComponent<RectTransform> ().localPosition, locais [3].GetComponent<RectTransform> ().localPosition, 3);
		score.gameObject.GetComponent<RectTransform> ().localPosition = Vector3.MoveTowards (score.gameObject.GetComponent<RectTransform> ().localPosition, locais [0].GetComponent<RectTransform> ().localPosition,8);
		highscore.gameObject.GetComponent<RectTransform> ().localPosition = Vector3.MoveTowards (highscore.gameObject.GetComponent<RectTransform> ().localPosition, locais [1].GetComponent<RectTransform> ().localPosition,8);
		if (newHs) {
			highscore.color =  new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0,256) / 255f);
			GameObject.Find ("new").GetComponent<RectTransform> ().localPosition = Vector3.MoveTowards (GameObject.Find ("new").GetComponent<RectTransform> ().localPosition, locais [2].GetComponent<RectTransform> ().localPosition, 3);

		}

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
		mudardecena.soundClick ();
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
		mudardecena.soundClick ();
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
		mudardecena.soundClick ();


    }
}
