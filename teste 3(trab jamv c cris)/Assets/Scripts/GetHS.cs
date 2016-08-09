using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GetHS : MonoBehaviour {
	private const string key = "fc1ab1a6bc1505b184f09e1fbe499a61edec16818ea13d07cdb85482b19d6342";
	private const string secretkey = "ad67abfb73dcd7ec24e353d705fb0a1212900958f2b79682ffec2d7b68bc2384";
	private GameService gameserv;
	private ScoreBoardService scoreboardserv;
	string gamename = "Cubetrixx";
	int maxplayers = 20;
	Dictionary<String, String> otherMetaHeaders = new Dictionary<String, String>();
	public static List<Text> ranks = new List<Text>();
	public static List<Text> names= new List<Text>();
	public static List<Text> score = new List<Text>();
	public List<GameObject> texts = new List<GameObject>();
	public GameObject botoes; 
	static public Image render;
	public Sprite[] bla; 
	static public Sprite[] error = new Sprite[2]; 
	static public bool scorenew; 
	public GameObject newScore; 
	public static GameObject reload;
	public GameObject relo;
	bool goRank; 
	// Use this for initialization

	void Start () {
		goRank = false; 
		ranks = new List<Text>();
		names= new List<Text>();
		score = new List<Text>();
		texts = new List<GameObject>();
		reload = relo; 
		scorenew = false; 
		otherMetaHeaders.Add ("orderByDescending", "score");
		App42API.Initialize (key, secretkey);
		App42Log.SetDebug (true);
		gameserv = App42API.BuildGameService ();
		scoreboardserv = App42API.BuildScoreBoardService ();
		scoreboardserv.SetOtherMetaHeaders (otherMetaHeaders);
		scoreboardserv.GetTopNRankers (gamename, maxplayers, new toprankMenu ());
		if (texts.Count < 20) {
			for (int i = 0; i < 20; i++) {
				texts.Add (GameObject.Find ("Text" + (i + 1)));

			}
			for (int i = 0; i < texts.Count; i++) {
				ranks.Add (texts [i].transform.FindChild ("ran").GetComponent<Text> ());
				names.Add (texts [i].transform.FindChild ("nome").GetComponent<Text> ());
				score.Add (texts [i].transform.FindChild ("pt").GetComponent<Text> ());
			}
			//Debug.Log ("veioaquiDENOVO");
		}
		render = GameObject.Find ("hsImg").GetComponent<Image> ();
		error [0] = bla [0];
		error [1] = bla [1];
	}
	void FixedUpdate()
	{
		if (goRank) {
			GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition =Vector3.MoveTowards(GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition, new Vector3 (-2.9f, 0, 4.6f),23);
		}
		else GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition =Vector3.MoveTowards(GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition,new Vector3(-2.9f,800, 4.6f) ,10);
	}
	
	// Update is called once per frame
	void Update () {
		if (scorenew) {
			newScore.SetActive (true);
							
		}
		if (!scorenew) {
			newScore.SetActive (false);
		}

	}
	public void ClickRank()
	{
		goRank = true; 
		//GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition = new Vector3 (-2.9f, 0, 4.6f);
		botoes.SetActive (false);
		mudardecena.soundClick ();
	}
	public void clickX()
	{
		goRank = false; 
		//GameObject.Find ("menu").GetComponent<RectTransform> ().localPosition = new Vector3 (-2.9f,800, 4.6f);
		botoes.SetActive (true);
		mudardecena.soundClick ();
	}
	public void reloadbt()
	{
		scoreboardserv.GetTopNRankers (gamename, maxplayers, new toprankMenu ());
		reload.SetActive (false);
		render.sprite = error [0];
		mudardecena.soundClick ();
	}
}
	
public class toprankMenu : App42CallBack
{

	public void OnSuccess(object response)
	{
		Game game = (Game)response;
		App42Log.Console("gameName is " + game.GetName());
		GetHS.scorenew = true; 
		for (int i = 0; i < game.GetScoreList().Count; i++)
		{
			GetHS.render.sprite = GetHS.error[0]; 
			GetHS.ranks[ i].text = (i + 1).ToString() + ".";
			if (i>2)GetHS.names[i].text = game.GetScoreList()[i].GetUserName().ToLower();
			else GetHS.names[i].text = game.GetScoreList()[i].GetUserName().ToUpper();
			GetHS.score[i].text = game.GetScoreList()[i].GetValue().ToString();
			//Debug.Log ("foi pego");
			// App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());
			//  App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());

			// Debug.Log("A posiçao é "+(i+1)+ " is " + game.GetScoreList()[i].GetUserName() + " Score is" + game.GetScoreList()[i].GetValue());
		}
	}

	public void OnException(Exception e)
	{
		App42Log.Console("Exception : " + e);
		GetHS.render.sprite = GetHS.error[1]; 
		GetHS.reload.SetActive (true);
	}
}
