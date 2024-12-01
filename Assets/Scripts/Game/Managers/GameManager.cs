using UnityEngine;

public class GameManager : InstanceFactory<GameManager>
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Transform spwanPosition;
	protected override void Awake()
	{
		base.Awake();
		SpawnPlayer();
	}
	private void SpawnPlayer()
	{
		Instantiate(playerPrefab, spwanPosition.position, spwanPosition.rotation);
	}
}
