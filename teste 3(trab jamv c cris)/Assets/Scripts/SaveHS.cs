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
    string gamename = "Cubetrix";
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
    
    
   // otherMetaHeaders.Add("orderByAscending", "score");
    
	// Use this for initialization
    void Awake ()

    {
        otherMetaHeaders.Add("orderByDescending", "score");
        if (PlayerPrefs.GetInt("antigohigh")<PlayerPrefs.GetInt("highscore"))
        {
            salvar = true; 
        }
                }
	void Start () {
        App42API.Initialize(key,secretkey);
        gameserv = App42API.BuildGameService();
        scoreboardserv = App42API.BuildScoreBoardService();
        App42Log.SetDebug(true);
        gameserv.GetGameByName(gamename, new gameCallback());
        highscore = PlayerPrefs.GetInt("highscore");
        name = PlayerPrefs.GetString("nome"); 
        if (salvar)
        {
            scoreboardserv.SaveUserScore(gamename, name, highscore,new savehigh()); 
        }
        scoreboardserv.SetOtherMetaHeaders(otherMetaHeaders);
        scoreboardserv.GetTopNRankers(gamename, maxplayers, new toprank());
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
	
	}
    public void clicou()
    {
        
        cam.depth = -1;
        canvas[0].gameObject.SetActive(true);
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
            App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
            App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());           
        }
    }

    public void OnException(Exception e)
    {
        App42Log.Console("Exception : " + e);
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
            SaveHS.names[i].text = game.GetScoreList()[i].GetUserName().ToLower();
            SaveHS.score[i].text = game.GetScoreList()[i].GetValue().ToString();
            App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
            App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());

            Debug.Log("A posiçao é "+(i+1)+ " is " + game.GetScoreList()[i].GetUserName() + " Score is" + game.GetScoreList()[i].GetValue());
        }
    }

    public void OnException(Exception e)
    {
        App42Log.Console("Exception : " + e);
         SaveHS.render.sprite = SaveHS.error[1]; 
    }
}