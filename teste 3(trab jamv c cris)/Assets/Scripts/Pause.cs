using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI; 

public class Pause : MonoBehaviour {
    public static bool pause;
    public GameObject pausebt;
    public GameObject[] pauseUi;
    public static bool restargame, carregamenu;
    bool AdShow;
	public Camera cam ; 
   
	void Start () {
        
        Debug.Log("Antigohd " + PlayerPrefs.GetInt("antigohigh"));
        Debug.Log("high " + PlayerPrefs.GetInt("highscore"));
        pause = false;
        pausebt = GameObject.Find("pausebt");
        restargame = false;
        carregamenu = false; 
	}
	void Awake ()
    {
        Advertisement.Initialize("1082397");
    }
	// Update is called once per frame
    void Update()
    {

        if (mudardecena.sound) Camera.main.GetComponent<AudioListener>().enabled = true;
        else Camera.main.GetComponent<AudioListener>().enabled = false; 
        if (Input.GetKeyDown(KeyCode.Escape)) pause = !pause;
        if (!AdShow)
        {
            if (restargame)
            {
				cam.depth = -3;
                if (mudardecena.fadeeout())
                {
                    PlayerPrefs.DeleteKey("highscore");
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("antigohigh"));
                    Application.LoadLevel("GrandeGame");
                }
            }
            if (carregamenu)
            {
				cam.depth = -3;
                if (mudardecena.fadeeout())
                {
                    PlayerPrefs.DeleteKey("highscore");
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("antigohigh"));
                    Application.LoadLevel("Menu");
                }
            }
        }
        if (!pause)
        {
           pausebt.SetActive(true);
            //click();
            for (int i = 0; i < pauseUi.Length; i++)
            {
				pauseUi[i].GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(	pauseUi[i].GetComponent<RectTransform>().localPosition,GameObject.Find("localPS").GetComponent<RectTransform>().localPosition+new Vector3(0,700,0),10);
            }
            if (Plano.player!=null) Plano.player.gameObject.SetActive(true);
        }
        else
        {
            pausebt.SetActive(false);
        for(int i = 0; i<pauseUi.Length;i++)
        {
			// pauseUi[i].SetActive(true);
				pauseUi[i].GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(	pauseUi[i].GetComponent<RectTransform>().localPosition,GameObject.Find("localPS").GetComponent<RectTransform>().localPosition,10);
			       }
        }
    }
    private void click()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "pause")
                {
                    
                    pause = true;
                    pausebt.SetActive(false);
                }

            }
        }

    }
          public void btplay()
    {
        pause = false; 
		mudardecena.soundClick ();
    }
         public void btreload()
          {
        PlayerPrefs.DeleteKey("highscore");
  
        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("antigohigh"));
        Debug.Log("hey");
             int randon = Random.Range(0,5);
             Debug.Log(randon);
             if (randon==0)
             {
                 StartCoroutine(ShowAdWhenReady());
             }
              restargame = true;
		mudardecena.soundClick ();
          }
    public void voltaMenu()
         {
        Debug.Log("hey");
       
        mudardecena.soundClick ();
             carregamenu = true;
             int randon = Random.Range(0, 5);
             Debug.Log(randon);
             if (randon == 1)
             {
                 StartCoroutine(ShowAdWhenReady());
             }
         }
    public void clicksom()
    {
        int qualimg;
        mudardecena.sound = !mudardecena.sound;
        if (mudardecena.sound) qualimg = 0;
        else qualimg = 1;
       
    }
    public void btPause()
         {
			mudardecena.soundClick ();
             pause = true; 
         }
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show("", options);
        AdShow = true; 
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                AdShow = false;
                Debug.Log("foi");
                break;
            case ShowResult.Skipped:
                Debug.Log("eita");
                AdShow = false;
                break;
            case ShowResult.Failed:
                Debug.Log("ah");
                AdShow = false;
                break;
        }
    }

         }

