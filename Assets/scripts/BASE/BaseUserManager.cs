using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUserManager : MonoBehaviour {

    private int score;
    private int highScore;
    private int level;
    private int health;
    private bool isFinished;

    public string playerName = "csci526";

    public virtual void GetDefaultData()
    {
        playerName = "csci526";
        score = 0;
        level = 1;
        health = 100;
        highScore = 0;
        isFinished = false;
    }
    // get-set name
    public string GetName()
    {
        return this.playerName;
    }

    public void SetName(string aName)
    {
        this.playerName = aName;
    }
    // get set level
    public int GetLevel()
    {
        return this.level;
    }
    public void SetLevel(int alevel)
    {
        this.level = alevel;
    }

    //get highest score
    public int GetHighScore()
    {
        return this.highScore;
    }

    //get set score
    public int GetScore()
    {
        return this.score;
    }
    public void SetScore(int num)
    {
        this.score = num;
    }

    //add lose score
    public virtual void AddScore(int anAmount)
    {
        score += anAmount;
    }

    public virtual void LostScore(int num)
    {
        score -= num;
    }

    //get set health
    public int GetHealth()
    {
        return this.health;
    }
    public void SetHealth(int num)
    {
        this.health = num;
    }
    public void AddHealth(int num)
    {
        health += num;
    }
    public void ReduceHealth(int num)
    {
        health -= num;
    }


    public bool GetIsFinished()
    {
        return this.isFinished;
    }

    public void SetIsFinished(bool aVal)
    {
        isFinished = aVal;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
