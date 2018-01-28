using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Please make sure all exits are added here
	public int NumberOfBotsToExit = 1;
	public float TimeBeforeDissolve = 5.0f;

	public GameObject[] Exits;
	public GameObject[] TileGoupsInOrderOfDissolve;

	int NumOfTIleGroups = 0;
	int CurrentDissolvingGroup = 0;
	bool bGameWon = false;

	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3 (0, -0.5f, 0);
	
		TileGoupsInOrderOfDissolve = GameObject.FindGameObjectsWithTag("Dissolver"); 
		TileGoupsInOrderOfDissolve = Reverse (TileGoupsInOrderOfDissolve);

		Exits = GameObject.FindGameObjectsWithTag("Exit"); 
		NumOfTIleGroups = TileGoupsInOrderOfDissolve.Length;
		CurrentDissolvingGroup = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bGameWon) 
		{
			return;
		}

		int totalbots = 0;
		for(int i=0;i<Exits.Length;i++)
		{
			totalbots += Exits [i].GetComponent<ExitScript> ().GetNumberOfBotLeft();
		}

		if (totalbots == 0) 
		{
			bGameWon = true;
			WinGame ();

			return;
		}


		if (TimeBeforeDissolve <= 0.0f) {
			
			if (CurrentDissolvingGroup >= NumOfTIleGroups) {
				LevelLose ();
				return;
			}

			if (!TileGoupsInOrderOfDissolve [CurrentDissolvingGroup].GetComponent<Dissolve> ().IsDissolving ()) {
				TileGoupsInOrderOfDissolve [CurrentDissolvingGroup].GetComponent<Dissolve> ().TriggerDissolve ();
			}

			if (TileGoupsInOrderOfDissolve [CurrentDissolvingGroup].GetComponent<Dissolve> ().IsDissolveDone ()) {
				CurrentDissolvingGroup++;
			}
		} 
		else 
		{
			TimeBeforeDissolve -= Time.deltaTime;
		}
	}

	void LevelWon()
	{
		Debug.Log ("Level Complete");
	}

	void LevelLose()
	{
//		Debug.Log ("Game Over");
	}

	GameObject[] Reverse(GameObject[] array)
	{
		var newArray = new GameObject [array.Length];

		for (int i = 0; i < array.Length; i++) 
		{
			newArray [array.Length - i - 1] = array [i];
		}
		return newArray;
	}

	void WinGame() 
	{
		// Pop up UI
		int iArrayIndex = (int) GameMaster.instance.activeScene - 1;
		GameMaster.instance.GameSessionData.LevelsComplete[ iArrayIndex ] = true;
		GameObject goScreenGroup = FindObject( "ScreenContainer", "WinScreen" );
		goScreenGroup.SetActive( true );

	}

	GameObject FindObject( string strParentName, string strChildName )
	{
		Transform[] trs = GameObject.Find(strParentName).GetComponentsInChildren<Transform>( true );
		foreach ( Transform t in trs )
		{
			if ( t.name == strChildName )
			{
				return t.gameObject;
			}
		}
		return null;
	}
}
