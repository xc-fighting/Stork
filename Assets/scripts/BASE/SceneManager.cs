using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public string[] levelNames;
    public int gameLevelNum;
	// Use this for initialization
	void Start () {
        //保持gameobject活跃状态
        DontDestroyOnLoad(this.gameObject);
	}

    public void LoadLevel(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
	
    public void GoNextLevel()
    {
        if(gameLevelNum >= levelNames.Length)
        {
            gameLevelNum = 0;
        }
        LoadLevel(levelNames[gameLevelNum]);
        gameLevelNum++;
    }

    public void ResetGame()
    {
        gameLevelNum = 0;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
