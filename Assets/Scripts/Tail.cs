using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float pointsSpacing = 0.1f;

    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;

    List<Vector2> points = new List<Vector2>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        SetPoint();
    }

    void Update()
    {
        if (Vector2.Distance(points[points.Count - 1], head.position) > pointsSpacing) SetPoint();
    }

    void SetPoint()
	{
        edgeCollider.SetPoints(points); // witout last point

        points.Add(head.position);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, head.position);
	}
}
