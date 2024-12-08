using UnityEngine;

public class PlacedownLocation : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; } = 5;
	private Transform[] placePosition;
	private int index;
	private void Awake()
	{
		//placePosition = GetComponentsInChildren<Transform>();
		placePosition = new Transform[transform.childCount];
		for (int i = 0; i < placePosition.Length; i++)
		{
			placePosition[i] = transform.GetChild(i);
		}
	}

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
		Transform _go = _item.transform;
		getFullIndex();
		_go.parent = placePosition[index];
		_go.SetPositionAndRotation(placePosition[index].position, placePosition[index].rotation);
		_go.gameObject.SetActive(true);
		GameManager.Instance.Inventory.RemoveItem();
		index = (1 + index) % placePosition.Length;
	}
	private void getFullIndex()
	{
		if (placePosition[index].childCount == 0)
		{
			Debug.Log("no child");
			return;
		}
		for (int i = 0; i < placePosition.Length; ++i)
		{
			Debug.Log("Evualuating index: " + i);
			if (placePosition[i].childCount != 0)
			{
				if (hasEnabledChild(placePosition[index])) { continue; }
				index = i;
			}
			index = i;
			break;
		}
	}
	private bool hasEnabledChild(Transform _parent)
	{
		bool _hasEnabledChild = false;
		for (int i = 0; i < _parent.childCount; ++i)
		{
			if (_parent.GetChild(i).gameObject.activeSelf)
			{
				Debug.Log($"Checking if {_parent.GetChild(i).name} is active");	
				_hasEnabledChild = true;
				Debug.Log("Has enabled child");
				break;
			}
		}
		return _hasEnabledChild;
	}

	public void OnStartHover()
	{

	}
}

