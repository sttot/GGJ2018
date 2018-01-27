using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour 
{
	static class InputCode
	{
		public const string Exit			= "EX";
		public const string Obstacle 		= "OB";
		public const string Robot 			= "RO";
		public const string Wall 			= "WL";
	}

	public GameObject Exit;
	public GameObject Floor;
	public GameObject Dissolver;
	public GameObject Wall;
	public GameObject Robot;

	GameObject goCurrentDissolver;

	Grid gGrid;
	GameObject goBotsStorage;

	List<string[,]> Levels = new List<string[,]>()
	{
		// TODO: reading from file
		// 10x10 grid
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
		// 10x10 grid
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
		}
	};
		
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
			goCurrentDissolver =  Instantiate(Dissolver, Vector3.zero, Quaternion.identity, gGrid.transform);

			for (int j = 0; j < iRowCount; j++) 
			{
				var v3Position = gGrid.trTiles [i, j];

				int iExitAmount = 0;
				if (CurrentLevel [i, j].Contains ("EX")) 
				{
					string sAmountInString = CurrentLevel [i, j];

					iExitAmount = int.Parse( sAmountInString.Remove (0, 2) );
					CurrentLevel [i, j] = "EX";

				}
				switch (CurrentLevel[i, j])
				{
					// Create an exit and set its size
					case InputCode.Exit:
						GameObject goExit = Instantiate (Exit, new Vector3 (v3Position.x, 1, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						goExit.GetComponent<ExitScript> ().SetBotsNeeded ( iExitAmount );
						break;
					// Create a wall
					case InputCode.Wall:
					Instantiate (Wall, new Vector3(v3Position.x, 1, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
						break;
					// Create both robot and the floor
					case InputCode.Robot:
						Instantiate (Robot, new Vector3 (v3Position.x, 1, v3Position.z), Quaternion.identity, goBotsStorage.transform);
						Instantiate (Floor, new Vector3(v3Position.x, 0, v3Position.z), Quaternion.identity, goCurrentDissolver.transform);
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
