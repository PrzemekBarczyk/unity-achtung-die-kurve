using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static bool PlayMusic { get; set; }
	public static bool PlaySound { get; set; }

	[Header("Players")]
	[SerializeField] PlayerData fred;
	[SerializeField] PlayerData greenlee;
	[SerializeField] PlayerData pinkey;
	[SerializeField] PlayerData bluebell;
	[SerializeField] PlayerData willem;
	[SerializeField] PlayerData greydon;

	static List<PlayerData> players = new List<PlayerData>();

	int leftAlivePlayersNumber;

	SceneManager sceneManager;

	void Start()
	{
		DontDestroyOnLoad(gameObject);

		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();

		players.Add(fred);
		players.Add(greenlee);
		players.Add(pinkey);
		players.Add(bluebell);
		players.Add(willem);
		players.Add(greydon);
	}

	void OnLevelWasLoaded(int level)
	{
		leftAlivePlayersNumber = players.Count;
		Pause();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (sceneManager.IsStartMenuSceneActive())
			{
				sceneManager.NextScene();
			}
			if (sceneManager.IsGameSceneActive())
			{
				Resume();
			}
		}
	}

	public static PlayerData GetPlayer(string name)
	{
		foreach (PlayerData player in players)
			if (player.Name.Equals(name)) return player;
		return null;
	}

	public static List<PlayerData> GetAllPlayers()
	{
		return players;
	}

	void Resume()
	{
		Time.timeScale = 1f;
	}

	void Pause()
	{
		Time.timeScale = 0f;
	}

	public void RestartGame()
	{
		leftAlivePlayersNumber--;
		if (leftAlivePlayersNumber <= 1) sceneManager.RestartScene();
	}
}
