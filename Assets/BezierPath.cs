using UnityEngine;
using System.Collections;

public class BezierPath : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;


    float t = 0;
    float dt = 0.01f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 P1 = Vector3.Lerp(A.transform.position, B.transform.position, t);
        Vector3 P2 = Vector3.Lerp(B.transform.position, C.transform.position, t);
        Vector3 P3 = Vector3.Lerp(C.transform.position, D.transform.position, t);

        Vector3 P12 = Vector3.Lerp(P1, P2, t);
        Vector3 P23 = Vector3.Lerp(P2, P3, t);

        Vector3 P = Vector3.Lerp(P12, P23, t);
        t += dt;
        transform.position = P;
    }
}
