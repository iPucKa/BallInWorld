using UnityEngine;

public class FinishButton : MonoBehaviour
{
	private bool _isActivated = false;

	public bool IsActivated => _isActivated;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Roller>() != null)
		{
			_isActivated = true;
		}
	}
}
