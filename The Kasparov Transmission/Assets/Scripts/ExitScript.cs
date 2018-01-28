using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	int NumberBotsReached = 0;
	int iNumberOfBotsNeeded;

	// Use this for initialization
	void Start () 
	{
		NumberBotsReached = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int NumToDisplay;

		if (iNumberOfBotsNeeded == 0) {
			NumToDisplay = 0;
		} else {
			NumToDisplay = (iNumberOfBotsNeeded - NumberBotsReached);
		}
		if(NumToDisplay==0){
			gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = null;
			iNumberOfBotsNeeded = 0; //This is here so that we do not end with a negative array index if one more
						//Robot passes through the gate.
		} else {
			gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = textures [NumToDisplay - 1];
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("" + other.gameObject.tag.ToString());
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.SetActive (false);
			NumberBotsReached++;
		}
	}

	public int GetNumberOfBotLeft()
	{
		int iNeededBots = iNumberOfBotsNeeded - NumberBotsReached;
		return ( iNeededBots ) < 0 ? 0 : iNeededBots;
	}

	public void SetBotsNeeded( int iNumberOfBots )
	{
		iNumberOfBotsNeeded = iNumberOfBots;
	}
}
