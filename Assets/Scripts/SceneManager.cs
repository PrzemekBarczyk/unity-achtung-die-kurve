using UnityEngine;
using sm = UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void RestartScene()
	{
		sm.SceneManager.LoadScene(sm.SceneManager.GetActiveScene().buildIndex);
	}

	public void NextScene()
	{
		int currentSceneIndex = sm.SceneManager.GetActiveScene().buildIndex;
		sm.SceneManager.LoadScene(++currentSceneIndex);
	}

	public bool IsStartMenuSceneActive()
	{
		if (sm.SceneManager.GetActiveScene().buildIndex == 0) return true;
		return false;
	}

	public bool IsGameSceneActive()
	{
		if (sm.SceneManager.GetActiveScene().buildIndex == 1) return true;
		return false;
	}
}
