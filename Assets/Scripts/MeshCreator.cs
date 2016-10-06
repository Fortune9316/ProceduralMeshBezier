using UnityEngine;
using System.Collections.Generic;

public class MeshCreator : MonoBehaviour {

	private Mesh          mesh      = null;
	private Vector3[]     points    = null;
	private List<Vector3> vertices  = new List<Vector3> ();
	private List<int>     triangles = new List<int> ();

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

	void Start () {

		puntos = new Vector3[9];
		CalcPoints();

		MeshFilter filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
		mesh.Clear();

		points = new Vector3[4];
		for (int i = 0; i < points.Length; i++) {
			points[i] = new Vector3(0.5f * (float)i, Random.Range(1f, 2f), 0f);
		}

		//------------------------------------
		int resolution = 10;
		for (int i = 0; i < resolution; i++) {
			t = (float)i / (float)(resolution - 1);
			Vector3 P1 = Vector3.Lerp(puntos[index], puntos[index+1], t);
			Vector3 P2 = Vector3.Lerp(puntos[index+1], puntos[index + 2], t);
			Vector3 p = Vector3.Lerp(P1, P2, t);
			AddTerrainPoint(p);
		}




		//-----------------------------------

		/*int resolution = 10;
		for (int i = 0; i < resolution; i++) {
			float t = (float)i / (float)(resolution - 1);
			Vector3 p = CalculateBezierPoint(t, points[0], points[1], points[2], points[3]);
			AddTerrainPoint(p);
		}*/

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
	}

	void AddTerrainPoint(Vector3 point) {

		vertices.Add(new Vector3(point.x, 0f, 0f));
		vertices.Add(point);

		if (vertices.Count >= 4) {
			int start = vertices.Count - 4;
			triangles.Add(start + 0);
			triangles.Add(start + 1);
			triangles.Add(start + 2);
			triangles.Add(start + 1);
			triangles.Add(start + 3);
			triangles.Add(start + 2);
		}
	}

	private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {

		float u = 1 - t;
		float tt = t * t;
		float uu = u * u;
		float uuu = uu * u;
		float ttt = tt * t;

		Vector3 p = uuu * p0;
		p += 3 * uu * t * p1;
		p += 3 * u * tt * p2;
		p += ttt * p3;

		return p;
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
