﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour 
{
	/// <summary>
	/// Attach this to each row of tiles
	/// As time goes on, it changes the colour of the tiles in a row slowly to black, 
	/// and when done, it will turn them to holes
	/// </summary>

	public const float TimeToDissolveSecs = 10.0f;

	TileControl[] children;
	public bool DissolveRowTrigerred = false;
	bool DissolveDone = false;
	public float currentTime = 0;


	// Use this for initialization
	void Start () 
	{
		children = GetComponentsInChildren<TileControl> ();
		//DissolveRowTrigerred = false;
	}

	public void TriggerDissolve()
	{
		if (!DissolveDone) 
		{
			DissolveRowTrigerred = true;
			DissolveDone = false;
		}

	}

	public bool IsDissolving()
	{
		return DissolveRowTrigerred;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (DissolveRowTrigerred) 
		{
			currentTime += Time.deltaTime;
			float red = ( (218.0f/255.0f) * ((TimeToDissolveSecs-currentTime) / TimeToDissolveSecs) );
			if (red < 0) 
			{
				red = 0.0f;
			}
			for (int i = 0; i < children.Length; i++) 
			{
				children [i].SetColor (new Color ( red , 0.0f, 0.0f) );
			}
			DissolveDone = currentTime >= TimeToDissolveSecs;
			if (DissolveDone) 
			{
				DissolveRowTrigerred = false;
				for (int i = 0; i < children.Length; i++) 
				{
					children [i].MakeHole ();
				}
			}
		}
	}

	public bool IsDissolveDone()
	{
		return DissolveDone;
	}
}
