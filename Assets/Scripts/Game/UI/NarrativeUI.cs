using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeUI : MonoBehaviour
{
	[SerializeField] private Image panel;
	[SerializeField] private Image image;
	[SerializeField] private TMP_Text text;
	private void Awake()
	{
		panel.enabled = false;
		image.enabled = false;
		text.text = "";
	}
	public void SetNarrative(string _text, Sprite _sprite, float _duration)
	{
		showNarrative(_text, _sprite, _duration).Forget();
	}
	private async UniTask showNarrative(string _text, Sprite _sprite, float _duration)
	{
		panel.enabled = true;
		if (_sprite != null)
		{
			image.enabled = true;
			image.sprite = _sprite;
		}
		text.text = _text;
		await UniTask.WaitForSeconds(_duration);
		image.sprite = null;
		text.text = "";
		image.enabled = false;
		panel.enabled = false;
	}
}
