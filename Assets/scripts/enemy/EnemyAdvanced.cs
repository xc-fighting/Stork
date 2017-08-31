using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAdvanced : MonoBehaviour {

    Transform m_transform;
    GameObject player;
    NavMeshAgent m_agent;
    float speed = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.tag.CompareTo("Airplane")==0)
        {
            player.GetComponent<PlayerHealth>().getHurt(10);
        }
    }

    // Use this for initialization
    void Start () {
        m_transform = this.transform;
        player = GameObject.FindGameObjectWithTag("Airplane");
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(m_transform.position, player.transform.position) < 50)
        {
            m_agent.enabled = true;
            m_agent.SetDestination(player.transform.position);
            MoveTo();
        }
        else
        {
            m_agent.enabled = false;
        }
    }
    void MoveTo()
    {
        m_agent.Move(m_transform.TransformDirection(new Vector3(0, 0, speed * Time.deltaTime)));
    }
}
