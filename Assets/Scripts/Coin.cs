using UnityEngine;

public class Coin : MonoBehaviour
{
	private bool _isCollected;
	public bool IsCollected => _isCollected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Ball>() != null)
		{
			_isCollected = true;
			gameObject.SetActive(false);
		}
	}
}
