using UnityEngine;
using System.Collections;

public class C01_DrawMesh : MonoBehaviour {


public Mesh myMesh;
public Material myMaterial;
	
	// Use this for initialization
	void Start () {
		
		myMesh = new Mesh();
			Vector3[] myVertices = new Vector3[4];
		
		myVertices[0] = new Vector3(-3,0,0);
		myVertices[1] = new Vector3(3,0,0);
		myVertices[2] = new Vector3(0,0,6);
		
		myVertices[3] = new Vector3(0,6,3);
		
		myMesh.vertices = myVertices;
		
		int[] myTriangles = new int[12];
		
		myTriangles[0] = 0;
		myTriangles[1] = 1;
		myTriangles[2] = 2;
		
		myTriangles[3] = 2;
		myTriangles[4] = 1;
		myTriangles[5] = 3;
		
		myTriangles[6] = 0;
		myTriangles[7] = 2;
		myTriangles[8] = 3;
		
		myTriangles[9] = 1;
		myTriangles[10] = 0;
		myTriangles[11] = 3;
		
		myMesh.triangles = myTriangles;

		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) + transform.position;
		Graphics.DrawMesh(myMesh, transform.position, Quaternion.identity, myMaterial, 0);

		
	}
}
