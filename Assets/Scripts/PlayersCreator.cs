using UnityEngine;

public class PlayersCreator : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] GameObject botPrefab;

    void Start()
    {
        foreach (PlayerData player in GameManager.GetAllPlayers())
		{
            if (player.IsBot)
			{
                Instantiate(botPrefab).GetComponentInChildren<LineRenderer>().material = player.Material;
            }
			else
			{
                var newPlayer = Instantiate(humanPrefab);
                newPlayer.GetComponentInChildren<LineRenderer>().material = player.Material;
                newPlayer.GetComponentInChildren<Head>().LeftKey = player.LeftKey;
                newPlayer.GetComponentInChildren<Head>().RightKey = player.RightKey;
            }
        }
    }
}
