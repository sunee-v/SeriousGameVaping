using UnityEngine;

public class InteractableNPC : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	[SerializeField] private string npcName;
	[TextArea(2, 50), SerializeField] private string interactionText = "Press [E] to talk to";
	[SerializeField]
	private Conversation[] npcSpeech = new Conversation[1];
	private int conversationIndex = 0;
	[SerializeField] private int teleportIndex = -1;
	[SerializeField] private Vector3 teleportLocation;
	private bool hasInteracted;
	private bool shouldTp;
	[SerializeField] private string[] teleportNarrative;
	public string GetInteractionText()
	{
		return interactionText + " " + npcName;
	}

	public void OnEndHover()
	{
		HUDManager.Instance.EndConversation();
		if (!hasInteracted) { return; }
		if (!shouldTp) { return; }
		Debug.Log(teleportNarrative.Length);
		GameManager.Instance.Player.transform.position = teleportLocation;
		shouldTp = false;
		hasInteracted = false;
		Debug.Log(gameObject.name +" "+ transform.position);
		
		//HUDManager.Instance.ShowNarrative(teleportNarrative);
	}

	public void OnInteract()
	{
		hasInteracted = true;
		HUDManager.Instance.StartConversation(npcSpeech[conversationIndex]);
		if (teleportIndex == conversationIndex) { shouldTp = true; }
		conversationIndex = (1 + conversationIndex) % npcSpeech.Length;
	}

	public void OnStartHover()
	{
		
	}
}
