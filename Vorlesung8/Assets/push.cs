using UnityEngine;
using System.Collections;

public class push : MonoBehaviour {
	
	public GameObject frontalAxle;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			float vert = Input.GetAxis("Vertical");
		//rigidbody.AddForce(Vector3.forward * vert);
		frontalAxle.rigidbody.AddTorque(vert*10,0,0);
		
	}
}
