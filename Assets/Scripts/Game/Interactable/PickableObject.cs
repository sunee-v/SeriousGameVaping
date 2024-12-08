using UnityEngine;

public class PickableObject : MonoBehaviour, IInteractable, IInventoryItem
{

	[field: SerializeField] public float MaxRange { get; set; } = 5;

	[field: SerializeField] public Sprite ItemIcon { get; set; }
	[field: SerializeField] public string ItemName { get; set; }

	[TextArea(2, 50), SerializeField] private string interactionText = "Press [E] to pick up";

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
		gameObject.SetActive(false);
		transform.parent = null;
	}

	public void OnStartHover()
	{

	}
}
