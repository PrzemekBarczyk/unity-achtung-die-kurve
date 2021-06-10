using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	[SerializeField] Text[] names;
	[SerializeField] Text[] scores;

	List<PlayerData> playersWithData;

	void Start()
	{
		playersWithData = GameManager.GetAllPlayers();

		UpdateScoreBoard();
	}

	public void UpdateScores(string deadPlayerName)
	{
		UpdatePlayersData(deadPlayerName);
		SortPlayersData();
		UpdateScoreBoard();
	}

	void UpdatePlayersData(string deadPlayerName)
	{
		foreach (PlayerData playerData in playersWithData)
		{
			if (playerData.Name.Equals(deadPlayerName))
			{
				playerData.IsAlive = false;
				continue;
			}
			else if (playerData.IsAlive)
			{
				playerData.Score += 1;
			}
		}
	}

	void SortPlayersData()
	{
		for (int i = 0; i < playersWithData.Count; i++)
			for (int j = i + 1; j < playersWithData.Count; j++)
				if (playersWithData[j].Score > playersWithData[i].Score)
				{
					var tmp = playersWithData[i];
					playersWithData[i] = playersWithData[j];
					playersWithData[j] = tmp;
				}
	}

	void UpdateScoreBoard()
	{
		for (int i = 0; i < playersWithData.Count; i++)
		{
			names[i].text = playersWithData[i].Name;
			names[i].color = playersWithData[i].Material.color;
			scores[i].text = playersWithData[i].Score.ToString();
			scores[i].color = playersWithData[i].Material.color;
		}
	}
}
