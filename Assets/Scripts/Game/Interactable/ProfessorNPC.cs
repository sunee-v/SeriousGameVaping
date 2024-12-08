using UnityEngine;

public class ProfessorNPC : InteractableNPC
{
	public override void OnInteract()
	{
		base.OnInteract();
		GameManager.Instance.hasInteractedWithProfessor = true;
	}
}
