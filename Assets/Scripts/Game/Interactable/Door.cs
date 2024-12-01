using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
	//open close immediate
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	private bool isOpen;

	public string GetInteractionText()
	{
		return "Press [E] to " + (isOpen ? "close" : "open") + " the door";
	}

	public void OnEndHover()
	{

	}

	public void OnInteract()
	{
		float _yRotation = isOpen ? -90 : 90;
		if (transform == null) { return; }
		transform.Rotate(0, _yRotation, 0);
		isOpen = !isOpen;
	}

	public void OnStartHover()
	{

	}
}
