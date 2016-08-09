using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveHS : MonoBehaviour {
    private const string key = "fc1ab1a6bc1505b184f09e1fbe499a61edec16818ea13d07cdb85482b19d6342";
    private const string secretkey = "ad67abfb73dcd7ec24e353d705fb0a1212900958f2b79682ffec2d7b68bc2384";
    private GameService gameserv;
    private ScoreBoardService scoreboardserv;
    string gamename = "Cubetrixx";
    bool salvar = false;
    double highscore;
    string name;
    int maxplayers = 20;
    public Canvas[] canvas;
    public Camera cam;
    public Sprite[] bla; 
    public static List<Text> ranks = new List<Text>();
    public static List<Text> names= new List<Text>();
    public static List<Text> score = new List<Text>();
    public List<GameObject> texts = new List<GameObject>();
    bool salvou;
    static public Image render;
   static public Sprite[] error = new Sprite[2]; 
   Dictionary<String, String> otherMetaHeaders = new Dictionary<String, String>();
   public static bool salvouhs; 
	public static GameObject reload;
	public GameObject relo;
    
   // otherMetaHeaders.Add("orderByAscending", "score");
    
	// Use this for initialization
    void Awake ()

    {
        otherMetaHeaders.Add("orderByDescending", "score");
       
    }
	void Start () {
		ranks = new List<Text>();
		names= new List<Text>();
		score = new List<Text>();
		texts = new List<GameObject>();
		reload = relo; 
        App42API.Initialize(key,secretkey);
        gameserv = App42API.BuildGameService();
        scoreboardserv = App42API.BuildScoreBoardService();
        App42Log.SetDebug(true);
        gameserv.GetGameByName(gamename, new gameCallback());
		if (PlayerPrefs.HasKey("highscore"))
        highscore = PlayerPrefs.GetInt("highscore");
       
		if (PlayerPrefs.HasKey("nome")	)
			{
			name = PlayerPrefs.GetString("nome"); 
            scoreboardserv.SaveUserScore(gamename, name, highscore,new savehigh()); 
			Debug.Log ("salva ai com nome " + name + " e com score " + highscore);
			}
       
        render = GameObject.Find("hsImg").GetComponent<Image>();
        error[0] = bla[0];
        error[1] = bla[1];

        for (int i = 0; i < 20; i++)
        {
            texts.Add(GameObject.Find("Text" + (i + 1)));

        }
        for (int i = 0; i < texts.Count; i++)
        {
            ranks.Add(texts[i].transform.FindChild("ran").GetComponent<Text>());
            names.Add(texts[i].transform.FindChild("nome").GetComponent<Text>());
            score.Add(texts[i].transform.FindChild("pt").GetComponent<Text>());
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (salvouhs)
        {
            scoreboardserv.SetOtherMetaHeaders(otherMetaHeaders);
            scoreboardserv.GetTopNRankers(gamename, maxplayers, new toprank());
            salvouhs = false; 
			Debug.Log ("vai pegar HS");
        }
	}
    public void clicou()
    {
        
        cam.depth = -1;
        canvas[0].gameObject.SetActive(true);
		mudardecena.soundClick ();
    }
	public void reloadbt()
	{
		scoreboardserv.SaveUserScore(gamename, name, highscore,new savehigh()); 
		reload.SetActive (false);
		render.sprite = error [0];
		mudardecena.soundClick ();
	}

}
public class gameCallback : App42CallBack
{
	

		public void OnSuccess(object response)
    {
        Game game = (Game)response;
        App42Log.Console("gameName is " + game.GetName());
        App42Log.Console("gameDescription is " + game.GetDescription());
    }

    public void OnException(Exception e)
    {
        App42Log.Console("Exception : " + e);
		Debug.Log ("semnome");
		SaveHS.render.sprite = SaveHS.error[1]; 
		SaveHS.reload.SetActive (true);
    }  
}
public class savehigh: App42CallBack
{
    public void OnSuccess(object response)
    {
        Game game = (Game)response;
        App42Log.Console("gameName is " + game.GetName());

        for (int i = 0; i < game.GetScoreList().Count; i++)
        {
			//App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
           // App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());
            SaveHS.salvouhs = true; 
			Debug.Log ("salvo");
        }
    }

    public void OnException(Exception e)
    {
        App42Log.Console("Exception : " + e);
        SaveHS.render.sprite = SaveHS.error[1]; 
		Debug.Log ("nemsalvo");
		SaveHS.reload.SetActive (true);
    }
}
public class toprank : App42CallBack
{
	
    public void OnSuccess(object response)
    {
		
        Game game = (Game)response;
        App42Log.Console("gameName is " + game.GetName());
        for (int i = 0; i < game.GetScoreList().Count; i++)
        {
            SaveHS.render.sprite = SaveHS.error[0]; 
            SaveHS.ranks[ i].text = (i + 1).ToString();
			if (i>2)SaveHS.names[i].text = game.GetScoreList()[i].GetUserName().ToLower();
			else SaveHS.names[i].text = game.GetScoreList()[i].GetUserName().ToUpper();
            SaveHS.score[i].text = game.GetScoreList()[i].GetValue().ToString();
			Debug.Log ("highscore foi salvo");
           // App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
			//  App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());

           // Debug.Log("A posiçao é "+(i+1)+ " is " + game.GetScoreList()[i].GetUserName() + " Score is" + game.GetScoreList()[i].GetValue());
        }
    }

    public void OnException(Exception e)
    {
        App42Log.Console("Exception : " + e);
         SaveHS.render.sprite = SaveHS.error[1]; 

		SaveHS.reload.SetActive (true);
    }
}