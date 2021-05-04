using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Head : MonoBehaviour
{
	[SerializeField] string inputAxis = "Horizontal";
	[SerializeField] float moveSpeed = 3f;
	[SerializeField] float rotationSpeed = 150f;

	float input;

	void Update()
	{
		input = Input.GetAxisRaw(inputAxis);
	}

	void FixedUpdate()
	{
		transform.Rotate(Vector3.forward * rotationSpeed * -input * Time.fixedDeltaTime);
		transform.Translate(transform.up * moveSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collision with: " + collision.name);
	}
}
