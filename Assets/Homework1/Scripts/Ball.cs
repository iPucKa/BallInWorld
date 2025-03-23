using UnityEngine;

public class Ball : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private Wallet _wallet;

	private bool _isGrounded;
	private Vector3 _contactPoint;
	public bool IsGrounded => _isGrounded;
	public Vector3 ContactPoint => _contactPoint;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_wallet = GetComponent<Wallet>();
	}

	public void StopBall()
	{
		_rigidbody.isKinematic = true;
	}

	public void GetCoin(int value)
	{
		_wallet.AddCoin(value);
	}

	private void OnCollisionStay(Collision collision)
	{
		ContactPoint contactPoint = collision.contacts[0];

		_contactPoint = contactPoint.point;
		_isGrounded = true;
	}

	private void OnCollisionExit(Collision collision) => _isGrounded = false;
}
