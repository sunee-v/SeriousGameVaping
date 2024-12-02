using UnityEngine;

public class GameManager : InstanceFactory<GameManager>
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Transform spwanPosition;
	[SerializeField] private int frameRate = 60;
	public GameObject Player { get; private set; }
	public Inventory Inventory { get; private set; }
	protected override void Awake()
	{
		base.Awake();
		Application.targetFrameRate = frameRate;
		SpawnPlayer();
	}
	private void SpawnPlayer()
	{
		Player = Instantiate(playerPrefab, spwanPosition.position, spwanPosition.rotation);
		Inventory = Player.GetComponent<Inventory>();
	}
}
