using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		float yaw = transform.localEulerAngles.y +horz *5;
		
		transform.eulerAngles = new Vector3(0,yaw,0);
		
		//Debug.Log("horz: "+ horz +" vert: "+ vert);

		CharacterController ccontroler = GetComponent<CharacterController>();
		
		//transform.Rotate(0,horz,0);
		ccontroler.SimpleMove(transform.forward * vert);
		//ccontroler.SimpleMove(Vector3.right * horz);
	}
}
