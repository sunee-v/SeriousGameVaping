using UnityEngine;

public class EntityMovement : MonoBehaviour
{
	public CharacterController CharacterController { get; private set; }
	[SerializeField] private float speed = 5f;
	private Vector3 velocity;
	private Vector3 movementDirection;
	protected delegate void MoveInputEvent(Vector2 _direction);
	protected MoveInputEvent OnMoveInput;
	private const float gravity = 17f;
	public bool IsGrounded => CharacterController.isGrounded;
	[SerializeField][Range(0, .5f)] private float moveSmoothTime = .3f;
	private Vector2 currentDir;
	private Vector2 currentDirVelocity;

	protected virtual void Awake()
	{
		CharacterController = GetComponent<CharacterController>();
	}
	private void Update()
	{
		CharacterController.Move(velocity * Time.deltaTime);
	}
	private void FixedUpdate()
	{
		MoveEntity();
		if (!IsGrounded)
		{
			velocity.y -= gravity * Time.fixedDeltaTime;
			velocity.y = Mathf.Clamp(velocity.y, -20, 20);
		}
		else
		{
			velocity.y = -5;
		}
	}
	protected void movement(Vector2 _movementDirection)
	{
		movementDirection = new Vector3(_movementDirection.x, 0, _movementDirection.y);
	}
	private void MoveEntity()
	{
		currentDir = Vector2.SmoothDamp(currentDir, new(movementDirection.x, movementDirection.z), ref currentDirVelocity, moveSmoothTime);
		velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocity.y;
	}
}
