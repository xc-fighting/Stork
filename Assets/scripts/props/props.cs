using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class props : MonoBehaviour {

    public Transform p_transform;
    public float RotateX =60;
    public int type;
    public GameManager gm;
	// Use this for initialization
	void Start () {
        p_transform = this.transform;
        gm = GameObject.FindGameObjectWithTag("gameM").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        p_transform.Rotate(RotateX*Time.deltaTime,0,0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("Airplane")==0)
        {
            Destroy(this.gameObject);
            gm.totalScore += 50;
        }
    }
}
