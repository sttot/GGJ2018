using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	//Load the level with the selected value.
	public void LoadScene(int iLevel) 
	{
		GameMaster.instance.activeScene = (GameMaster.ActiveScene) iLevel;
		GameMaster.instance.SwapScenes();
	}

	public void LoadMainMenu() 
	{
		GameMaster.instance.activeScene = GameMaster.ActiveScene.MainMenu;
		GameMaster.instance.SwapScenes();
	}
}
