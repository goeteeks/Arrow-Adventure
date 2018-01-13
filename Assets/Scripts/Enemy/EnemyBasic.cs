using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour {

	[SerializeField] float health = 1;
	private SpriteRenderer sprite;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
		sprite = GetComponent <SpriteRenderer> ();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void giveDamage (float damagedAmount){
		health -= damagedAmount;
	}

}
