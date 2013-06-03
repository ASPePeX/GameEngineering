using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Boom(Vector3 camRot) 
	{
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.Euler(Vector3.zero);
		transform.rotation = Quaternion.Euler(camRot);
		rigidbody.AddForce(transform.forward *500);
		rigidbody.useGravity = true;
	}
}
  