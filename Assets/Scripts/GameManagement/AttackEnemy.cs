using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {
	GameObject player;
	PlayerManager playerManager;
	[SerializeField] float attack = 1;
	Rigidbody2D a_rigidbody;
	Animator a_anim;

	[SerializeField] bool hasIdled = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerManager = player.GetComponent <PlayerManager> ();
		a_rigidbody = player.GetComponent <Rigidbody2D> ();
		a_anim = GetComponentInParent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col){ 
		if (col.gameObject.tag == "Enemy") {
			EnemyBasic challenger = col.gameObject.GetComponent <EnemyBasic> ();
			if (playerManager.fastEnough ()) {
				challenger.giveDamage (attack);
			}
		}
		if (col.gameObject.tag == "Stick") {
			a_rigidbody.isKinematic = true;
			a_rigidbody.simulated = false;
			if (!hasIdled) {
				a_anim.Play ("Idle");
				a_anim.SetBool ("IsCharging", false);
				a_anim.SetBool ("HasFired", false);
				hasIdled = true;
			}
		}
	}

	public void setHasIdled (bool idle){
		hasIdled = idle;
	}
}
