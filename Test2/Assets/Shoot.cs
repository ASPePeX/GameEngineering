using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		rigidbody.AddForce(0,0,-2000);
		rigidbody.useGravity = true;
	}
	
	void OnCollisionEnter(Collision collision)
	{
	foreach (ContactPoint cp in collision.contacts)
		{
			Debug.Log("Collision mit " + cp.otherCollider.name + " bei " + cp);
		}
	}
}
