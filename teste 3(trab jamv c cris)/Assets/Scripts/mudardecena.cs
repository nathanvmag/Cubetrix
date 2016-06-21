using UnityEngine;
using System.Collections;

public class mudardecena : MonoBehaviour {
    GameObject fadein;
    float alpha;
    bool carregar, carrecredito, carregamenu,carregajogo; 
	// Use this for initialization
	void Start () {
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
            if (fadeeout()) Application.LoadLevelAsync("creditos");
           
        }
        if (carregamenu)
        {
            
            if (fadeeout()) Application.LoadLevelAsync("menu");
        }
        if (carregajogo)
        {
            
            {
                if (fadeeout())Application.LoadLevelAsync("load");
            }
        }
	}	
	
    public void clickcreditos()
    {
        carrecredito = true;   
			Debug.Log ("acerto");
    }
    public void clickjogar()
    {
        carregajogo = true; 
            Debug.Log("volto");
        
    }
    public void clickvoltar()
    {
        carregamenu = true;
        GameObject.Find("Button").SetActive(false);
	    Debug.Log ("volto");
    }
    public static bool fadeeout()
    {
        float alpha;
       
        GameObject fadein = GameObject.Find("fade");
        if (fadein == null) Debug.Log("opa n tem fade ");
        Debug.Log("veio");
        alpha = Time.deltaTime / 1.5f;
       if (fadein.GetComponent<SpriteRenderer>().color.a < 1)
        {
            fadein.GetComponent<SpriteRenderer>().color = new Color(fadein.GetComponent<SpriteRenderer>().color.r, fadein.GetComponent<SpriteRenderer>().color.b, fadein.GetComponent<SpriteRenderer>().color.g, fadein.GetComponent<SpriteRenderer>().color.a + alpha);
            return false; 
        }
        return true; 
    }

        

    }

