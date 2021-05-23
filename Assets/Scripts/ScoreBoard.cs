using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Score[] scores;

	public void UpdateScore(string deadPlayerName)
	{
        foreach (Score score in scores)
		{
			if (score.GetPlayerName().Equals(deadPlayerName))
			{
				score.IsPlayerAlive = false;
				continue;
			}
            if (score.IsPlayerAlive)
			{
				score.UpdateScore();
			}
		}
	}
}
