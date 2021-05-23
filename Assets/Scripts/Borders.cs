using UnityEngine;

public class Borders : MonoBehaviour
{
	[SerializeField] Transform leftBorder;
	[SerializeField] Transform rightBorder;
	[SerializeField] Transform bottomBorder;
	[SerializeField] Transform topBorder;

	public float MinX()
	{
		return leftBorder.position.x;
	}

	public float MaxX()
	{
		return rightBorder.position.x;
	}

	public float MinY()
	{
		return bottomBorder.position.y;
	}

	public float MaxY()
	{
		return topBorder.position.y;
	}

	public void VoyageThroughVoid(Transform player)
	{
		if (player.position.x < MinX())
		{
			player.position = new Vector2(MaxX(), player.position.y);
			player.GetComponent<Head>().ChangeTail();
		}
		else if (player.position.x > MaxX())
		{
			player.position = new Vector2(MinX(), player.position.y);
			player.GetComponent<Head>().ChangeTail();
		}

		if (player.position.y < MinY())
		{
			player.position = new Vector2(player.position.x, MaxY());
			player.GetComponent<Head>().ChangeTail();
		}
		else if (player.position.y > MaxX())
		{
			player.position = new Vector2(player.position.x, MinY());
			player.GetComponent<Head>().ChangeTail();
		}
	}
}
