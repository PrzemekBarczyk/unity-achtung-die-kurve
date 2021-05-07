using UnityEngine;

public class Window : MonoBehaviour
{
    public static float MinX()
	{
		return Camera.main.ScreenToWorldPoint(Vector2.zero).x;
	}

	public static float MaxX()
	{
		return Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0f)).x;
	}

	public static float MinY()
	{
		return Camera.main.ScreenToWorldPoint(Vector2.zero).y;
	}

	public static float MaxY()
	{
		return Camera.main.ScreenToWorldPoint(new Vector2(0f, Camera.main.pixelHeight)).y;
	}

	public static void VoyageThroughVoid(Transform player)
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
