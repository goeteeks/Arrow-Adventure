using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapParts : MonoBehaviour {

	private List<string> parts = new List<string>();

	private string[] partsList;

	private string curPart;

	private PlayerManager pm;
	private Image imagePart;
	private int currentIndex = 0;

	[SerializeField] private Button upButton;
	[SerializeField] private Button downButton;

	// Use this for initialization
	void Start () {
		parts.Add ("normal");
		parts.Add ("wood");
		parts.Add ("metal");

		partsList = parts.ToArray ();

		curPart = partsList [currentIndex];

		imagePart = GetComponent <Image> ();

		pm = GameObject.FindWithTag ("Player").GetComponent <PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void swapPart (int index){
		if (index >= partsList.Length) {
			Debug.LogError ("Given index is out of range!");
		} else if (index < 0) {
			Debug.LogError ("Given Index cannot be negative!");
		} else {
			curPart = partsList [index];
			changePart (curPart);
			currentIndex = index;
		}
	}

	void changePart (string part){
		switch (part) {
		case "normal":
			imagePart.color = new Color (1.0f, 1.0f, 1.0f);
			break;
		case "wood":
			imagePart.color = new Color (0.18f, 0.09f, 0.0f);
			break;
		case "metal":
			imagePart.color = new Color (0.75f, 0.75f, 0.75f);
			break;
		default:
			Debug.LogError ("Not a known part type: " + part);
			break;
		}
	}

	public void incrementPart (){
		currentIndex++;
		//Handle wrapping
		if (currentIndex >= partsList.Length) {
			currentIndex = 0;
		}
		swapPart (currentIndex);
	}

	public void decrementPart (){
		currentIndex--;
		//Handle wrapping
		if (currentIndex < 0) {
			currentIndex = partsList.Length - 1;
		}
		swapPart (currentIndex);
	}
}
