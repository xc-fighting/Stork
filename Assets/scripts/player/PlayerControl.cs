using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
   
   //子弹的发射频率
    public float bulletRate = 0;

    //子弹的速度
    public float speed = 3f;

    //player自身的transform
    public Transform m_transform;

    //玩家子弹的transform
    public Transform m_pbullet;
   
    //能量回复频率
    public float energyRetriveRate = 5;
    
    //玩家角色gameobject
	GameObject player;

    //玩家生命
	PlayerHealth playerHealth;
    public GameObject[] enemy;


    //标志位 
    public int shooting = 0;
    public int accelerating = 0;

    public Texture forward_pic;
    public Texture shoot_pic;
    
	public bool isleft = false;
	public bool isright = false;

    public float AccRate = 0f;

    public bool isLevelPass=false;

    public EasyJoystick myJoyStick;

    public TrailRenderer trail1;
    public TrailRenderer trail2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("levelOneEnv")==0)
        {
            m_transform.Rotate(0, 180, 0);
         //   m_transform.Rotate(0, 0, m_transform.rotation.z);
            //m_health -= 50;
		//	playerHealth.getHurt(10);
        }
        if(other.tag.CompareTo("enemy1")==0)
        {
            playerHealth.getHurt(20);
        }
        if(other.tag.CompareTo("levelentry")==0)
        {
            if(playerHealth.currentHealth>0)
            {
                isLevelPass = true;
                Time.timeScale = 0;
            }
        }
    }


    // Use this for initialization
    void Start () {

        enemy = GameObject.FindGameObjectsWithTag("enemy1");
        trail1 = GameObject.FindGameObjectWithTag("wing1").GetComponent<TrailRenderer>();
        trail2 = GameObject.FindGameObjectWithTag("wing2").GetComponent<TrailRenderer>();
        trail1.enabled = false;
        trail2.enabled = false;
        myJoyStick = GameObject.Find("sticker1").GetComponent<EasyJoystick>();
        m_transform = this.transform;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;

		player = GameObject.FindGameObjectWithTag ("Airplane");
  
		playerHealth = player.GetComponent<PlayerHealth> ();
       
    }

   
    // Update is called once per frame
    void Update () { 
       //每隔5s 加20的能量值  
		if (!playerHealth.isFullEnergy())
        {
            energyRetriveRate -= Time.deltaTime;
            if (energyRetriveRate<=0)
            {
                energyRetriveRate = 5;
                //m_energy += 20;
				playerHealth.getEnergy (20);
            }
        }


      //  Accelerate();
        AccRate -= Time.deltaTime;
        if (AccRate < 0)
        {
            speed = 6f;
            trail1.enabled = false;
            trail2.enabled = false;
        }
        // Shoot();
        //  shooting = 0;
        bulletRate -= Time.deltaTime;

		if (myJoyStick.JoystickTouch == Vector2.zero) {
			//===newly added
			Vector3 temp = transform.rotation.eulerAngles;
			temp.x = 0f;
			temp.z = 0f;
			transform.rotation = Quaternion.Euler(temp);
			isleft = false;
			isright = false;
			//=====
		}
        else if (myJoyStick.JoystickTouch != Vector2.zero)
        {

            // Debug.Log("you press the stick");
            float jposx = myJoyStick.JoystickAxis.x;
            float jposy = myJoyStick.JoystickAxis.y;
         //   Debug.Log("x offset:" + jposx + "y offset:" + jposy);
            //    m_transform.LookAt(new Vector3(player.transform.position.x+jposx,player.transform.position.y+jposy,
            //      player.transform.position.z+jposy));
            m_transform.Translate(0, jposy * 6*Time.deltaTime, 0);
            if (jposx > 0)
            {
				//====newly added==
				if (isleft) {
					isleft = false;
					Vector3 temp = transform.rotation.eulerAngles;
					temp.x = 0f;
					temp.z = 0f;
					transform.rotation = Quaternion.Euler(temp);
				}
				if (!isright) {
					isright = true;
					m_transform.Rotate(0, 0, -10);
					print ("turn right");
				}
				//======end======
                m_transform.Rotate(0, 60 * Time.deltaTime, 0);
            }
            else if (jposx < 0)
            {
				//====newly added==
				if (isright) {
					isright = false;
					Vector3 temp = transform.rotation.eulerAngles;
					temp.x = 0f;
					temp.z = 0f;
					transform.rotation = Quaternion.Euler(temp);
				}
				if (!isleft) {
					isleft = true;
					m_transform.Rotate(0, 0, 10);
					print ("turn left");
				}
				//======end======
                m_transform.Rotate(0, -60 * Time.deltaTime, 0);
            }
        }
       
        m_transform.Translate(Vector3.forward * Time.deltaTime *speed);
        if (Application.platform==RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
	}

    public void Shoot()
    {
        //  bulletRate -= Time.deltaTime;
        enemy = GameObject.FindGameObjectsWithTag("enemy1");
        if (bulletRate<=0)
        {
       
                bulletRate = 0.1f;

                if (playerHealth.tired == false)
            {
                if(enemy.Length>0)
                {
                    
                    GameObject target=null;
                    float dis = 0;
                    float min = float.MaxValue;
                    for(int i=0;i<enemy.Length;i++)
                    {
                        dis = Vector3.Distance(m_transform.position, enemy[i].transform.position);
                        if ( dis< min)
                        {
                            target = enemy[i];
                            min = dis;
                           // break;
                        }
                        
                    }
                  //  if (target != null)
                   // {
                        Vector3 relativePos = target.transform.position - m_transform.position;
                        Instantiate(m_pbullet,
                            new Vector3(m_transform.position.x, m_transform.position.y, m_transform.position.z),
                            Quaternion.LookRotation(relativePos));

                  //  }
                   
                       
                    
                    
                   
                }
                else
                {
                    Instantiate(m_pbullet,
                       new Vector3(m_transform.position.x, m_transform.position.y, m_transform.position.z),
                       m_transform.rotation);
                }
                playerHealth.consumeEnergy(20);
            }

        }
    }

    public void Accelerate()
    {
       
        if ( AccRate < 0 && playerHealth.tired==false)
        {
            trail1 . enabled = true;
            trail2.enabled = true;
            AccRate = 3;
            speed = 30;
        }
        playerHealth.consumeEnergy(20);

    }


    private void OnGUI()
    {
      
        //if (GUI.RepeatButton(new Rect(Screen.width - Screen.height / 10, Screen.height * 9 / 10, Screen.height /10, Screen.height / 10), shoot_pic))
        //{
        //    shooting = 1;
        //}
        //if (GUI.RepeatButton(new Rect(Screen.width - Screen.height / 5, Screen.height * 4 / 5, Screen.height / 10, Screen.height / 10), forward_pic))
        //{
        //    accelerating = 1;   
        //}
        if(isLevelPass)
        {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 100;
            
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "SUCCESS!");
            GUI.skin.label.fontSize = 30;
            if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.75f, 500, 60), "next level"))
            {
                Time.timeScale = 1;
                isLevelPass = false;
                playerHealth.currentEnergy=200;
                playerHealth.currentHealth = 100;
            }
        }


    }


}
