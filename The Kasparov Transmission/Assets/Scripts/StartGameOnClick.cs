using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOnClick : MonoBehaviour {

	public void OpenLevelSelect() 
	{
		GameMaster.instance.activeScene = GameMaster.ActiveScene.LevelSelect;
		Debug.Log("Next Scene: " + GameMaster.instance.activeScene );
		GameMaster.instance.SwapScenes();
	}
}
