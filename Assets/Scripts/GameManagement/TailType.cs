using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TailType : MonoBehaviour
{
	private GameObject player;
	private PlayerManager playerManager;
	private GameObject partSwapperObject;
	private SwapParts partSwapper;
	public string[] tails;
	public string currentTail;
	private string prevTail;
	public float metalDelay = .25f;

	/* the current tail should be able to be set
	*/

	// Use this for initialization
	void Start ()
	{
		partSwapperObject = (GameObject) GameObject.FindObjectOfType(typeof(SwapParts));
		partSwapper = partSwapperObject.GetComponent <SwapParts> ();
		tails = partSwapper.tailsArray;
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerManager = player.GetComponent <PlayerManager> ();
	}

	void selectType (string type)
	{
		if (tails.Contains(type))
		{
			currentTail = type;
			if (currentTail == "metal")
			{
				print("setting metal delay");
				try
				{
					playerManager.setLaunchDelay(metalDelay);
				}
				catch (Exception e)
				{
					print(e.Message);
				}
				print("after that");
			}
		}
		else
		{
			//not sure if hours print there
			print("tail type parameter given is not valid");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (prevTail != currentTail)
		{
			prevTail = currentTail;
			selectType("normal");
			selectType(prevTail);
		}
	}
}
