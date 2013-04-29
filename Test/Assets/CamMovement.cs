using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {
	
	private Vector3 camRot;
	private Vector3 camMov;

	float camRotSpeedMod = 5000;
	float camMovSpeedMod = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		camMov.x = Input.GetAxis("Horizontal") * camMovSpeedMod * Time.deltaTime;
		camMov.z = Input.GetAxis("Vertical") * camMovSpeedMod * Time.deltaTime;
		
		if(Input.GetKey(KeyCode.Q))
			camMov.y = Time.deltaTime * camMovSpeedMod * (-1);
		
		else if(Input.GetKey(KeyCode.E))
			camMov.y = Time.deltaTime * camMovSpeedMod;
		
		else
			camMov.y = 0;
		
		transform.Translate(camMov, Camera.main.transform);

		// Left
		if(Input.GetKey(KeyCode.Keypad4))
			camRot.y -=  Time.deltaTime * camRotSpeedMod * Time.deltaTime;

		// Right
		if(Input.GetKey(KeyCode.Keypad6))
			camRot.y +=  Time.deltaTime * camRotSpeedMod * Time.deltaTime;
		
		// Up
		if(Input.GetKey(KeyCode.Keypad8))
			camRot.x -=  Time.deltaTime * camRotSpeedMod * Time.deltaTime;
		
		// Down
		if(Input.GetKey(KeyCode.Keypad2))
			camRot.x +=  Time.deltaTime * camRotSpeedMod * Time.deltaTime;

		if(Input.GetKey(KeyCode.Keypad5))
		{
			camRot.x = 0;
			camRot.y = 0;
		}
		transform.rotation = Quaternion.Euler(camRot);
		
		
	}
}
