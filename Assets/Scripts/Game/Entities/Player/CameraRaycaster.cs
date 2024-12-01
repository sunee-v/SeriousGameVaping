using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRaycaster : MonoBehaviour
{
	private const float range = 100;
	private IInteractable currentTarget;
	private Camera cam;
	[SerializeField] private LayerMask mask;
	private PlayerInput playerInput;
	private void Awake()
	{
		cam = Camera.main;
	}
	protected virtual void SetInputActions()
	{
		playerInput.actions["Interact"].started += _ => interact();
	}
	protected virtual void RemoveInputActions()
	{
		playerInput.actions["Interact"].started -= _ => interact();
	}
	private void OnDestroy()
	{
		RemoveInputActions();
	}
	private void Update()
	{
		raycastForInteractable();
	}
	private void interact()
	{
		if(currentTarget == null) { return; }
		currentTarget.OnInteract();
	}
	private void raycastForInteractable()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		//start
		if (!Physics.Raycast(ray, out var _hit, range, mask))
		{
			clearTarget();
			return;
		}
		//Debug.Log("We Hit" + whatIHit.collider.name + " " + whatIHit.point);
		if (!_hit.collider.TryGetComponent<IInteractable>(out var _interactable))
		{
			clearTarget();
			return;
		}
		if (_hit.distance > _interactable.MaxRange)
		{
			clearTarget();
			return;
		}
		if (_interactable == currentTarget) { return; }
		HUDManager.Instance.SetInteractionText(_interactable.GetDescription());
		currentTarget = _interactable;
		currentTarget.OnStartHover();
	}
	private void clearTarget()
	{
		if (currentTarget == null) { return; }
		currentTarget.OnEndHover();
		currentTarget = null;
		HUDManager.Instance.SetInteractionText("");
	}
}
