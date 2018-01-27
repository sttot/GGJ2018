using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScreenButtons : MonoBehaviour {

	public void BackToLevelSelect()
	{
		GameMaster.instance.activeScene = GameMaster.ActiveScene.LevelSelect;
		GameMaster.instance.SwapScenes();
	}

	public void RestartLevel() 
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}

	public void LoadNextNevel() 
	{
		GameMaster.ActiveScene eNextScene = GameMaster.instance.activeScene + 1;
		SceneManager.LoadScene( eNextScene.ToString() );
	}
}
