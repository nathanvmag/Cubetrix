using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
        }
        else gameObject.SetActive(false);
    }

	void OnCollisionEnter(Collision collision)
	{

	}
}