using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControlScript : MonoBehaviour {

	public void BackToLevelSelect() 
	{
		GameMaster.instance.activeScene = GameMaster.ActiveScene.LevelSelect;
		GameMaster.instance.SwapScenes();
	}

	public void WinGame() 
	{
		
	}

	public void LoseGame() 
	{
		
	}
}
