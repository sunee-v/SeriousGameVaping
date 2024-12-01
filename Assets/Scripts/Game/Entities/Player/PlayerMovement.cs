using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : EntityMovement
{
	private PlayerInput playerInput;
	protected override void Awake()
	{
		base.Awake();
		playerInput = GetComponent<PlayerInput>();
		SetInputActions();
	}
	private void OnDestroy()
	{
		RemoveInputActions();
	}
	protected virtual void SetInputActions()
	{
		playerInput.actions["Move"].performed += ctx => OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());
		OnMoveInput += movement;
	}
	protected virtual void RemoveInputActions()
	{
		playerInput.actions["Move"].performed -= ctx => OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());
		OnMoveInput -= movement;
	}
}
