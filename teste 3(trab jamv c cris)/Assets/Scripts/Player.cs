using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private Score scriptscore;
    private Shake scriptshake;
    bool explodir = true;

    // Use this for initialization
    void Start()
    {
        scriptscore = Camera.main.GetComponent<Score>();
        scriptshake = GetComponent<Shake>();
        scriptshake.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.pause)
        {
            gameObject.SetActive(true);
            if (Input.GetKeyDown("left"))
            {
                transform.Rotate(0, 90, 0, Space.World);
            }

            if (Input.GetKeyDown("right"))
            {
                transform.Rotate(0, -90, 0, Space.World);
            }

            if (Input.GetKeyDown("up"))
            {
                transform.Rotate(0, 0, -90, Space.World);
            }

            if (Input.GetKeyDown("down"))
            {
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
    
        
       
        