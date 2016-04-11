using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private int score;
    public Text scoretext;
    public Image[] imgvidas;
    private int vidas; 
    // Use this for initialization
    void Start()
    {
        setVidas = 3;
        setScore = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
        if (Plano.seguidas == 10)
        {
            setVidas++;
            Plano.seguidas = 0;
        }
    }
    public int setScore
	{
		get { return score;}
		set { score = value;}
	}
    public int setVidas
    {
        get { return vidas; }
        set { vidas = value;
        for (int i = 0; i < imgvidas.Length;i++)
        {
            imgvidas[i].gameObject.active = false;
        } 
            for (int i = 0; i < vidas; i++)
            {
                imgvidas[i].gameObject.active = true ;
            }
                
                       }
    }

}