using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Head : MonoBehaviour
{
	[SerializeField] string inputAxis = "Horizontal";
	[SerializeField] float moveSpeed = 3f;
	[SerializeField] float rotationSpeed = 150f;

	float input;

	bool isAlive = true;

	GameManager gameManager;

	void Start()
	{
		Debug.Log("MinX: " + Camera.main.pixelHeight);
		transform.position = RandomPosition();
		transform.eulerAngles = RandomRotation();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void Update()
	{
		if (isAlive) input = Input.GetAxisRaw(inputAxis);
	}

	void FixedUpdate()
	{
		if (isAlive)
		{
			transform.Rotate(Vector3.forward * rotationSpeed * -input * Time.fixedDeltaTime, Space.Self);
			transform.Translate(Vector2.up * moveSpeed * Time.fixedDeltaTime, Space.Self);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collision with: " + collision.name);
		isAlive = false;
		gameManager.RestartLevel();
	}

	Vector2 RandomPosition()
	{
		return new Vector2(Random.Range(Window.MinX(), Window.MaxX()), Random.Range(Window.MinY(), Window.MaxY()));
	}

	Vector3 RandomRotation()
	{
		return Vector3.forward * Random.Range(0f, 360f);
	}
}
