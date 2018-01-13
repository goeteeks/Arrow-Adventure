using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour {
	//both of these are generated from the children of the Obstacle object
//	private List<GameObject> ObstacleList = new List<GameObject> ();
//	private Transform[] ObstacleTransformArray;
	// Use this for initialization
	void Start () {
//		ObstacleTransformArray = this.transform.GetComponentsInChildren<Transform> (true);
//		foreach (Transform tr in ObstacleTransformArray) {
//			ObstacleList.Add (tr.gameObject);
//		}
	}
	
	// Update is called once per frame
	void Update () {
//		for (GameObject g : ObstacleList) {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			print ("you lose");
			Lose ();
		} else {
			print ("that wasn't a player");
		}
	}

	void Lose() {
		//reload current scene
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
