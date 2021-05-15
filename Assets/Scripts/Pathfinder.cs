using UnityEngine;

[RequireComponent(typeof(Head))]
public class Pathfinder : MonoBehaviour
{
	[SerializeField] Transform[] rayTargets;
	[SerializeField] LayerMask ignoreRaycast;

	public float FindInput()
	{
		Vector3 farrestPoint = transform.position;
		RaycastHit2D previousRaycast = Physics2D.Raycast(transform.position, transform.position, 0f, ignoreRaycast);
		for (int i = 0; i < rayTargets.Length; i++)
		{
			RaycastHit2D newRaycastHit = Physics2D.Raycast(transform.position, rayTargets[i].position - transform.position, Vector2.Distance(transform.position, rayTargets[i].position), ~ignoreRaycast); // cast ray in point direction
			if (newRaycastHit.collider == null) // ray didn't collide
			{
				farrestPoint = rayTargets[i].position; // save that point
				break;
			}
			else // ray did collide
			{
				Debug.DrawLine(transform.position, newRaycastHit.point, Color.yellow, 0.1f);
				if (Vector2.Distance(transform.position, newRaycastHit.point) > Vector2.Distance(transform.position, previousRaycast.point)) farrestPoint = rayTargets[i].position; // save farrest point
				previousRaycast = newRaycastHit;
			}
		}
		Debug.DrawLine(transform.position, farrestPoint, Color.red, 0.1f);
		return PointToInput(farrestPoint);
	}

	float PointToInput(Vector3 point)
	{
		if (point == rayTargets[0].position) return 0f;
		if (point == rayTargets[1].position) return -1f;
		if (point == rayTargets[2].position) return -1f;
		if (point == rayTargets[3].position) return -1f;
		if (point == rayTargets[4].position) return -1f;
		if (point == rayTargets[5].position) return 1f;
		if (point == rayTargets[6].position) return 1f;
		if (point == rayTargets[7].position) return 1f;
		if (point == rayTargets[8].position) return 1f;
		return 0f;
	}
}
