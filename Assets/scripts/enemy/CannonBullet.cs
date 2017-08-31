using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour {
    GameObject player;
    PlayerHealth ph;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.tag.CompareTo("Airplane")==0)
        {
            ph.getHurt(10);
            Destroy(this.gameObject);
        }
        if(collision.rigidbody.tag.CompareTo("levelOneEnv")==0)
        {
            Debug.Log("hit the ground");
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Airplane");
        ph = player.GetComponent<PlayerHealth>();
     //   GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0)*400);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
