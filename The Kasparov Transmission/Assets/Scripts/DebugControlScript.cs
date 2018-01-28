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
		int iArrayIndex = (int) GameMaster.instance.activeScene - 1;
		GameMaster.instance.GameSessionData.LevelsComplete[ iArrayIndex ] = true;
		GameObject goScreenGroup = FindObject( "ScreenContainer", "WinScreen" );
		goScreenGroup.SetActive( true );
	}

	public void LoseGame() 
	{
		GameObject goScreenGroup = FindObject( "ScreenContainer", "RetryScreen" );
		goScreenGroup.SetActive( true );
	}

	public static GameObject FindObject( string strParentName, string strChildName )
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
