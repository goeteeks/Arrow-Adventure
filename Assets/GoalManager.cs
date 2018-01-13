using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Body") {
			print ("you win");
			PlayerWin ();
		} else {
			print ("that wasn't a player");
		}
	}

	void PlayerWin() {
		//trigger win animation/effect
		//Put to next level, or put up a win screen they have to click 'okay' on
		SceneManager.LoadScene("Menu1");
	}
}
