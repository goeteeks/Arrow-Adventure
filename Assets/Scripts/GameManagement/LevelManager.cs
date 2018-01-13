using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	private GameObject player;
	private PlayerManager playerManager;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerManager = player.GetComponent <PlayerManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
