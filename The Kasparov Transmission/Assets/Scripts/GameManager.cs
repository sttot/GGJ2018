using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Please make sure all exits are added here
	public int NumberOfBotsToExit = 1;

	public GameObject[] Exits;
	public GameObject[] TileGoupsInOrderOfDissolve;

	int NumOfTIleGroups = 0;
	int CurrentDissolvingGroup = 0;

	// Use this for initialization
	void Start () {
		NumOfTIleGroups = TileGoupsInOrderOfDissolve.Length;
		CurrentDissolvingGroup = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int totalbots = 0;
		for(int i=0;i<Exits.Length;i++){
			totalbots += Exits [i].GetComponent<ExitScript> ().GetNumberOfBothsReachedTheExit();
		}

		if (totalbots >= NumberOfBotsToExit) {
			LevelWon ();
			return;
		}

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

	void LevelWon(){
		Debug.Log ("Level Complete");
	}

	void LevelLose(){
		Debug.Log ("Game Over");
	}
}
