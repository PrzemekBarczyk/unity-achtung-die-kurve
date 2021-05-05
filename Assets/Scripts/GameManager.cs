using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
	int leftAlivePlayersNumber;

	SceneManager sceneManager;

	void Start()
	{
		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
		leftAlivePlayersNumber = players.Length;
	}

	public void RestartLevel()
	{
		leftAlivePlayersNumber--;
		if (leftAlivePlayersNumber <= 1) sceneManager.RestartLevel();
	}
}
