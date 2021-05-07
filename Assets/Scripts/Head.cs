using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Head : MonoBehaviour
{
	[SerializeField] Tail tail;
	Tail currentTail;
	[SerializeField] string inputAxis = "Horizontal";
	[SerializeField] float moveSpeed = 3f;
	[SerializeField] float rotationSpeed = 150f;

	float input;

	bool isAlive = true;

	GameManager gameManager;

	void Start()
	{
		currentTail = tail;
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
			Window.VoyageThroughVoid(transform);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (isAlive)
		{
			isAlive = false;
			gameManager.RestartLevel();
		}
	}

	public void ChangeTail()
	{
		currentTail.IsActive(false);
		currentTail = Instantiate(tail, transform.parent);
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
