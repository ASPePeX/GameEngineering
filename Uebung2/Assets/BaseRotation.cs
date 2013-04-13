using UnityEngine;
using System.Collections;

public class BaseRotation : MonoBehaviour {
	//Does a little more then rotating the base ...
	
	private GameObject kugel;
	private GameObject upper;
	private GameObject lower;
	
	// Use this for initialization
	void Start () {
	
		kugel = GameObject.Find("Sphere");
		upper = GameObject.Find("Oberarm");
		lower = GameObject.Find("Unterarm");
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//Base rotation
		transform.localRotation = Quaternion.Euler(0, -1 * Mathf.Rad2Deg * Mathf.Atan2(kugel.transform.localPosition.z,kugel.transform.localPosition.x) + 90, 0);
		/*
		Vector3 kugelpos = GameObject.Find("Sphere").transform.position;
		transform.rotation = Quaternion.Euler(0, -1 * Mathf.Rad2Deg * Mathf.Atan2(kugelpos.z,kugelpos.x) +90, 0);
		*/
		
		//lots of yuck
		float upperDeg1 = Mathf.Atan2(Mathf.Sqrt(Vector3.Distance(upper.transform.position, lower.transform.position) * Vector3.Distance(upper.transform.position, lower.transform.position) - Vector3.Distance(kugel.transform.position, upper.transform.position)/2f * Vector3.Distance(kugel.transform.position, upper.transform.position)/2f), Vector3.Distance(kugel.transform.position, upper.transform.position)/2f);
		float upperDeg2 = Mathf.Atan2((kugel.transform.localPosition.y - upper.transform.localPosition.y), Mathf.Sqrt(Vector3.Distance(kugel.transform.localPosition, upper.transform.position) * Vector3.Distance(kugel.transform.localPosition, upper.transform.position) - (kugel.transform.localPosition.y - upper.transform.localPosition.y) * (kugel.transform.localPosition.y - upper.transform.localPosition.y)));
		float upperH = (3f/2f) * Mathf.PI - upperDeg1;
		float upperDeg = upperDeg1 + upperDeg2;
		
		if(Vector3.Distance(kugel.transform.position, upper.transform.position) <= 2f * Vector3.Distance(upper.transform.position, lower.transform.position))
		{
			upper.transform.localRotation = Quaternion.Euler(((1f/2f) * Mathf.PI - upperDeg) * Mathf.Rad2Deg, 0,0);
			lower.transform.localRotation = Quaternion.Euler((Mathf.PI - upperH * 2f) * Mathf.Rad2Deg, 0,0);
		}
		else
		{
			upper.transform.localRotation = Quaternion.Euler(((1f/2f) * Mathf.PI - upperDeg2) * Mathf.Rad2Deg, 0,0);
			lower.transform.localRotation = Quaternion.Euler(0,0,0);
		}
		
	}
}
