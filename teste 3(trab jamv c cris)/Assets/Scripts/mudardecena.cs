using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mudardecena : MonoBehaviour {
    GameObject fadein;
    float alpha;
    bool carregar, carrecredito, carregamenu,carregajogo;
    public Sprite[] soundd; 
    public static bool sound = true ; 
	public GameObject botoes,config; 
	public Text low,med,high,best; 
	Resolution r;

	// Use this for initialization
	void Start () {
		r = Screen.currentResolution; 
        fadein = GameObject.Find("fade");
        carregar = false;
        carrecredito = false;
        carregamenu = false;
        carregajogo = false;
      
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (carrecredito)
        {            
            if (fadeeout()) Application.LoadLevel(4);
           
        }
        if (carregamenu)
        {
            
            if (fadeeout()) Application.LoadLevel("menu");
        }
        if (carregajogo)
        {
            
            {
                if (fadeeout())Application.LoadLevel("load");
            }
        }
	}	
	
    public void clickcreditos()
    {
        carrecredito = true;   
		//	Debug.Log ("acerto");
    }
    public void clickjogar()
    {
        carregajogo = true; 
          //  Debug.Log("volto");
        
    }
    public void clickvoltar()
    {
        carregamenu = true;
        GameObject.Find("Button").SetActive(false);
	  //  Debug.Log ("volto");
    }
    public void clicksom()
    {
        int qualimg; 
        sound = !sound;
        if (sound) qualimg = 0;
        else qualimg = 1;
        GameObject.Find("sound").GetComponent<Image>().sprite = soundd[qualimg];      
    }
    public static bool fadeeout()
    {
        float alpha;
       
        GameObject fadein = GameObject.Find("fade");
        if (fadein == null) Debug.Log("opa n tem fade ");
     //   Debug.Log("veio");
        alpha = Time.deltaTime / 1.5f;
       if (fadein.GetComponent<SpriteRenderer>().color.a < 1)
        {
            fadein.GetComponent<SpriteRenderer>().color = new Color(fadein.GetComponent<SpriteRenderer>().color.r, fadein.GetComponent<SpriteRenderer>().color.b, fadein.GetComponent<SpriteRenderer>().color.g, fadein.GetComponent<SpriteRenderer>().color.a + alpha);
            return false; 
        }
        return true; 
    }
	public void clickconfig(int i) 
	{
		if (i == 0) {
			config.SetActive (true); 
			botoes.SetActive (false);
		} else {
			config.SetActive(false); 
			botoes.SetActive(true);
		}
	}
	public void qualitySettings(int i)
	{
		switch (i) {
		case 0:
			QualitySettings.SetQualityLevel(i);
			low.color = Color.white;
			med.color= Color.black; 
			best.color= Color.black; 
			high.color= Color.black; 
			Screen.SetResolution (800, 480, true);
			break;
		case 1:
			QualitySettings.SetQualityLevel(i+1);
			low.color = Color.black;
			med.color= Color.white; 
			best.color= Color.black; 
			high.color= Color.black; 
			Screen.SetResolution (800, 480, true);
			break;
		case 2:
			QualitySettings.SetQualityLevel(i+1);
			low.color = Color.black;
			med.color= Color.black; 
			best.color= Color.black; 
			high.color= Color.white; 
		//	Screen.SetResolution (r.width, r.height, true);

			break;
		case 3:
			QualitySettings.SetQualityLevel (i + 2);
			low.color = Color.black;
			med.color = Color.black; 
			best.color = Color.white; 
			high.color = Color.black; 
			//Screen.SetResolution (r.width, r.height, true);
			break;
		}

        
	}

    }

