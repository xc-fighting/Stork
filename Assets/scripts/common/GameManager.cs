using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int totalScore = 0;
    public PlayerHealth ph;
  
	// Use this for initialization
	void Start () {
        ph = GameObject.FindGameObjectWithTag("Airplane").GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 40;
        GUI.Label(new Rect(0, 20, Screen.width, 50), "Score:" + totalScore);
       if(ph.currentHealth<=0)
        {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "game over");
        //    Time.timeScale = 0;
            GUI.skin.label.fontSize = 30;
            if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.75f, 500, 60), "try again"))
            {
              //  Time.timeScale = 1;
                //Application.LoadLevel(Application.loadedLevelName);
                SceneManager.LoadScene("game");
               
            }
        }
       
    }
}
