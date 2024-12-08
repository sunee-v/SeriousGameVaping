using UnityEngine;

public class GameManager : InstanceFactory<GameManager>
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Transform spwanPosition;
	[SerializeField] private int frameRate = 60;
	public GameObject Player { get; private set; }
	public Inventory Inventory { get; private set; }
	public bool hasInteractedWithProfessor;
	[field: SerializeField] public string[] VapeContents { get; private set; }
	[field: Header("The accuracy needed to win the game in percentage")]
	[field: SerializeField, Range(0, 100)] public int AccuracyToWin { get; private set; } = 50;
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
	private void OnValidate()
	{
		for (int i = 0; i < VapeContents.Length; ++i)
		{
			VapeContents[i] = VapeContents[i].ToLower();
		}
	}
	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
