using UnityEngine;
using System.Collections;

public class ShaderControl : MonoBehaviour {

	private float radius1 = 0.5f;
	private float radius2 = 0.5f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GUI.changed)
		{
		renderer.material.SetFloat("_Radius1", radius1);
        renderer.material.SetFloat("_Radius2", radius2);
		}
	}
	
	void OnGUI () {
		GUI.Label (new Rect (25, 15, 100, 30), "Radius1");
		GUI.Label (new Rect (25, 35, 100, 30), "Radius2");
		radius1 = GUI.HorizontalSlider (new Rect (80, 21, 100, 15), radius1, 0.0f, 10.0f);
		radius2 = GUI.HorizontalSlider (new Rect (80, 41, 100, 15), radius2, 0.0f, 10.0f);
	}
}
