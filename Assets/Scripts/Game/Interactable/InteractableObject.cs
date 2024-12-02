using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	[TextArea(2, 50), SerializeField] private string interactionText = "Press [E] to interact";

	public string GetInteractionText()
	{
		return interactionText;
	}

	public void OnEndHover()
	{
		
	}

	public void OnInteract()
	{
		
	}

	public void OnStartHover()
	{
		
	}
}
