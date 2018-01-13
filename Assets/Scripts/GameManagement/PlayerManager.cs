using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
	//public GameObject arrow;
	public float speed = 5.0f; //Power of the arrow based on the bow's drawback range
	[SerializeField] float thrust = 1.5f; //Extra push for the arrow
	[SerializeField] float launchDelay = 0.5f;
	private float gameSpeed = 1f;
	private float prevLaunchTime = 0f;
	private Quaternion curRotation;
	private Rigidbody2D m_rigidbody;
	LevelManager lm;
	[SerializeField] bool falling = true;
	private Animator m_anim;
	[SerializeField] float maxHealth = 3;
	[SerializeField] float health = 3;
	[SerializeField] bool hasDied = false;
	[SerializeField] bool damaged = false;
	[SerializeField] bool canMove = false;

	public Slider healthSlider;

	AttackEnemy a_Tip;


	Vector2 target;
	Vector2 myPos;
	Vector2 direction;
	Vector2 startPosition;

	// Use this for initialization
	void Start () {
		this.m_rigidbody = GetComponent <Rigidbody2D> ();
		m_anim = GetComponent <Animator> ();
		health = maxHealth;
		healthSlider.maxValue = maxHealth;
		healthSlider.value = health;
		lm = GameObject.FindObjectOfType<LevelManager> ();
		startPosition = (Vector2) transform.position;
		canMove = true;
		a_Tip = GetComponentInChildren <AttackEnemy> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)){
			speed = 0;
			m_anim.SetBool ("HasFired", false);
			canMove = true;
		}
		if (Input.GetMouseButton(0)) {
			if (canMove) {
				m_anim.SetBool ("IsCharging", true);
				target = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
				myPos = new Vector2 (transform.position.x, transform.position.y);
				direction = myPos - target;
				direction.Normalize ();
				Quaternion rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg);
				transform.rotation = rotation;
				if (m_rigidbody.velocity.magnitude == 0) {
					m_rigidbody.isKinematic = true;
					m_rigidbody.simulated = false;
				}
			}
		}
			

		if (Input.GetMouseButtonUp (0) && canMove) {
			m_rigidbody.isKinematic = false;
			m_rigidbody.simulated = true;
			m_anim.SetBool ("IsCharging", false);
			m_anim.SetBool ("HasFired", true);
			a_Tip.setHasIdled (false);
			float launchedTime = Time.unscaledTime;
			if (launchedTime > (prevLaunchTime + launchDelay)) {	
				m_rigidbody.velocity = direction * speed * thrust;
				falling = false;
				//Time.timeScale = (Time.timeScale == 0f ? gameSpeed : 0f);
				prevLaunchTime = launchedTime;
			}
		}

		if (m_rigidbody.velocity.y < -0.5 && !falling) {
			//transform.rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( transform.position.y, transform.position.x ) * Mathf.Rad2Deg -90);
			m_rigidbody.freezeRotation = false;
			falling = true;
			m_anim.SetTrigger ("Falling");
			//m_anim.SetBool ("HasFired", false);
		} else {
			m_rigidbody.freezeRotation = true;
		}

		if (!Input.GetMouseButton (0) && m_rigidbody.velocity.magnitude > .4 ) {
//			transform.rotation = Quaternion.LookRotation (m_rigidbody.velocity);
//			print ( "in the no button down bit" );
			// y veloc / x veloc
			transform.eulerAngles = new Vector3 (0, 0, (Mathf.Atan2 (m_rigidbody.velocity.y, m_rigidbody.velocity.x ) * Mathf.Rad2Deg));
		}
		if (health <= 0 || transform.position.y < -20) {
			//hasDied = true;
			death ();
		}

		//print (m_rigidbody.velocity);
	}

	public void receiveDamage (float damageReceived){
		health -= damageReceived;
		healthSlider.value = health;
	}

	public void death(){
		canMove = false;
		respawnPlayer ();
	}

	public void respawnPlayer(){
		health = maxHealth;
		healthSlider.value = health;
		transform.position = startPosition;
		damaged = false;
		transform.rotation = new Quaternion (0, 0, 0, 0);
		m_anim.Play ("Idle");
		m_rigidbody.velocity = new Vector2 (0f, 0f);
		m_anim.SetBool ("HasFired", false);
		m_anim.SetBool ("IsCharging", false);
		m_anim.SetBool ("isInvincible", false);
		speed = 0;
		falling = false;
	}



	public void chargeUp (float chargeAmount){
		speed = chargeAmount;
	}

	public void fullyCharged (){
		m_anim.SetBool ("IsCharging", false);
	}

	public void hasNoLongerFired(){
		m_anim.SetBool ("HasFired", false);
	}

	void OnTriggerExit2D (Collider2D col){
	}

	public IEnumerator invincible (){
		m_anim.SetBool ("isInvincible", true);
		yield return new WaitForSeconds (2);
		damaged = false;
		m_anim.SetBool ("isInvincible", false);
	}

	public void startInvincible(){
		StartCoroutine ("invincible");
	}

	public bool fastEnough (){
		if ((m_rigidbody.velocity.x >= -6 && m_rigidbody.velocity.x <= 6) && (m_rigidbody.velocity.y >= -6 && m_rigidbody.velocity.y <= 6)) {
			return false;
		} else {
			return true;
		}

	}



	public float Health {
		get {
			return health;
		}
		set { 
			health = value; 
		}
	}

	public bool HasDied {
		get {
			return hasDied;
		}
		set {
			hasDied = value;
		}
	}

	public void setDamaged(bool boo) {
		damaged = boo;
	}

	public bool getDamaged(){
		return damaged;
	}
}