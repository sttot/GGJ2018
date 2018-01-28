using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	//Load the level with the selected value.
	public void LoadScene(int iLevel) 
	{
		gameObject.GetComponents<AudioSource> ()[0].Play ();

		GameMaster.instance.activeScene = (GameMaster.ActiveScene) iLevel;
		GameMaster.instance.SwapScenes();
	}

	public void LoadMainMenu() 
	{
		gameObject.GetComponents<AudioSource> ()[1].Play ();

		GameMaster.instance.activeScene = GameMaster.ActiveScene.MainMenu;
		GameMaster.instance.SwapScenes();
	}
}
