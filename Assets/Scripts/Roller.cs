using UnityEngine;

public class Roller : MonoBehaviour
{
	private Rigidbody _rigidbody;

	//[SerializeField] private Platform _platform;
	[SerializeField] private float _force;


	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void LateUpdate()
	{
		_rigidbody.AddForce(Vector3.down * _force);
		//_rigidbody.AddForce(_platform.transform.up * - _force);
	}

	public void Stop()
	{
		_rigidbody.isKinematic = true;
	}
}
