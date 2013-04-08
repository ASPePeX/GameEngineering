using UnityEngine;
using System.Collections;

public class Kugel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float y = 0;
		if (Input.GetKey(KeyCode.Q))
			y = -1;
		else if (Input.GetKey(KeyCode.E))
			y = 1;
		transform.position = new Vector3(Input.GetAxis("Horizontal"), y, Input.GetAxis("Vertical")) * Time.deltaTime *10 + transform.position;
		
	}
}
