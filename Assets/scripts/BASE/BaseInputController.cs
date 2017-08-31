using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInputController : MonoBehaviour {
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool fire;
    //for weapon slots
    public bool slot1;
    public bool slot2;
    public bool slot3;
    public bool slot4;
    public bool slot5;
    public bool slot6;
    public bool slot7;
    public bool slot8;
    public bool slot9;

    public float vert;
    public float horz;
    public bool shouldRespawn;

    public Vector3 TEMPVec3;
    private Vector3 zeroVector = new Vector3(0, 0, 0);

    public virtual void CheckInput()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
    }

    public virtual float getHorizontal()
    {
        return horz;
    }

    public virtual float getVertical()
    {
        return vert;
    }

    public virtual bool getFire()
    {
        return fire;
    }
    public bool getRespawn()
    {
        return shouldRespawn;
    }

    public virtual Vector3 GetMovementDirectionVector()
    {
        TEMPVec3 = zeroVector;
        if (left || right)
        {
            TEMPVec3.x = horz;
        }
        if (up || down)
        {
            TEMPVec3.y = vert;
        }
        return TEMPVec3;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
