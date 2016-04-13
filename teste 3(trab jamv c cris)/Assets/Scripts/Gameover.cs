using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Gameover : MonoBehaviour {
    public Text score, highscore; 
	// Use this for initialization
	void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btreload()
    {
        Application.LoadLevel("GrandeGame");
    }
    public void voltaMenu()
    {
        Application.LoadLevel("Menu");
    }
}
