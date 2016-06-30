using UnityEngine;
using System.Collections;

public class Plano  : MonoBehaviour {
    static public float speed = 2;
    public GameObject alvo;
    public  GameObject[] peças,jogadores;
    public static GameObject ObjComparar;
    public static GameObject player; 
    public GameObject localplayer; 
    static public int controle = 0 ; 
	public GameObject nextPlane;
	public static GameObject copy;
    private int[] angles = {0,90,180,270};
	Transform localpespe;
    private Score score; 
    public static float  speedantiga;
    public Material[] skyboxes; 
    public static int seguidas = 0;
    public AudioClip passou,explo,erro,winlife;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        speed = 2;
        controle = 0;
       
        score = Camera.main.GetComponent<Score>();
        alvo.gameObject.name = "ponto";
		player = null; 
		localpespe = GameObject.Find ("pespe").GetComponent<Transform> ();
        speedantiga = speed;
        
        seguidas = 0; 
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!Pause.pause &&!Score.showbutton)
        {
			Debug.Log (speed);
            
            if (Input.GetKey(KeyCode.Space)|| touchV2.aperto)
            {
               speed = 10;

            }
            else
            {
                speed = speedantiga;
               // Debug.Log(speed);
            }
            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, speed * Time.deltaTime);
            if (localplayer.transform.position.x >= transform.position.x)
            {
                bool acertou;
                if (player != null && ObjComparar != null)
                {
                    Vector3 diff = player.transform.eulerAngles - ObjComparar.transform.eulerAngles;
                    if (diff.magnitude <= 0.1f)
                    {
                       acertou = true;
                    }
                   else acertou = false;

                    if (acertou)
                    {
                       // Debug.Log("Valeu = a peca se chama " + ObjComparar.gameObject.name + "e a rotacao " + ObjComparar.transform.rotation + "player " + player.transform.rotation);
						if (speed >= 10) {
							speed = 10; 
							if (speed < 7) {
								speedantiga += 0.1f;
							}

						} else if (speed<7) {
							speed += 0.1f;
						}
                        score.setScore += 1;
                        if (score.setScore % 10 == 0) RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];
                        if (speed < 10 ) speedantiga = speed;
                        seguidas++;
                        if (seguidas == 10) audio.PlayOneShot(winlife);
                        else audio.PlayOneShot(passou);
                        
                    }
                    else
					{ 	if (speed>=3)
                        speed -= 0.4f;
                       // Debug.Log("Fail a peca se chama " + ObjComparar.gameObject.name + "e a rotacao " + ObjComparar.transform.rotation + "player " + player.transform.rotation);
                        if (score.setVidas-1==0&&!Score.mostro)
                        {
                            int rand = Random.Range(0, 3);
                            Debug.Log("o rand é " + rand);
                            if (rand == 1) Score.showbutton = true;
                            else score.setVidas--;
                            Debug.Log("veio\a");
                        }
                        else score.setVidas--;
                        seguidas = 0;
                        audio.PlayOneShot(erro);
                    }
                }
                if (ObjComparar != null) Destroy(ObjComparar.gameObject);
                transform.position = new Vector3(65, transform.position.y, transform.position.z);
                if (score.setVidas != 0 )
                {
                    if (transform.childCount > 0)
                    {
                        foreach (Transform t in transform)
                        {
                            Destroy(t.gameObject);
                        }
                    }
                    newbloco();
                }
                
            }
        }
    }
     void OnTriggerEnter(Collider coll)
    {
       if (coll.gameObject.tag == "plano") {
			Debug.Log ("Aee");
			controle = 0; 
			Vector3 posi = ObjComparar.transform.position;
			voltaOrdem();
				ObjComparar.transform.parent = GameObject.Find("Plane0").transform;
			ObjComparar.transform.position = posi;
		}
    }
	void newbloco()
	{
		if (player != null) Destroy(player.gameObject);
		if (copy != null) Destroy (copy.gameObject);
		if (controle == 3) {
			controle = 0;
		} else {
			controle ++;
		}

		string objectname = "Plane" + controle;
		
		nextPlane = GameObject.Find (objectname);
		int rand = Random.Range(0, peças.Length);
		player = Instantiate(jogadores[rand], localplayer.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject; 
		copy = Instantiate (peças[rand], localpespe.position, Quaternion.identity)as GameObject;
		copy.transform.eulerAngles = new Vector3 (0, 330, 0);
		ObjComparar = Instantiate(peças[rand],nextPlane.transform.position, Quaternion.identity) as GameObject;

		ObjComparar.transform.parent = nextPlane.transform;
		ObjComparar.transform.rotation= Quaternion.Euler(0, angles [Random.Range (0, angles.Length)], angles [Random.Range (0, angles.Length)]);
		ObjComparar.transform.position += new Vector3(-2.4f, 2, 0);
		if (rand == 1 || rand == 2 )
			copy.transform.Translate (Vector3.down * 1);
		else if (rand == 3)
			copy.transform.Translate (Vector3.down * 0.5f);

	}
	void voltaOrdem()
	{
		for (int i= 0; i<4; i++) {
			if (i == 0) {
				GameObject.Find ("Plane" + i).transform.position = ObjComparar.transform.parent.position;
			}
			GameObject.Find("Plane"+i).transform.position = new Vector3 (5 + (i*20),transform.position.y,transform.position.z);
		}
	}

}
