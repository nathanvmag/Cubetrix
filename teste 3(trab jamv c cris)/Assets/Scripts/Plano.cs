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
	public GameObject nextPlane ;
   
    private int[] angles = {0,90,180,270};
   
	// Use this for initialization
	void Start () {
        
        alvo.gameObject.name = "ponto";
		player = null; 
       
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, speed*Time.deltaTime);
		if (localplayer.transform.position.x == transform.position.x) {

			if (player!=null && ObjComparar!=null)
			{	
				if (player.transform.rotation == ObjComparar.transform.rotation) Debug.Log("vai virar jogo");
				else Debug.Log("tu é ruim");
			}
			if (ObjComparar!= null) Destroy(ObjComparar.gameObject);
			
			transform.position = new Vector3(65,transform.position.y,transform.position.z);
			speed = speed == 10f? speed = 10f : speed+0.2f;
			
			if(transform.childCount > 0)
			{
				foreach(Transform t in transform)
				{
					Destroy(t.gameObject);
				}
			} 
			newbloco();
		
		}
	}
     void OnTriggerEnter(Collider coll)
    {
       
    }
	void newbloco()
	{
		if (player != null) Destroy(player.gameObject);
		if (controle == 3) {
			controle = 0;
		} else {
			controle ++;
		}

		string objectname = "Plane" + controle;
		//Debug.Log (objectname);
		nextPlane = GameObject.Find (objectname);
		int rand = Random.Range(0, peças.Length);
		player = Instantiate(jogadores[rand], localplayer.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject; 

		ObjComparar = Instantiate(peças[rand],nextPlane.transform.position, Quaternion.Euler(new Vector3(0, angles[Random.Range(0, angles.Length)], angles[Random.Range(0, angles.Length)]))) as GameObject;
		ObjComparar.transform.parent = nextPlane.transform;
		ObjComparar.transform.position += new Vector3(-2.4f, 2, 0);
		//Debug.Log (speed);
	}	
}
