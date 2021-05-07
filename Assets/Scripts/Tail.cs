using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float pointsSpacing = 0.1f;

    bool isActive = true;

    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;

    List<Vector2> points = new List<Vector2>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgeCollider.points = new Vector2[] { new Vector2(100, 100), new Vector2(101, 101) };
        SetPoint();
    }

    void Update()
    {
        if (isActive && Vector2.Distance(points[points.Count - 1], head.position) > pointsSpacing) SetPoint();
    }

    void SetPoint()
	{
        if (points.Count >= 2) edgeCollider.SetPoints(points); // witout last point

        points.Add(head.position);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, head.position);
	}

    public void IsActive(bool isActive)
	{
        this.isActive = isActive;
	}
}
