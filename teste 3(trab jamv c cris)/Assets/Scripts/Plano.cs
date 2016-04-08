using UnityEngine;
using System.Collections;

public class Plano  : MonoBehaviour {
    static public float speed = 2;
    public GameObject alvo;
    public GameObject[] peças,jogadores;
    public static GameObject ObjComparar;
    public static GameObject player; 
    public GameObject localplayer; 
    static public int controle = 0 ; 
	public GameObject nextPlane;
	public static GameObject copy;
	int a;
    private int[] angles = {0,90,180,270};
	Transform localpespe;
    private Score score; 
	// Use this for initialization
	void Start () {
        speed = 2;
        controle = 0;
        a = 0; 
        score = Camera.main.GetComponent<Score>();
        alvo.gameObject.name = "ponto";
		player = null; 
		localpespe = GameObject.Find ("pespe").GetComponent<Transform> ();
        
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!Pause.pause)
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, speed * Time.deltaTime);
            if (localplayer.transform.position.x == transform.position.x)
            {
                bool acertou;
                if (player != null && ObjComparar != null)
                {

                    if (player.transform.rotation == ObjComparar.transform.rotation)
                    {
                        //Debug.Log ("Valeu = a peca se chama " + ObjComparar.gameObject.name+"e a rotacao "+ ObjComparar.transform.rotation+ "player "+player.transform.rotation);
                        acertou = true;
                    }
                    else if (ObjComparar.transform.rotation * new Quaternion(-1f, -1f, -1f, -1f) == player.transform.rotation)
                    {
                        acertou = true;
                        Debug.Log("protectbug" + a);
                        a++;
                    }
                    else acertou = false;

                    if (acertou)
                    {
                        Debug.Log("Valeu = a peca se chama " + ObjComparar.gameObject.name + "e a rotacao " + ObjComparar.transform.rotation + "player " + player.transform.rotation);
                        speed = speed == 10f ? speed = 10f : speed + 0.2f;
                        score.setScore += 1;

                    }
                    else
                    {
                        speed -= 0.4f;
                        Debug.Log("Fail a peca se chama " + ObjComparar.gameObject.name + "e a rotacao " + ObjComparar.transform.rotation + "player " + player.transform.rotation);
                        score.setVidas--;
                    }
                }
                if (ObjComparar != null) Destroy(ObjComparar.gameObject);

                transform.position = new Vector3(65, transform.position.y, transform.position.z);


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
     void OnTriggerEnter(Collider coll)
    {
       
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
}
