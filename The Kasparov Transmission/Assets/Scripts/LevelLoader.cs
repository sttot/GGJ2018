using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour 
{
	// TODO: reading from file
	// 10x10 grids
	List<string[,]> Levels = new List<string[,]>()
	{
		// Level1
		new string[,]
		{
			{"WL", "WL", "WL", "WL", "EX3", "EX3", "EX3", "WL", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "WL",  "WL",  "WL",  "WL", "WL", "WL", "WL", "WL"}
		},
		// Level2
		new string[,]
		{
			{"WL", "WL", "WL", "WL", "EX3", "EX3", "EX3", "WL", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ",  "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "WL",  "WL",  "WL",  "WL", "WL", "WL", "WL", "WL"}
		},
		// Level3
		new string[,]
		{
			{"WL", "WL", "WL", "WL", "WL", "EX3", "EX3", "WL", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "WL",  "WL",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "EX3"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "WL", "WL",  "WL",  "WL", "WL", "WL", "WL", "WL"}
		},
		// Level4 
		new string[,]
		{
			{"WL", "WL", "WL", "WL", "WL", "EX3", "EX3", "WL", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "  ", "HO",  "HO",  "HO", "  ", "WL", "WL", "WL"},
			{"WL", "WL", "WL", "  ", "HO",  "HO",  "HO", "  ", "WL", "WL", "WL"},
			{"WL", "WL", "WL", "  ", "HO",  "HO",  "HO", "  ", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "WL", "WL",  "EX3",  "WL", "WL", "WL", "WL", "WL"}
		},
		// Level5
		new string[,]
		{
			{"WL", "WL", "WL", "EX3", "WL", "EX3", "WL", "WL", "WL", "WL", "WL"},
			{"WL", "  ", "  ", "  ", "HO",  "  ",  "WL", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "HO",  "HO",  "HO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "HO",  "HO",  "HO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "HO",  "HO",  "HO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "EX3"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "RO",  "RO",  "RO", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{ "WL","  ", "  ", "  ", "  ",  "  ",  "  ", "  ", "  ", "  ", "WL"},
			{"WL", "WL", "WL", "WL", "WL",  "WL",  "WL", "WL", "WL", "WL", "WL"}
		},
		// Level6
		new string[,]
		{
			{ "WL",  "WL",  "WL", "WL", "WL",  "EX3",  "WL", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "WL",  "DS3",  "WL", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "HO",  "SW3",  "HO", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "HO",   "  ",  "HO", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "HO",   "  ",  "HO", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "HO",   "  ",  "HO", "WL",  "WL",  "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "WL",   "  ",  "WL", "WL",  "WL",  "WL",  "WL"},
			{"EX3", "DS1", "SW1", "  ", "  ",   "  ",  "  ", "  ", "SW2", "DS2", "EX3"},
			{ "WL",  "HO",  "HO", "WL", "  ",   "  ",  "  ", "WL",  "HO",  "HO",  "WL"},
			{ "WL",  "HO",  "HO", "WL", "RO",   "RO",  "RO", "WL",  "HO",  "HO",  "WL"},
			{ "WL",  "HO",  "HO", "  ", "RO",   "RO",  "RO", "  ",  "HO",  "HO",  "WL"},
			{ "WL",  "HO",  "HO", "  ", "RO",   "RO",  "RO", "  ",  "HO",  "HO",  "WL"},
			{ "WL",  "HO",  "HO", "  ", "  ",   "  ",  "  ", "  ",  "HO",  "HO",  "WL"},
			{ "WL",  "HO",  "HO", "  ", "  ",   "  ",  "  ", "  ",  "HO",  "HO",  "WL"},
			{ "WL",  "  ",  "  ", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "WL",   "WL",  "WL", "WL",  "WL",  "WL",  "WL"}
		},
		// Level7
		new string[,]
		{
			{ "WL",  "WL",  "WL", "EX3", "WL",  "WL",  "WL",  "WL", "WL", "WL",  "WL"},
			{ "WL",  "WL",  "WL",  "  ", "  ",  "  ",  "  ",  "WL", "WL", "WL",  "WL"},
			{ "WL",  "WL",  "WL",  "  ", "  ",  "  ",  "  ", "DS3", "  ", "  ", "EX3"},
			{ "WL",  "WL",  "WL",  "  ", "  ",  "  ",  "  ",  "WL", "WL", "WL",  "WL"},
			{ "WL",  "WL",  "WL",  "  ", "  ",  "  ",  "  ", "SW3", "WL", "WL",  "WL"},
			{ "WL",  "WL",  "WL", "DS2", "WL",   "WL",  "WL", "WL", "WL", "WL",  "WL"},
			{ "WL",  "  ",  "  ",  "  ", "  ",   "  ",  "WL", "WL", "WL", "WL",  "WL"},
			{ "WL",  "  ", "SW2",  "  ", "  ",   "  ",  "  ", "  ", "  ", "  ", "EX3"},
			{ "WL",  "  ",  "  ",  "  ", "  ",   "  ",  "  ", "  ", "WL", "WL",  "WL"},
			{ "WL",  "WL",  "WL", "WL", "WL",   "WL",  "WL", "DS1", "WL", "WL",  "WL"},
			{ "WL",  "RO",  "RO", "RO", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "RO",  "RO", "RO", "  ",   "  ",  "  ", "SW1",  "  ",  "  ","WL"},
			{ "WL",  "RO",  "RO", "RO", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "  ",  "  ", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "  ",  "  ", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "  ",  "  ", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "WL",  "WL", "WL", "WL",   "WL",  "WL", "WL",  "WL",  "WL", "WL"}
		},
		// Level8
		new string[,]
		{
			{ "WL",   "WL", "WL", "WL", "WL",  "EX3", "WL", "WL",  "WL", "EX3",  "WL"},
			{ "EX3",  "  ", "  ", "  ", "  ",   "  ",  "WL", "WL",  "  ",  "  ", "WL"},
			{ "WL",   "  ", "  ", "  ", "  ",   "  ",  "WL", "WL",  "  ",  "WL", "WL"},
			{ "WL",   "  ", "  ", "  ", "  ",   "  ",  "WL", "WL",  "  ",  "WL", "WL"},
			{ "WL",  "DS3", "WL", "  ", "  ",  "RD2",  "WL", "WL",  "  ",  "WL", "WL"},
			{ "WL",   "  ", "WL", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",   "  ", "WL", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",  "SW2", "WL", "  ", "  ",   "  ",  "  ", "  ",  "  ",  "  ", "WL"},
			{ "WL",   "  ", "HO", "HO", "WL",  "SW1",  "WL", "HO", "HO", "SW3",  "WL"},
			{ "WL",   "  ", "HO", "HO", "WL",   "  ",  "WL", "HO", "HO",  "  ",  "WL"},
			{ "WL",   "  ", "HO", "HO", "WL",   "  ",  "WL", "HO", "HO",  "  ",  "WL"},
			{ "WL",   "  ", "WL", "WL", "WL",   "RD1", "WL", "WL", "WL",  "  ",  "WL"},
			{ "WL",   "  ", "  ", "  ", "RO",   "RO",  "RO", "  ", "  ",  "  ",  "WL"},
			{ "WL",   "  ", "  ", "  ", "RO",   "RO",  "RO", "  ", "  ",  "  ",  "WL"},
			{ "WL",   "  ", "  ", "  ", "RO",   "RO",  "RO", "  ", "  ",  "  ",  "WL"},
			{ "WL",   "  ", "  ", "  ", "  ",   "  ",  "  ", "  ", "  ",  "  ",  "WL"},
			{ "WL",   "  ", "  ", "  ", "  ",   "  ",  "  ", "  ", "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",   "WL", "WL", "WL", "WL",   "WL",  "WL", "WL", "WL",  "WL",  "WL"}
		},
		// Level9
		new string[,]
		{
			{ "WL", "WL",  "WL", "WL", "WL", "EX9",  "WL",    "WL",  "WL",  "WL",  "WL"},
			{ "WL", "HO", "SW3", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "DS3", "DS3", "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "HO",  "HO",   "HO",  "  ",  "  ",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "HO",  "HO",   "HO",  "  ",  "  ",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "HO",  "HO",   "HO",  "  ",  "  ",  "WL"},
			{ "WL", "WL",  "WL", "  ", "WL",   "WL",  "WL",   "WL",  "  ",  "  ",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "  ",  "  ",  "RD2",  "  ",  "HO",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "  ",  "  ",  "RD2",  "  ",  "HO",  "WL"},
			{ "WL", "HO",  "  ", "  ", "  ",   "  ",  "  ",  "RD2",  "  ",  "HO",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ", "RD2",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",  "SW2", "RD2",   "  ",  "SW1", "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ", "RD2",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "WL",  "WL", "WL", "WL",   "WL",  "WL",  "DS1",  "  ", "DS1",  "WL"},
			{ "WL", "  ",  "  ", "  ", "RO",   "RO",  "RO",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "RO",   "RO",  "RO",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "RO",   "RO",  "RO",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "  ",  "  ", "  ", "  ",   "  ",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "WL",  "WL", "WL", "WL",   "WL",  "WL",   "WL",  "WL",  "WL",  "WL"}
		},
		// Level 10
		new string[,]
		{
			{  "WL", "WL",  "WL",  "WL",  "WL",   "WL",  "EX2",  "WL",  "WL",  "WL",  "WL"},
			{  "WL", "  ",  "  ",  "  ",  "HO",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "EX3", "  ",  "RD4","RD4",  "  ",   "WL",  "  ",   "  ",  "  ",  "  ", "EX4"},
			{ "WL",  "  ",   "  ", "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "DS4", "WL"},
			{ "WL",  "  ",   "  ", "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "HO",  "WL"},
			{ "WL",  "  ",   "  ", "  ",  "HO",   "WL",  "  ",   "  ",  "  ",  "HO",  "WL"},
			{ "WL",  "  ",   "  ", "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "HO",   "  ", "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "HO",   "  ", "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "HO",   "  ",  "  ", "  ",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ", "RD2","RD2",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "  ",   "WL", "RD3",  "RD3",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL", "SW2",   "  ",  "  ", "SW3",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL",  "  ",   "  ",  "  ", "WL",   "WL",  "  ",  "DS2", "DS2",  "WL",  "WL"},
			{ "WL", "DS1",  "DS1", "DS1", "WL",   "WL",  "RO",   "RO",  "RO",  "WL",  "WL"},
			{ "WL", "SW1",  "  ",  "  ", "RD1",  "RD1",  "RO",   "RO",  "RO",  "WL",  "WL"},
			{ "WL", "  ",   "  ",  "  ", "DS1",   "WL",  "RO",   "RO",  "RO",  "WL",  "WL"},
			{ "WL", "  ",   "  ",  "  ", "DS2",   "WL",  "WL",   "WL",  "WL",  "WL",  "WL"},
			{ "WL", "  ",   "  ",  "  ", "DS3",   "WL",  "WL",   "WL",  "WL",  "WL",  "WL"},
			{ "WL", "  ",   "  ",  "  ",  "  ",   "WL",  "  ",   "  ",  "  ",  "  ",  "WL"},
			{ "WL", "WL",   "WL",  "WL",  "WL",   "WL",  "WL",   "WL",  "WL",  "WL",  "WL"}
		}
	};


	static class InputCode
	{
		public const string Exit			= "EX";
		public const string Obstacle 		= "OB";
		public const string Robot 			= "RO";
		public const string Wall 			= "WL";
		public const string Hole			= "HO";
		public const string Door			= "DS";
		public const string ReverseDoor		= "RD";
		public const string Switch			= "SW";
	}

	public GameObject Exit;
	public GameObject Floor;
	public GameObject Wall;
	public GameObject Dissolver;
	public GameObject Robot;
	public GameObject Door;
	public GameObject Switch;

	GameObject goCurrentDissolver;

	Grid gGrid;
	GameObject goBotsStorage;


		
	void Awake()
	{
		gGrid = GameObject.FindGameObjectWithTag ("Pathing").GetComponent<Grid>();
		goBotsStorage = GameObject.Find ("Bots");

		LoadLevel( (int) GameMaster.instance.activeScene - 1 );
	}

	public void LoadLevel( int iCurrentLevel )
	{
		string[,] CurrentLevel = Levels[ iCurrentLevel ];

		int iColCount = CurrentLevel.GetLength (0);
		int iRowCount = CurrentLevel.GetLength (1);
				gGrid.CreateGrid (iColCount, iRowCount);

		for (int i = 0; i < iColCount; i++)
		{
			goCurrentDissolver = Instantiate (Dissolver, gGrid.transform);
			for (int j = 0; j < iRowCount; j++) 
			{
				var v3Position = gGrid.trTiles [j, i];

				int iNumber = 0;

				// Very bad code, change in future
				if (	CurrentLevel [i, j].Contains ("EX")
					||	CurrentLevel [i, j].Contains ("DS")
					|| 	CurrentLevel [i, j].Contains ("SW")
					|| 	CurrentLevel [i, j].Contains ("RD")
					) 
				{
					string sAmountInString = CurrentLevel [i, j];
					iNumber = int.Parse (sAmountInString.Remove (0, 2));
					CurrentLevel [i, j] = CurrentLevel [i, j].Substring(0, 2);
				} 


				switch (CurrentLevel[i, j])
				{
					// Create an exit and set its size
					case InputCode.Exit:
					GameObject goExit = Instantiate (Exit, new Vector3 (v3Position.x, 1.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						goExit.GetComponent<ExitScript> ().SetBotsNeeded ( iNumber );
						break;

					// Create a wall
					case InputCode.Wall:
						Instantiate (Wall, new Vector3(v3Position.x, 1.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;

					// Create both robot and the floor
					case InputCode.Robot:
						Instantiate (Robot, new Vector3 (v3Position.x, 0.5f, v3Position.z), Quaternion.identity, goBotsStorage.transform);
						Instantiate (Floor, new Vector3(v3Position.x, 0.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;


					// Create door
					case InputCode.Door:
						var goDoor = Instantiate (Door, new Vector3 (v3Position.x, 1.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						goDoor.GetComponent<Door> ().iKey = iNumber;
						Instantiate (Floor, new Vector3(v3Position.x, 0.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;

					// Create Reverse
					case InputCode.ReverseDoor:
					var goReverseDoor = Instantiate (Door, new Vector3 (v3Position.x, 0.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						goReverseDoor.GetComponent<Door> ().iKey = iNumber;
						goReverseDoor.GetComponent<Door> ().bIsReverse = true;
						Instantiate (Floor, new Vector3(v3Position.x, 0.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;

					// Create switch
					case InputCode.Switch:
						var goSwitch = Instantiate (Switch, new Vector3 (v3Position.x, 0.5f, v3Position.z), Quaternion.identity, gGrid.transform);
						goSwitch.GetComponent<Switch> ().iKey = iNumber;
						Instantiate (Floor, new Vector3(v3Position.x, 0.0f, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;

					// Create hole
					case InputCode.Hole:
						break;

					// Create a floor
					default:
						Instantiate (Floor, new Vector3(v3Position.x, 0, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;
				}



			}
		}
	}
}
