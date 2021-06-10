using UnityEngine;

[RequireComponent(typeof(Head))]
public class Pathfinder : MonoBehaviour
{
	[SerializeField] Transform leftHeadPosition;
	[SerializeField] Transform rightHeadPosition;

	[SerializeField] RayTarget[] rayTargets;
	[SerializeField] LayerMask ignoreRaycast;

	bool noCollisionInThisFrame = true;

	public float FindInput()
	{
		noCollisionInThisFrame = true;

		Vector3 farrestCollidingRayTargetPosition = transform.position;
		RaycastHit2D previousRaycast = Physics2D.Raycast(transform.position, transform.position, 0f, ignoreRaycast);

		foreach (RayTarget rayTarget in rayTargets)
		{
			// cast two rays in target direction: one from left side and one from right side of head object
			RaycastHit2D newLeftRaycastHit = Physics2D.Raycast(leftHeadPosition.position, rayTarget.GetLeftTargetPosition() - leftHeadPosition.position,
															   Vector2.Distance(leftHeadPosition.position, rayTarget.GetLeftTargetPosition()), ~ignoreRaycast);

			RaycastHit2D newRightRaycastHit = Physics2D.Raycast(rightHeadPosition.position, rayTarget.GetRightTargetPosition() - rightHeadPosition.position,
															   Vector2.Distance(rightHeadPosition.position, rayTarget.GetRightTargetPosition()), ~ignoreRaycast);
			
			if (newLeftRaycastHit.collider != null || newRightRaycastHit.collider != null) // ray did collide
			{
				RaycastHit2D newRaycastHit = newLeftRaycastHit.collider == null ? newRightRaycastHit : newLeftRaycastHit; // choose colliding ray

				Debug.DrawLine(transform.position, newRaycastHit.point, Color.yellow, 0.1f);

				if (Vector2.Distance(transform.position, newRaycastHit.point) > Vector2.Distance(transform.position, previousRaycast.point))
					farrestCollidingRayTargetPosition = rayTarget.transform.position; // save farrest ray target

				previousRaycast = newRaycastHit;
				noCollisionInThisFrame = false;
			}
			else // ray did not collide
			{
				Debug.DrawLine(transform.position, rayTarget.transform.position, Color.blue, 0.1f);

				if (Vector2.Distance(transform.position, newLeftRaycastHit.point) > Vector2.Distance(transform.position, previousRaycast.point))
					farrestCollidingRayTargetPosition = rayTarget.transform.position; // save farrest ray target

				previousRaycast = newLeftRaycastHit;
			}
		}

		if (noCollisionInThisFrame) // choose target position randomly
		{
			Vector3 randomRayTargetPosition = rayTargets[Random.Range(0, rayTargets.Length)].transform.position;
			return PointToInput(randomRayTargetPosition);
		}

		return PointToInput(farrestCollidingRayTargetPosition);
	}

	float PointToInput(Vector3 point)
	{
		Debug.DrawLine(transform.position, point, Color.green, 0.1f);

		if (point == rayTargets[0].transform.position) return -0.2f;
		if (point == rayTargets[1].transform.position) return 0.2f;
		if (point == rayTargets[2].transform.position) return -0.5f;
		if (point == rayTargets[3].transform.position) return 0.5f;
		if (point == rayTargets[4].transform.position) return -0.8f;
		if (point == rayTargets[5].transform.position) return 0.8f;
		if (point == rayTargets[6].transform.position) return -1f;
		if (point == rayTargets[7].transform.position) return 1f;

		return 0f;
	}
}
