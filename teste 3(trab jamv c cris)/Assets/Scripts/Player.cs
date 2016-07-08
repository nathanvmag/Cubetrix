using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    private Score scriptscore;
    private Shake scriptshake;
    bool explodir = true;
    GameObject[] protectbug; 
	public static bool esq1,dir1,cima1,baixo1;
    // Use this for initialization
    void Start()
    {
        scriptscore = Camera.main.GetComponent<Score>();
        scriptshake = GetComponent<Shake>();
        scriptshake.enabled = false;
        bool explodir = true; 
		esq1 = false; 
		dir1 = false;
		cima1 = false;
		baixo1 = false; 
                 }

    // Update is called once per frame
    void Update()
    {
       
        if (!Pause.pause && !Score.showbutton)
        {
            protectbug = GameObject.FindGameObjectsWithTag("player");
            if (protectbug.Length > 1)
            {
                Destroy(protectbug[0]);
                Debug.Log("chego");
            }

            gameObject.SetActive(true);

			if ((Input.GetKeyDown("left") || touchV2.esq) && !Score.firtsSlideY)
            {
				if (Score.firtSlideX)
					esq1 = true;
				else
					esq1 = false;
                touchV2.esq = false; 
                transform.Rotate(0, 90, 0, Space.World);
            }

			if( (Input.GetKeyDown("right") || touchV2.dir) && !Score.firtsSlideY)
            {
				if (Score.firtSlideX)
					dir1 = true;
				else
					dir1 = false;
                transform.Rotate(0, -90, 0, Space.World);
                touchV2.dir = false;
            }

			if ((Input.GetKeyDown("up") || touchV2.cima) && !Score.firtSlideX)
            {
				if (Score.firtsSlideY)
					cima1 = true;
				else
					cima1 = false;
                touchV2.cima = false; 
                transform.Rotate(0, 0, -90, Space.World);
            }

			if ((Input.GetKeyDown("down") || touchV2.baixo)&& !Score.firtSlideX)
            {
			
				if (Score.firtsSlideY)
					baixo1 = true;
				else
					baixo1 = false;
                touchV2.baixo = false; 
                transform.Rotate(0, 0, 90, Space.World);
            }
			touchV2.esq = false; 
			touchV2.dir = false; 
			touchV2.cima = false;
			touchV2.baixo = false; 
            if (scriptscore.setVidas == 0 )
            {
                scriptshake.enabled = true;

                
                if (scriptshake.shakeDuration == 0)
                {
                    if (transform.childCount > 0 && explodir)
                    {
                        foreach (Transform t in transform)
                        {
                            Debug.Log("bla");
                            t.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);

                        }
                        
                        transform.DetachChildren();
                        explodir = false;                       
                        Destroy(transform.gameObject);
                    }


                }
            }
        }


        else if (Pause.pause)gameObject.SetActive(false);
    }
}
    
        
       
        