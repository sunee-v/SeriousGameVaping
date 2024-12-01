using UnityEngine;

public class PlacedownLocation : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	[SerializeField] private Transform placePosition;


	public string GetInteractionText()
	{
		IInventoryItem _item = GameManager.Instance.Inventory.GetSelectedItem();
		string _text;
		if (_item == null)
		{
			_text = "Inventory Slot is empty";
		}
		else
		{
			_text = "Press [E] to place down " + _item.ItemName;
		}
		return _text;
	}

	public void OnEndHover()
	{

	}

	public void OnInteract()
	{
		MonoBehaviour _item = GameManager.Instance.Inventory.GetSelectedItem() as MonoBehaviour;
		if (_item == null) { return; }
		GameObject _go = _item.gameObject;
		_go.transform.SetPositionAndRotation(placePosition.position, placePosition.rotation);
		_go.SetActive(true);
		GameManager.Instance.Inventory.RemoveItem();
	}

	public void OnStartHover()
	{

	}
}

