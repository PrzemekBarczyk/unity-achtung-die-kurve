using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] string playerName;
	PlayerData player;
    public bool IsPlayerAlive = true;

    [SerializeField] Text scoreText;

    int pointsForKill = 1;

	void Start()
	{
		player = GameManager.GetPlayer(playerName);
		scoreText.text = player.Score.ToString();
	}

	public string GetPlayerName()
	{
        return playerName;
	}

    public void UpdateScore()
	{
        player.Score += pointsForKill;
        scoreText.text = player.Score.ToString();
	}
}
