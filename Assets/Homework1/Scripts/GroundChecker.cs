using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	private bool _isGrounded;
	private Vector3 _contactPoint;
	public bool IsGrounded => _isGrounded;
	public Vector3 ContactPoint => _contactPoint;

	private void OnCollisionStay(Collision collision)
	{
		Ground ground = collision.collider.gameObject.GetComponent<Ground>();

		if (ground != null)
		{
			ContactPoint contactPoint = collision.contacts[0];

			_contactPoint = contactPoint.point;
			_isGrounded = true;
		}
		else
			_isGrounded = false;
	}

	private void OnCollisionExit(Collision collision) => _isGrounded = false;
}
