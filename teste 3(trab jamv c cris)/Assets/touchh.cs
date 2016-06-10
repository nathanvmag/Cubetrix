using UnityEngine;
using System.Collections;

public class touchh : MonoBehaviour {
    public static bool esq, dir, cima, baixo,aperto;
    float timer; 
	// Use this for initialization
    void OnEnable()
    {
        EasyGesture.onSwipe += OnSwipe;
        timer = 0; 
	}

    void OnDisable()
    {
        EasyGesture.onSwipe -= OnSwipe;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount>0)
        {
            if (Input.GetTouch(0).phase==TouchPhase.Stationary)
            {
                timer += Time.deltaTime;
                if (timer>0.5f)
                {
                    aperto = true; 
                }
            }
            else
            {
                timer = 0;
                aperto = false; 
            }
        }
       
       
	}
    void OnSwipe(EasyGesture.Gesture type, float speed)
    {
        switch (type){
            case EasyGesture.Gesture.SWIPE_RIGHT:
                dir = true;
                Debug.Log("dir");
                break;
            case EasyGesture.Gesture.SWIPE_LEFT:
                esq = true; 
                 Debug.Log("esq");
                break;
            case EasyGesture.Gesture.SWIPE_DOWN:
                baixo = true; 
                 Debug.Log("down");
                break;
            case EasyGesture.Gesture.SWIPE_UP:
                cima = true; 
                 Debug.Log("up");
                break;

    }
}

}
