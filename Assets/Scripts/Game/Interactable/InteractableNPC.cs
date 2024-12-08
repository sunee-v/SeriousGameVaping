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
	[SerializeField] private Conversation teleportNarrative;
	[Header("Conversation after the player has interacted with the professor")]
	[SerializeField] private Conversation afterProfessorConversation;

	public string GetInteractionText()
	{
		return interactionText + " " + npcName;
	}

	public void OnEndHover()
	{
		HUDManager.Instance.EndConversation();
		if (!hasInteracted) { return; }
		if (!shouldTp) { return; }
		GameManager.Instance.Player.transform.position = teleportLocation;
		shouldTp = false;
		hasInteracted = false;
		HUDManager.Instance.ShowNarrative(teleportNarrative);
	}

	public virtual void OnInteract()
	{
		hasInteracted = true;
		HUDManager.Instance.StartConversation
		(GameManager.Instance.HasInteractedWithProfessor ? 
		afterProfessorConversation : npcSpeech[conversationIndex]);
		if(GameManager.Instance.HasInteractedWithProfessor)
		{
			HUDManager.Instance.ShowInputField();
		}
		if (teleportIndex == conversationIndex) { shouldTp = true; }
		conversationIndex = (1 + conversationIndex) % npcSpeech.Length;
	}

	public void OnStartHover()
	{

	}
}
