using UnityEngine;

public class InstanceFactory<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; private set; }
	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Destroy(this);
			return;
		}
		Instance = this as T;
	}
}
