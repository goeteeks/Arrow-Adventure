using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapParts : MonoBehaviour {

	private List<string> bodies = new List<string>();
	private List<string> tips = new List<string>();
	private List<string> tails = new List<string>();

	private string[] bodiesArray;
	private string[] tipsArray;
	private string[] tailsArray;

	private string curBody;
	private string curTip;
	private string curTail;

	private PlayerManager pm;

	// Use this for initialization
	void Start () {
		bodies.Add ("normal");
		bodies.Add ("wood");
		bodies.Add ("metal");

		tips.Add ("normal");
		tips.Add ("wood");
		tips.Add ("metal");

		tails.Add ("normal");
		tails.Add ("wood");
		tails.Add ("metal");

		bodiesArray = bodies.ToArray ();
		tipsArray = tips.ToArray ();
		tailsArray = tails.ToArray ();

		curBody = bodiesArray [0];
		curTip = tipsArray [0];
		curTail = tailsArray [0];

		pm = GameObject.FindWithTag ("Player").GetComponent <PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void swapPart (string[] partsList, int index){
		if (index > partsList.Length) {
			Debug.LogError ("Given index is out of range!");
		} else if (index < 0) {
			Debug.LogError ("Given Index cannot be negative!");
		} else {
			
		}
	}
}
