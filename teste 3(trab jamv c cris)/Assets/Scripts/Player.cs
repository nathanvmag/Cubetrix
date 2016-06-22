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
        if (mudardecena.sound) Camera.main.GetComponent<AudioListener>().enabled = true;
        else Camera.main.GetComponent<AudioListener>().enabled = false; 

        if (!Pause.pause && !Score.showbutton)
        {
            protectbug = GameObject.FindGameObjectsWithTag("player");
            if (protectbug.Length > 1)
            {
                Destroy(protectbug[0]);
                Debug.Log("chego");
            }

            gameObject.SetActive(true);
            if (Input.GetKeyDown("left") || touchV2.esq)
            {
                touchV2.esq = false; 
                transform.Rotate(0, 90, 0, Space.World);
            }

            if (Input.GetKeyDown("right") || touchV2.dir)
            {
                transform.Rotate(0, -90, 0, Space.World);
                touchV2.dir = false;
            }

            if (Input.GetKeyDown("up") || touchV2.cima)
            {
                touchV2.cima = false; 
                transform.Rotate(0, 0, -90, Space.World);
            }

            if (Input.GetKeyDown("down") || touchV2.baixo)
            {
                touchV2.baixo = false; 
                transform.Rotate(0, 0, 90, Space.World);
            }
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
    
        
       
        