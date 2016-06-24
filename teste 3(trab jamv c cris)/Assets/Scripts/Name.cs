using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
public class Name : MonoBehaviour {
    ServiceAPI serviceapi;
    public GameObject digname; 
	// Use this for initialization
	void Start () {
        serviceapi = new ServiceAPI("fc1ab1a6bc1505b184f09e1fbe499a61edec16818ea13d07cdb85482b19d6342", "ad67abfb73dcd7ec24e353d705fb0a1212900958f2b79682ffec2d7b68bc2384");
       
        if (PlayerPrefs.GetString("nome") == null||PlayerPrefs.GetString("nome") == "" )
        {
            digname.SetActive(true);
            
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btok()
    {
        PlayerPrefs.SetString("nome", GameObject.Find("playername").GetComponent<Text>().text);
        digname.SetActive(false);
    }
}
