using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private int score;
    public Text scoretext;
    public Image[] imgvidas;
    private int vidas;
    private int highScore;
    public Image highscoreimg;
    public Image tutorialimg;
    public Image start; 
    float timer;
    public AudioClip explo;
    bool podexplo = true;
    public GameObject[] jogadores;
    public GameObject botaopropa;
    public Transform local;
    public static bool showbutton,mostro;
    float  t = 5;
    public static bool click;
    public Text time;
    public GameObject menupropa;
    bool gameoveer;
    public Font block;
    public Text pausetx; 
	public Camera cam; 
	public static bool firtSlideX,firtsSlideY,firtPress;
	public Sprite[] spritesTuto;
    // Use this for initialization
    void Start()    {   	
		Camera.main.backgroundColor = ConversorColor.HexToColor (Plano.cores[0]);
		firtSlideX = true;
		firtsSlideY = false;
		firtPress = false;       
        highScore = PlayerPrefs.GetInt("highscore") == null ? 0 : PlayerPrefs.GetInt("highscore");
        setVidas = 3;
        setScore = 0;
        Plano.player =  Instantiate(jogadores[Random.Range(0,jogadores.Length)], GameObject.Find("posiplayer").transform.position, Quaternion.identity)as GameObject;
        showbutton = false;
        mostro = false;
        t = 7;
        gameoveer = false;
        block = Resources.Load("Blox2") as Font;
        scoretext.font = block;
        pausetx.font = block;
    }

    // Update is called once per frame
    void Update()
    {if (gameoveer)
    {	
			cam.depth = -2;
        if (mudardecena.fadeeout())
        {
            Application.LoadLevel("derrota");
        }
    }

        if (showbutton)
        {
            Plano.player.SetActive(false);
            menupropa.SetActive(true);
            t -= Time.deltaTime;
            time.text = t.ToString().Substring(0, 1);
            Debug.Log("veio");
            if (!mostro)
            {
                botaopropa.SetActive(true);
                mostro = true;
            }
            if (t < 0 && !click)
            {
                t = 0; 
                showbutton = false;
                setVidas--;
                GameObject.FindGameObjectWithTag("botaoPropa").SetActive(false);

            }
        }
        else if (!Pause.pause)
        {
            menupropa.SetActive(false);
            if (Plano.player != null) Plano.player.SetActive(true);
        }


		if (firtSlideX && (Player.esq1 || Player.dir1)) {
			tutorialimg.sprite = spritesTuto [1];
			Debug.Log ("slidex");
			firtSlideX = false;
			firtsSlideY = true; 

		} else if (!firtSlideX && firtsSlideY &&( Player.baixo1 || Player.cima1) ){
			firtsSlideY = false; 
			tutorialimg.sprite = spritesTuto [2];
			firtPress = true; 
			Debug.Log ("slidey");
		}
		else if (!firtSlideX && !firtsSlideY &&firtPress &&touchV2.aperto) {
			firtsSlideY = false; 
			tutorialimg.gameObject.SetActive (false);
			firtPress = false; 
			Debug.Log ("press");

		}

			
            scoretext.text = score.ToString();
            if (Plano.seguidas == 10)
            {
                setVidas++;
                Plano.seguidas = 0;
            }
            if (score > highScore)
            {
                PlayerPrefs.SetInt("highscore", score);
                highscoreimg.gameObject.SetActive(true);
                scoretext.color = new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0,256) / 255f);
                
            }
            if (setVidas == 0)
            {



                PlayerPrefs.SetInt("score", score);
                timer += Time.deltaTime;

                if (timer > 2 && podexplo)
                {
                    GetComponent<AudioSource>().PlayOneShot(explo);
                    podexplo = false;
                }
                if (timer > 4)
                {
                    gameoveer = true; 
                }
            }

        
    }
    public void clicknoX()
    {
        showbutton = false;
        setVidas--;
        GameObject.FindGameObjectWithTag("botaoPropa").SetActive(false);
    }
    public void clicknoX2()
    {
        showbutton = false;
        setVidas--;
        Debug.Log("sk");
        Destroy(GameObject.FindGameObjectWithTag("botaoPropa"));
        GameObject.Find("naoskip").SetActive(false);
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
            imgvidas[i].gameObject.SetActive(false)  ;
        } 
            for (int i = 0; i < vidas; i++)
            {
                imgvidas[i].gameObject.SetActive(true) ;
            }
                
        }
    }
    

}