using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour 
{
	public enum ME_Enum{
		Idle,
		Move,
		MoveBack,
		Attack,
		Die
	}

	private GameObject stork;
	public float atkSpeed;
	public const float MOVE_TOWARD_SPEED = 0.8f;
	public const float ATTACK_MOVE_SPEED = 10;
	public const float MOVE_BACK_SPEED = 3;
	public const float ATTACK_DISTENCE = 20;
	public const int PLAYER_BULLET_DAMAGE = -20;
	public const float ATTACK_RANGE = 5;
	private ME_Enum currState;
	public int hp = 100;
	private float attackFlag;
	private Vector3 oriPosition;
	public Animator enemyAnimator;
	private bool attackForward;

	public void setState(ME_Enum newState){
		currState = newState;
		switch (newState) {
		case ME_Enum.Idle:
			//enemyAnimator.SetInteger ("enemyMotion", 0);
			//print(enemyAnimator.GetInteger ("enemyMotion"));
			break;
		case ME_Enum.Move:
			//enemyAnimator.SetInteger ("enemyMotion", 1);
		//	print(enemyAnimator.GetInteger ("enemyMotion"));
			break;
		case ME_Enum.MoveBack:
			//enemyAnimator.SetInteger ("enemyMotion", 1);
		//	print(enemyAnimator.GetInteger ("enemyMotion"));
			break;
		case ME_Enum.Attack:
			//enemyAnimator.SetInteger ("enemyMotion", 2);
		//	print(enemyAnimator.GetInteger ("enemyMotion"));
			break;
		}
	}

	void Start(){
		stork = GameObject.Find ("stork");
		oriPosition = transform.position;
		currState = ME_Enum.Idle;
	}

	public void Update(){
		switch (currState) {
		case ME_Enum.Idle:
			DoIdle ();
			break;
		case ME_Enum.Move:
			DoMove ();
			break;
		case ME_Enum.MoveBack:
			DoMoveBack ();
			break;
		case ME_Enum.Attack:
			DoAttack ();
			break;
		case ME_Enum.Die:
			DoDie ();
			break;
		}
	}

	void DoIdle(){
		transform.Rotate(Vector3.up*Time.deltaTime*45);
		if (Vector3.Distance (transform.position, stork.transform.position) <= ATTACK_DISTENCE) {
			setState (ME_Enum.Move);
			//transform.Rotate(Vector3.right*Time.deltaTime);
			//Rigidbody rigidBody = GetComponent<Rigidbody> ();
			//rigidBody.velocity = transform.forward * 20;
		}
	}

	void DoMove(){
		if (Vector3.Distance (oriPosition, stork.transform.position) > ATTACK_DISTENCE) {
			setState (ME_Enum.MoveBack);
		}
		if (Vector3.Distance (transform.position, stork.transform.position) <= ATTACK_RANGE) {
			setState (ME_Enum.Attack);
			attackForward = true;
			//attackFlag = Time.time;
		}
		transform.LookAt(stork.transform);
		transform.Translate ((stork.transform.position-transform.position) * Time.deltaTime * MOVE_TOWARD_SPEED, Space.World);
	}

	void DoMoveBack(){
		// need to add a translate to Move state
		if (Vector3.Distance (oriPosition, transform.position) > 0.5) {
			transform.LookAt(oriPosition);
			transform.Translate ((oriPosition - transform.position) * Time.deltaTime * MOVE_BACK_SPEED, Space.World);
		} else {
			transform.rotation = Quaternion.identity;
			setState (ME_Enum.Idle);
		}
	}

	void DoAttack(){
		if (Vector3.Distance (oriPosition, stork.transform.position) > ATTACK_DISTENCE) {
			setState (ME_Enum.MoveBack);
		}
		/*if (Time.time-attackFlag<(0.5/atkSpeed)) {
			transform.LookAt(stork.transform);
			transform.Translate (stork.transform.position * Time.deltaTime * -ATTACK_MOVE_SPEED);
		} else {
			transform.LookAt(stork.transform);
			transform.Translate (stork.transform.position * Time.deltaTime * ATTACK_MOVE_SPEED);
		}*/
		if (attackForward == true) {
			print ("forward");
			transform.LookAt (stork.transform);
			transform.Translate ((stork.transform.position-transform.position) * Time.deltaTime * (ATTACK_MOVE_SPEED/Vector3.Distance (transform.position, stork.transform.position)), Space.World);
			//if (Vector3.Distance (transform.position, stork.transform.position) <=0.5)
				//attackForward = false;
		} else if (attackForward == false) {
			print ("backward");
			transform.LookAt (stork.transform);
			transform.Translate ((stork.transform.position-transform.position) * Time.deltaTime * -(ATTACK_MOVE_SPEED/Vector3.Distance (transform.position, stork.transform.position)), Space.World);
			if (Vector3.Distance (transform.position, stork.transform.position) >=5)
				attackForward = true;
		}
	}

	void DoDie(){
		Destroy (gameObject);
	}

	/*void OnCollisionEnter(Collision other){
		if (currState == ME_Enum.Attack) {
			attackForward = false;
		}
	}*/

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "playerbullet"){
            hp -=20;
            Destroy(other.gameObject);
            if (hp <= 0) setState(ME_Enum.Die);
        }
        if(other.gameObject.tag=="Airplane")
        {
            if (currState == ME_Enum.Attack)
            {
                attackForward = false;
            }
        }
	}

	void UpdateHP(int num){
		hp += num;
		if(hp <= 0) setState(ME_Enum.Die);
	}
}
