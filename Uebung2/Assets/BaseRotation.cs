using UnityEngine;
using System.Collections;

public class BaseRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 kugelpos = GameObject.Find("Sphere").transform.position;
		
		transform.rotation = Quaternion.Euler(0, -1 * Mathf.Rad2Deg * Mathf.Atan2(kugelpos.z,kugelpos.x) +90, 0);
	}
}
