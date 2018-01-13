using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	public KeyCode keyPause = KeyCode.P;
	public string pauseScreenName = "PauseScreen";
	public float pauseDelay = .1f;
	public float gameSpeed = 1f;

	private float prevPauseTime = 0f;
	private GameObject pauseObj;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		this.pauseObj = this.gameObject.transform.Find (pauseScreenName).gameObject;
		this.pauseObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyPause)) {
			print ("pause pressed");
			print (pauseDelay);
			print (prevPauseTime);
			float pressTime = Time.unscaledTime;
			if (pressTime > (prevPauseTime + pauseDelay)) {
				this.pauseObj.SetActive (!pauseObj.activeSelf);
				Time.timeScale = (Time.timeScale == 0f ? gameSpeed : 0f);
				prevPauseTime = pressTime;
			}
		}
	}
}
