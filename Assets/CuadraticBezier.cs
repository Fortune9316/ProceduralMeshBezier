using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CuadraticBezier : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject C;



    float t = 0;
    float dt = 0.01f;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 P1 = Vector3.Lerp(A.transform.position, B.transform.position, t);
        Vector3 P2 = Vector3.Lerp(B.transform.position, C.transform.position, t);
        Vector3 P = Vector3.Lerp(P1, P2, t);      
        t += dt;
        transform.position = P;
	}
}
