using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Head : MonoBehaviour
{
	[SerializeField] bool isBot;
	[SerializeField] Pathfinder pathfinder;
	[SerializeField] Tail tail;
	Tail currentTail;
	[SerializeField] public KeyCode LeftKey;
	[SerializeField] public KeyCode RightKey;
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
		if (isBot && isAlive) input = pathfinder.FindInput();
		else if (!isBot && isAlive) input = GetInput();
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
			gameManager.RestartGame();
		}
	}

	public void ChangeTail()
	{
		currentTail.IsActive(false);
		currentTail = Instantiate(tail, transform.parent);
	}

	int GetInput()
	{
		if (Input.GetKey(LeftKey)) return -1;
		if (Input.GetKey(RightKey)) return 1;
		return 0;
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
