using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour {
    public float _Speed = 10;
    public float _LiveTime = 5;
    public float _power = 10;
    Transform _transform;
	// Use this for initialization
	void Start () {
        _transform = this.transform;

	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("levelOneEnv")==0)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        _LiveTime -= Time.deltaTime;
        if(_LiveTime<=0)
        {
            Destroy(this.gameObject);
        }
        _transform.Translate(new Vector3(0, 0, _Speed * Time.deltaTime));
	}
}
