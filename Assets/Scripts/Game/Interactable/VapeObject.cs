using UnityEngine;

public class VapeObject : MonoBehaviour, IInteractable, IInventoryItem
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	[field: SerializeField] public Sprite ItemIcon { get; set; }
	[field: SerializeField] public string ItemName { get; set; }

	[TextArea(2, 50), SerializeField] private string interactionText = "Press [E] to pick up";
	[TextArea(2, 50), SerializeField] private string pickUpNarrative = "Hey you picked up this ite, this item bla bla bla";
	[SerializeField] private Sprite narrativeSprite;


	public string GetInteractionText()
	{
		return interactionText;
	}

	public void OnEndHover()
	{

	}

	public void OnInteract()
	{
		bool _added = GameManager.Instance.Inventory.TryAddItem(this);
		if (!_added)
		{
			HUDManager.Instance.InventoryFull();
			return;
		}
		HUDManager.Instance.ShowNarrative(pickUpNarrative, 5, narrativeSprite);
		gameObject.SetActive(false);
	}

	public void OnStartHover()
	{

	}
}
