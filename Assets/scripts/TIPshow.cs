using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIPshow : MonoBehaviour {
    private Camera camera;
    private string[] tip_arr = { "WA!", "NICE!", "GOOD JOB!" };
   
	// Use this for initialization
	void Start () {
        camera = Camera.main;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
