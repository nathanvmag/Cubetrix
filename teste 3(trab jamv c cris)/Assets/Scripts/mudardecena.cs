using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
public class mudardecena : MonoBehaviour {
    GameObject fadein;
    float alpha;
    bool carregar, carrecredito, carregamenu,carregajogo;
    public Sprite[] soundd; 
    public static bool sound = true ; 
	public GameObject botoes,config; 
	public Text low,med,high,best; 
	Resolution r;
	public static AudioSource audio; 
	public GameObject[] cenas; 
	public AudioClip clicktp ; 
	public static AudioClip click;
	// Use this for initialization
	void Start () {
		click = clicktp;

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
			if (fadeeout ()) {
				cenas [0].SetActive (false);
				cenas [1].SetActive (true);
				carrecredito = false; 
				GameObject.Find ("fade").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			}
				//Application.LoadLevel(4);
           
        }
        if (carregamenu)
        {
            
			if (fadeeout ()) {
				cenas [1].SetActive (false);
				cenas [0].SetActive (true);
				carregamenu = false; 
				GameObject.Find ("fade").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			}//Application.LoadLevel("menu");
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
		soundClick ();
		//	Debug.Log ("acerto");
    }
    public void clickjogar()
    {
        carregajogo = true; 
		soundClick ();
		//audio.PlayOneShot (click);
          //  Debug.Log("volto");
        
    }
    public void clickvoltar()
    {
        carregamenu = true;
		soundClick ();
		//audio.PlayOneShot (click);
		// GameObject.Find("Button").SetActive(false);
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
	/// <summary>
	/// Fadeeout precisa de um gameobject chamado fade
	/// </summary>
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
	public static void soundClick()
	{ 
		AudioSource audio = Object.FindObjectOfType <AudioSource>() as AudioSource;
		//Debug.Log (audio.gameObject.name);
		audio.PlayOneShot (Resources.Load ("Sounds/Click") as AudioClip );
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

