using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BezierPath2 : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;

    Vector3 [] puntos;

    float t = 0;
    float dt = 0.01f;

    int index = 0;
    void Start()
    {
        puntos = new Vector3[9];
        CalcPoints();
    }

    // Update is called once per frame
    void Update()
    {

        
        
        Vector3 P1 = Vector3.Lerp(puntos[index], puntos[index+1], t);
        Vector3 P2 = Vector3.Lerp(puntos[index+1], puntos[index + 2], t);
        Vector3 P = Vector3.Lerp(P1, P2, t);
        if(Input.GetKey(KeyCode.RightArrow))
        t += dt;
        if (Input.GetKey(KeyCode.LeftArrow))
            t -= dt;
        transform.up = P2 - P1;
        transform.position = P;
        if(t>= 1f)
        {
            if (index >= 6)
                index = 0;
            else
            index += 2;
            t = 0;
        }
        if (t < 0f)
        {
            
                index -= 2;
            t = 1f;
        }
        print(t);

    }

    void CalcPoints()
    {
        puntos[index] = A.transform.position;
        puntos[index + 1] = B.transform.position;
        puntos[index + 3] = C.transform.position;
        puntos[index + 2] = (puntos[index + 1]  + puntos[index + 3]) /2 ;
        puntos[index + 5] = D.transform.position;
        puntos[index + 4] = (puntos[index + 3]+ puntos[index + 5]) / 2;
        puntos[index + 7] = E.transform.position;
        puntos[index + 6] = (puntos[index + 5]  + puntos[index + 7])/2;
        puntos[index + 8] = F.transform.position;
    }
}
