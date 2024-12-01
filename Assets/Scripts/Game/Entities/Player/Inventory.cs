using UnityEngine;

public class Inventory : MonoBehaviour
{
	//max 5 things
	//make minecraft hotbar
	public UpdateInventory OnInventoryUpdate;
	private IInventoryItem[] items = new IInventoryItem[5];
	public UpdateSelectedSlot OnSlotChanged;
	private int selectedSlot = 0;
	public bool TryAddItem(IInventoryItem _item)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i] == null)
			{
				items[i] = _item;
				OnInventoryUpdate?.Invoke(items);
				return true;
			}
		}
		return false;
	}
	public IInventoryItem GetSelectedItem()
	{
		return items[selectedSlot];
	}
	public void RemoveItem(int _index = -1)
	{
		if (_index == -1)
		{
			items[selectedSlot] = null;
			OnInventoryUpdate?.Invoke(items);
			return;
		}
		if (items.Length <= _index)
		{
			Debug.LogWarning("Index out of range");
			return;
		}
		items[_index] = null;
		OnInventoryUpdate?.Invoke(items);
	}

	public void Update()
	{
		updateSlot();
	}
	private void updateSlot()
	{
		bool _changed = false;
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedSlot = 0;
			_changed = true;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedSlot = 1;
			_changed = true;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			selectedSlot = 2;
			_changed = true;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			selectedSlot = 3;
			_changed = true;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			selectedSlot = 4;
			_changed = true;
		}
		if (!_changed) { return; }
		OnSlotChanged?.Invoke(selectedSlot);
	}
}
public delegate void UpdateInventory(IInventoryItem[] _items);
public delegate void UpdateSelectedSlot(int _slot);
