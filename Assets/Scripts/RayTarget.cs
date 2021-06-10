using UnityEngine;

public class RayTarget : MonoBehaviour
{
    [SerializeField] Transform leftTarget;
    [SerializeField] Transform rightTarget;

    public Vector3 GetLeftTargetPosition()
	{
        return leftTarget.position;
	}

    public Vector3 GetRightTargetPosition()
	{
        return rightTarget.position;
	}
}
