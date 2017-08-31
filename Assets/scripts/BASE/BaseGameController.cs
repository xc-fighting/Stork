using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameController : MonoBehaviour {
    bool paused;
    public GameObject effectPrefab;
    //此处进行更新ui操作，当玩家生命值为0时候
    public virtual void PlayerLostLife()
    {

    }

    //玩家进行重生操作
    public virtual void SpawnPlayer()
    {

    }
    //玩家正在重生时后的操作
    public virtual void Respawn()
    {

    }
    //开始游戏时候的操作
    public virtual void StartGame()
    {

    }
    //产生效果
    public virtual void doEffect(Vector3 aPosition)
    {
        Instantiate(effectPrefab, aPosition, Quaternion.identity);
    }
    //敌人被摧毁
    public virtual void EnemyDestroyed(Vector3 aPostion,int pointsValue,int hitId)
    {

    }
    //boss 被摧毁
    public virtual void BossDestroyed()
    {

    }

    //当重新开始游戏按钮按下时候的操作
    public virtual void RestartGameButtonPressed()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    //游戏暂停时候的效果
    public bool Paused
    {
        get{
            return paused;
        }
        set
        {
            paused = value;
            if(paused == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
