using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class Pause : MonoBehaviour {
    public static bool pause;
    public GameObject pausebt;
   public GameObject[] pauseUi;
   bool restargame, carregamenu;
   bool AdShow; 
	void Start () {
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
        
        if (Input.GetKeyDown(KeyCode.Escape)) pause = !pause;
        if (!AdShow)
        {
            if (restargame)
            {
                if (mudardecena.fadeeout())
                {

                    Application.LoadLevel("GrandeGame");
                }
            }
            if (carregamenu)
            {
                if (mudardecena.fadeeout())
                {

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
                pauseUi[i].SetActive(false);
            }
            if (Plano.player!=null) Plano.player.gameObject.SetActive(true);
        }
        else
        {
            pausebt.SetActive(false);
        for(int i = 0; i<pauseUi.Length;i++)
        {
            pauseUi[i].SetActive(true);
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
    }
         public void btreload()
          {
             int randon = Random.Range(0,5);
             Debug.Log(randon);
             if (randon==0)
             {
                 StartCoroutine(ShowAdWhenReady());
             }
              restargame = true;
              
          }
    public void voltaMenu()
         {
             carregamenu = true;
             int randon = Random.Range(0, 5);
             Debug.Log(randon);
             if (randon == 1)
             {
                 StartCoroutine(ShowAdWhenReady());
             }
         }
    public void btPause()
         {
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

