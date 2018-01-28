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

	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3 (0, -0.5f, 0);
	
		TileGoupsInOrderOfDissolve = GameObject.FindGameObjectsWithTag("Dissolver"); 
		TileGoupsInOrderOfDissolve = Reverse (TileGoupsInOrderOfDissolve);

		NumOfTIleGroups = TileGoupsInOrderOfDissolve.Length;
		CurrentDissolvingGroup = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int totalbots = 0;
		for(int i=0;i<Exits.Length;i++)
		{
			totalbots += Exits [i].GetComponent<ExitScript> ().GetNumberOfBothsReachedTheExit();
		}

		if (totalbots >= NumberOfBotsToExit) 
		{
			LevelWon ();
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

	void LevelWon(){
		Debug.Log ("Level Complete");
	}

	void LevelLose(){
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

}
