using TMPro;
using UnityEngine;

public class HUDManager : InstanceFactory<HUDManager>
{
	[SerializeField] private TMP_Text interactionText;
	public void SetInteractionText(string _text)
	{
		interactionText.text = _text;
	}
}
