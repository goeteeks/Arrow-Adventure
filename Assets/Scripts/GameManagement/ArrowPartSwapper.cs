using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrowPartSwapper : MonoBehaviour
{
	private GameObject player;
	private PlayerManager playerManager;
	private GameObject arrowPartsObject;
	private ArrowParts arrowParts;
	private enum parts {tail, body, tip}
	public string[] tails;
	public string[] bodies;
	public string[] tips;
	public string currentTail = "normal";
	public string currentBody = "normal";
	public string currentTip = "normal";
	private string prevTail;
	private string prevBody;
	private string prevTip;
	public float metalDelay = .25f;
	public float normalDelay = .5f;
	private int frameNum = 0;

	/* the current tail should be able to be set
	*/

	// Use this for initialization
	void Start ()
	{
		arrowPartsObject = GameObject.FindGameObjectWithTag("ArrowParts");
		arrowParts = arrowPartsObject.GetComponent <ArrowParts> ();
		tails = arrowParts.tailsArray;
		bodies = arrowParts.bodiesArray;
		tips = arrowParts.tipsArray;
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerManager = player.GetComponent <PlayerManager> ();
	}

	void selectTailType (string type)
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
			}
			else if (currentTail == "normal")
			{
				print("setting normal delay to: " + normalDelay);
				try
				{
					playerManager.setLaunchDelay(normalDelay);
				}
				catch (Exception e)
				{
					print(e.Message);
				}
			}
		}
		else
		{
			//not sure if hours print there
			print("tail type parameter given is not valid");
		}
	}
	
	void selectBodyType (string type)
	{
		if (bodies.Contains(type))
		{
			currentBody = type;
			if (currentBody == "metal")
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
			}
			else if (currentBody == "normal")
			{
				print("setting normal delay to: " + normalDelay);
				try
				{
					playerManager.setLaunchDelay(normalDelay);
				}
				catch (Exception e)
				{
					print(e.Message);
				}
			}
		}
		else
		{
			print("body type parameter given is not valid");
		}
	}
	
	void selectTipType (string type)
	{
		if (tips.Contains(type))
		{
			currentTip = type;
			if (currentTip == "metal")
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
			}
			else if (currentTip == "normal")
			{
				print("setting normal delay to: " + normalDelay);
				try
				{
					playerManager.setLaunchDelay(normalDelay);
				}
				catch (Exception e)
				{
					print(e.Message);
				}
			}
		}
		else
		{
			print("body type parameter given is not valid");
		}
	}
	
	// Update is called once per frame
	// alternates checking tail, body, tip
	void Update ()
	{
		frameNum = (frameNum + 1) % 3;
		print(frameNum);
		switch (frameNum)
		{
			case 0:
				if (prevTail != currentTail)
				{
					prevTail = currentTail;
					selectTailType(currentTail);
				}
				break;
			case 1:
				if (prevBody != currentBody)
				{
					prevBody = currentBody;
					selectBodyType(currentBody);
				}
				break;
			case 2:
				if (prevTip != currentTip)
				{
					prevTip = currentTip;
					selectTipType(currentTip);
				}
				break;
		}
	}
}
