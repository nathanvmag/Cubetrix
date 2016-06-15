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
    float t = 5;
    
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Tutorial());
        highScore = PlayerPrefs.GetInt("highscore") == null ? 0 : PlayerPrefs.GetInt("highscore");
        setVidas = 1;
        setScore = 0;
        Plano.player =  Instantiate(jogadores[Random.Range(0,jogadores.Length)], GameObject.Find("posiplayer").transform.position, Quaternion.identity)as GameObject;
        showbutton = false;
        mostro = false;
        t = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        if (showbutton)
        {
            t -= Time.deltaTime;
            Debug.Log("veio");
            if (!mostro)
            {
                Instantiate(botaopropa, local.position, Quaternion.identity);
                mostro = true;
            }
            if (t <0)
            {
                showbutton = false;
                setVidas--;
               GameObject.FindGameObjectWithTag("botaoPropa").SetActive(false);
                
            }}
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
                scoretext.color = new Color(84f / 255f, 225f / 255f, 178f / 255f);

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
                    Application.LoadLevel("derrota");
                }
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
            imgvidas[i].gameObject.SetActive(false)  ;
        } 
            for (int i = 0; i < vidas; i++)
            {
                imgvidas[i].gameObject.SetActive(true) ;
            }
                
                       }
    }
    IEnumerator Tutorial()
    {
        tutorialimg.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        tutorialimg.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        start.gameObject.SetActive(false);
        

    }

}