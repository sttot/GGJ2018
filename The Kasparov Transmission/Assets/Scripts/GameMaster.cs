using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameMaster : MonoBehaviour {

	//Global access instance.
	public static GameMaster instance;

	//Enum of what scenes are currently active.
	public enum ActiveScene 
	{
		MainMenu = -1,
		LevelSelect = 0,
		GameLevel_1 = 1,
		GameLevel_2 = 2,
		GameLevel_3 = 3,
		GameLevel_4 = 4,
		GameLevel_5 = 5,
		GameLevel_6 = 6,
		GameLevel_7 = 7,
		GameLevel_8 = 8,
		GameLevel_9 = 9,
		GameLevel_10 = 10
	};

	[HideInInspector]
	public ActiveScene activeScene;

	[HideInInspector]
	public bool playTutorial;

	[HideInInspector]
	public bool MainMenuSelectionReturn = false;

	//Data the game loads from file and used by other parts of the game.
	[HideInInspector]
	public GameSessionInfo GameSessionData { get; private set; }

	[SerializeField]
	private SceneLoader Loader;

	private void InstantiateSessionData() 
	{
		GameSessionData = new GameSessionInfo();
		GameSessionData.Instantiate();
		//LoadData();
	}

	void Awake() 
	{
		InstantiateSessionData();
		activeScene = ActiveScene.MainMenu;
		instance = this;
	}

	public void SwapScenes() 
	{
		Loader.StartLoadNewCoroutine();
	}

	public void SaveData( ref GameSessionInfo sDataToSave ) 
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerHighscores.dat");
		PlayerData data = new PlayerData();
		
		//Set PlayerData to be saved to file from GameSessionInfo.
		data.LastSavedSession = GameSessionData;

		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadData() 
	{
		if(File.Exists(Application.persistentDataPath + "/playerHighscores.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerHighscores.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			//Get data from PlayerData and store it.
			GameSessionData = data.LastSavedSession;
		}
	}
}

//Simple data holding class for menu population and highscore tracking.
public struct GameSessionInfo 
{
	public bool[] LevelsComplete;
	public int[] LevelScores;

	public void Instantiate() 
	{
		LevelsComplete = new bool[10];
		LevelScores = new int[10];
	}
}

//Savedata format class.
[Serializable]
struct PlayerData 
{
	//Add what data to be saved / loaded by filesystem here.
	public GameSessionInfo LastSavedSession;
}
