using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public static bool pause;
    
   public GameObject[] pauseUi;
	void Start () {
        pause = false; 
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) pause = !pause;
        
        if (!pause)
        {
            click();
            for (int i = 0; i < pauseUi.Length; i++)
            {
                pauseUi[i].SetActive(false);
            }
            if (Plano.player!=null) Plano.player.gameObject.SetActive(true);
        }
        else
        {
        for(int i = 0; i<pauseUi.Length;i++)
        {
            pauseUi[i].SetActive(true);
        }
        }
    }
    private void click()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "pause")
                {
                    
                    pause = true; 
                }

            }
        }

    }
          public void btplay()
    {
        pause = false; 
    }
         public void btreload()
          {
              Application.LoadLevel("GrandeGame"); 
          }

         }

