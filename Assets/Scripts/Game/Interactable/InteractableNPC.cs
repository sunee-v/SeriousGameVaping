using UnityEngine;

public class InteractableNPC : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	[SerializeField] private string npcName;
	[TextArea(2, 50), SerializeField] private string interactionText = "Press [E] to talk to";
	[SerializeField]
	private Conversation npcSpeech = new();
	public string GetInteractionText()
	{
		return interactionText + " " + npcName;
	}

	public void OnEndHover()
	{
		HUDManager.Instance.EndConversation();
	}

	public void OnInteract()
	{
		Debug.Log("Interacted with " + gameObject.name);
		Debug.Log("hudmanager show text bla bla bla");
		HUDManager.Instance.StartConversation(npcSpeech);
	}

	public void OnStartHover()
	{
		Debug.Log("Hovering over " + gameObject.name);
	}
}
