using UnityEngine;
using System.Collections;

public class touchV2 : MonoBehaviour {
    bool salvarposi,esperar;
    public static bool esq, dir, cima, baixo, aperto;
    float posix, posiy;
    float timer; 
	// Use this for initialization
	void Start () {
        salvarposi = true;
        esperar = true;
        timer = 0; 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount>0)
        {
            if (salvarposi)
            {
                posix = Input.GetTouch(0).position.x;
                posiy = Input.GetTouch(0).position.y;
               // Debug.Log("x= " + posix + " y= " + posiy);
               salvarposi=false ;}

            if (Input.GetTouch(0).phase == TouchPhase.Moved && !salvarposi)
            {
                if (Input.GetTouch(0).position.x> posix+20 && esperar)
                {
                    //Debug.Log("arrasto direta");
                    dir = true; 
                    esperar = false;
                }
                else if (Input.GetTouch(0).position.x < posix - 20&& esperar)
                {
                   // Debug.Log("arrasto esq");
                    esq = true; 
                    esperar = false;
                }
                else if (Input.GetTouch(0).position.y > posiy + 20&& esperar)
                {
                    //Debug.Log("arrasto cima");
                    cima = true; 
                    esperar = false;
                }
                else if (Input.GetTouch(0).position.y < posiy -20&& esperar)
                {
                    baixo = true;
                    // Debug.Log("arrasto baixo");                    
                    esperar = false;
                }
            }
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                timer += Time.deltaTime;
                if (timer > 0.1f)
                {
                    aperto = true;
                }
            }
            else
            {
                timer = 0;
                aperto = false;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended) { salvarposi = true; esperar = true; }
        }
	
	}
}
