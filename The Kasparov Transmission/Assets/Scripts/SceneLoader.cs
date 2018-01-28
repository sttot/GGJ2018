using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
	private WaitForEndOfFrame mWaitForEndOfFrame;

	public bool Loading { get; private set; }

	void Awake()
	{
		mWaitForEndOfFrame = new WaitForEndOfFrame();
        Loading = true;
		DontDestroyOnLoad(transform.gameObject);
		LoadInitialScene();
    }

	public void StartLoadNewCoroutine() 
	{
		StartCoroutine(LoadNewScene());
	}

	private void LoadInitialScene() 
	{
		SceneManager.LoadScene("MainMenu");
	}

	private IEnumerator LoadNewScene() 
	{
		Loading = true;
		string sceneName = GameMaster.instance.activeScene.ToString();

		AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		if( ao != null ) 
		{
			while(!ao.isDone) 
			{
				yield return mWaitForEndOfFrame;
			}
		}
		yield return mWaitForEndOfFrame;
		Loading = false;
	}
}
