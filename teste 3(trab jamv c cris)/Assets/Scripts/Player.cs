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

    // Use this for initialization
    void Start()
    {
        scriptscore = Camera.main.GetComponent<Score>();
        scriptshake = GetComponent<Shake>();
        scriptshake.enabled = false;
        bool explodir = true; 
                 }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.pause)
        {
            protectbug = GameObject.FindGameObjectsWithTag("player");
            if (protectbug.Length > 1)
            {
                Destroy(protectbug[0]);
                Debug.Log("chego");
            }

            gameObject.SetActive(true);
            if (Input.GetKeyDown("left") || touchh.esq)
            {
                touchh.esq = false; 
                transform.Rotate(0, 90, 0, Space.World);
            }

            if (Input.GetKeyDown("right") || touchh.dir)
            {
                transform.Rotate(0, -90, 0, Space.World);
                touchh.dir = false;
            }

            if (Input.GetKeyDown("up") || touchh.cima)
            {
                touchh.cima = false; 
                transform.Rotate(0, 0, -90, Space.World);
            }

            if (Input.GetKeyDown("down") || touchh.baixo)
            {
                touchh.baixo = false; 
                transform.Rotate(0, 0, 90, Space.World);
            }
            if (scriptscore.setVidas == 0)
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


        else gameObject.SetActive(false);
    }
}
    
        
       
        