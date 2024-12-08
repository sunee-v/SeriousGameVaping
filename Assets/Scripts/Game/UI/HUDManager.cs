using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class HUDManager : InstanceFactory<HUDManager>
{
	[SerializeField] private TMP_Text interactionText;
	[SerializeField] private TMP_Text conversationText;
	private bool isInConversation;
	private CancellationTokenSource cts;
	private InventoryUI inventoryUI;
	private NarrativeUI narrativeUI;
	[SerializeField] private GameObject narrativeBox;
	protected override void Awake()
	{
		base.Awake();
		inventoryUI = GetComponentInChildren<InventoryUI>();
		narrativeUI = GetComponentInChildren<NarrativeUI>();
	}
	private void Start()
	{
		GameManager.Instance.Inventory.OnInventoryUpdate += OnInventoryUpdate;
	}

	public void SetInteractionText(string _text)
	{
		interactionText.text = _text;
	}
	public void StartConversation(Conversation _convo)
	{
		cts = new();
		isInConversation = true;
		if (_convo.Dialogues.Length == 0)
		{
			Debug.LogWarning("No dialogues in conversation!");
			return;
		}
		conversation(_convo, cts.Token).Forget();
	}
	private async UniTask conversation(Conversation _convo, CancellationToken _cts = default)
	{
		narrativeBox?.SetActive(isInConversation);
		for (int i = 0; i < _convo.Dialogues.Length; ++i)
		{
			conversationText.text = _convo.Dialogues[i].Text;
			await UniTask.WaitForSeconds(_convo.Dialogues[i].Duration, cancellationToken: _cts);
		}
		EndConversation();
	}
	public void EndConversation()
	{
		if (cts != null)
		{
			cts.Cancel();
			cts.Dispose();
			cts = null;
		}
		isInConversation = false;
		narrativeBox?.SetActive(isInConversation);
		Debug.Log("Player ended conversation!");
		conversationText.text = "";
	}
	public void InventoryFull()
	{
		Debug.Log("Inventory is full!");
	}
	public void ShowNarrative(string _text, float _duration, Sprite _sprite = null)
	{
		Debug.Log("Narrative: " + _text);
		narrativeUI.SetNarrative(_text, _sprite, _duration);
	}
	public void OnInventoryUpdate(IInventoryItem[] _items)
	{
		inventoryUI.UpdateSprites(_items);
	}
}
