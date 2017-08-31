using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerdefense : MonoBehaviour {
  //  GameObject cannon;
    Transform fire_point;
    GameObject player;
   public  GameObject cannon_bullet;
    Transform m_transform;
    float Timer = 3;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
       // cannon = GameObject.FindGameObjectWithTag("cannon");
        fire_point = m_transform.Find("firepoint");
        player = GameObject.FindGameObjectWithTag("Airplane");
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
		if(Vector3.Distance(m_transform.position, player.transform.position) < 30)
        {
            RotateTo();
            if(Timer<0)
            {
                Timer = 3;
                fire();
            }
        }
	}
    void RotateTo()
    {
        Vector3 oldangle = m_transform.eulerAngles;
        m_transform.LookAt(player.transform);
        float target = m_transform.eulerAngles.y;
        float speed = 60 * Time.deltaTime;
        float angle = Mathf.MoveTowardsAngle(oldangle.y, target, speed);
        m_transform.eulerAngles = new Vector3(0,angle,0);
    }

    void fire()
    {
        Rigidbody ballR = Instantiate(cannon_bullet, 
            fire_point.transform.position, fire_point.transform.rotation).GetComponent<Rigidbody>();
        Vector3 vec = player.transform.position-fire_point.transform.position;
       // vec = vec.normalized;
        ballR.AddForce(vec *60);
    }

}
