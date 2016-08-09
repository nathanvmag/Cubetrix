using UnityEngine;
using System.Collections;
public class giramentodapeca : MonoBehaviour
{
    float[] ale = new float[2] { -0.8f, 0.8f };

    float valor;
    Vector3[] posi;
    Vector3[] rot;
    int controle;
    bool voltar, rodar;
    // Use this for initialization
    void Start()
    {
        voltar = false;
        rodar = true;
        posi = new Vector3[transform.childCount];
        rot = new Vector3[transform.childCount];
        controle = 0;
        Debug.Log("tenho " + transform.childCount);
        valor = ale[Random.Range(0, ale.Length)];
        if (transform.childCount > 0)
        {
            foreach (Transform t in transform)
            {
                posi[controle] = t.localPosition;
                rot[controle] = t.localEulerAngles;
                controle++;
            }
        }

    }



    void FixedUpdate()
    {
        if (rodar)
            transform.Rotate(new Vector3(0, 0, valor));
        //transform.Rotate(Vector3.left);

    }
    // Update is called once per frame
    void Update()
    {
        click();
        if (voltar)
        {
            if (transform.childCount > 0)
            {
                foreach (Transform t in transform)
                {
                    t.localPosition = Vector3.MoveTowards(t.localPosition, posi[controle], 10 * Time.deltaTime);
                    // posi[controle] = t.localPosition;
                    t.localRotation = Quaternion.Euler(rot[controle]);
                    // rot[controle] = t.localEulerAngles;
                    controle++;
                }
                if (controle == rot.Length) controle = 0;
            }

        }
    }
    public IEnumerator explosao()
    {
       // yield return new WaitForSeconds(3);
        if (transform.childCount > 0)
        {
            foreach (Transform t in transform)
            {
                Debug.Log("bla");
                t.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode.Impulse);

            }
            rodar = false;




        }
        yield return new WaitForSeconds(3);
        voltar = true;
        controle = 0;
        rodar = true;


    }

    private void click()
    {
        if (Input.touchCount > 0)
        {

            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform == gameObject.transform)
                {
                    if (rodar) {StartCoroutine(explosao());
                    voltar = false;
                    rodar = false;
                    }
                }

            }
        }



    }
}