using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {
	private GameObject player;
	private PlayerManager playerManager;
	[SerializeField] float damageToGive;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerManager = player.GetComponent <PlayerManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Body" || col.name == "Tip"){
			if (!playerManager.getDamaged () && (!playerManager.fastEnough () || transform.tag == "InstantKill")) {
				playerManager.receiveDamage (damageToGive);
				playerManager.setDamaged (true);
				playerManager.StartCoroutine ("startInvincible");
			}
		}
	}


}
