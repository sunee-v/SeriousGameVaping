using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	private Image[] images;
	private void Awake()
	{
		images = GetComponentsInChildren<Image>();
	}
	private void Start()
	{
		GameManager.Instance.Inventory.OnSlotChanged += updateSelected;
		updateSelected(0);
		UpdateSprites(new IInventoryItem[5]);
	}
	public void UpdateSprites(IInventoryItem[] _items)
	{
		for (int i = 0; i < images.Length; ++i)
		{
			if (_items[i] == null)
			{
				images[i].sprite = null;
				images[i].enabled = false;
				continue;
			}
			images[i].sprite = _items[i].ItemIcon;
			images[i].enabled = true;
		}
	}
	public void updateSelected(int _slot)
	{
		foreach (var item in images)
		{
			item.transform.SetScale(1);
		}
		images[_slot].transform.SetScale(1.2f);
	}
}
