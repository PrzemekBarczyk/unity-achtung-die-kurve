using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Head : MonoBehaviour
{
	public string Name { get; set; }
	[SerializeField] bool isBot;
	[SerializeField] Pathfinder pathfinder;
	[SerializeField] Tail tail;
	Tail currentTail;
	[SerializeField] public KeyCode LeftKey;
	[SerializeField] public KeyCode RightKey;
	[SerializeField] float moveSpeed = 3f;
	[SerializeField] float rotationSpeed = 150f;

	float input;

	public bool IsAlive { get; private set; } = true;

	GameManager gameManager;
	ScoreBoard scoreBoard;
	Borders borders;

	void Start()
	{
		currentTail = tail;
		scoreBoard = FindObjectOfType<ScoreBoard>();
		borders = FindObjectOfType<Borders>();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		transform.position = RandomPosition();
		transform.eulerAngles = RandomRotation();
	}

	void Update()
	{
		if (isBot && IsAlive) input = pathfinder.FindInput();
		else if (!isBot && IsAlive) input = GetInput();
	}

	void FixedUpdate()
	{
		if (IsAlive)
		{
			transform.Rotate(Vector3.forward * rotationSpeed * -input * Time.fixedDeltaTime, Space.Self);
			transform.Translate(Vector2.up * moveSpeed * Time.fixedDeltaTime, Space.Self);
			borders.VoyageThroughVoid(transform);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsAlive)
		{
			IsAlive = false;
			scoreBoard.UpdateScore(Name);
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
		return new Vector2(Random.Range(borders.MinX(), borders.MaxX()), Random.Range(borders.MinY(), borders.MaxY()));
	}

	Vector3 RandomRotation()
	{
		return Vector3.forward * Random.Range(0f, 360f);
	}
}
