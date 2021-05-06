using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
	int leftAlivePlayersNumber;

	SceneManager sceneManager;

	void Start()
	{
		Pause();
		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
		leftAlivePlayersNumber = players.Length;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) Resume();
	}

	void Resume()
	{
		Time.timeScale = 1f;
	}

	void Pause()
	{
		Time.timeScale = 0f;
	}

	public void RestartLevel()
	{
		leftAlivePlayersNumber--;
		if (leftAlivePlayersNumber <= 1) sceneManager.RestartLevel();
	}
}
