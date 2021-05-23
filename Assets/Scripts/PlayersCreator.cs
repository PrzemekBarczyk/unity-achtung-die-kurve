using System.Collections.Generic;
using UnityEngine;

public class PlayersCreator : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] GameObject botPrefab;

    List<GameObject> players = new List<GameObject>();

    void Start()
    {
        foreach (PlayerData player in GameManager.GetAllPlayers())
		{
            if (player.IsBot)
			{
                var newBot = Instantiate(botPrefab);
                newBot.GetComponentInChildren<Head>().Name = player.Name;
                newBot.GetComponentInChildren<LineRenderer>().material = player.Material;
                players.Add(newBot);
            }
			else
			{
                var newHuman = Instantiate(humanPrefab);
                newHuman.GetComponentInChildren<Head>().Name = player.Name;
                newHuman.GetComponentInChildren<LineRenderer>().material = player.Material;
                newHuman.GetComponentInChildren<Head>().LeftKey = player.LeftKey;
                newHuman.GetComponentInChildren<Head>().RightKey = player.RightKey;
                players.Add(newHuman);
            }
        }
    }

    public List<GameObject> GetAllPlayers()
	{
        return players;
	}
}
