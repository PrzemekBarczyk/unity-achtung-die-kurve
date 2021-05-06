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
}
