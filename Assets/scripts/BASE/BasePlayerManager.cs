using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerManager : MonoBehaviour {
    public bool didInit;
    public BaseUserManager DataManager;

    public virtual void Awake()
    {
        didInit = false;
        Init();
    }

    public virtual void Init()
    {
        DataManager = gameObject.GetComponent<BaseUserManager>();
        if(DataManager == null)
        {
            DataManager = gameObject.AddComponent<BaseUserManager>();
        }
        didInit = true;
    }
    public virtual void GameFinished()
    {
        DataManager.SetIsFinished(true);
    }
    public virtual void GameStart()
    {
        DataManager.SetIsFinished(false);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
