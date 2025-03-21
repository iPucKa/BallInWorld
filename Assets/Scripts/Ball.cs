using UnityEngine;

public class Ball : MonoBehaviour
{
	private string _horizontalAxis = "Horizontal";
	private KeyCode _jumpKey = KeyCode.Space;

	private float _xInput;
	private bool _isJumped;

	private Rigidbody _rigidbody;

	private bool _isGrounded;

	private float _deadInputZone = 0.05f;
	[SerializeField] private ParticleSystem _jumpEffect;

	[SerializeField] private float _jumpForce;
	[SerializeField] private float _moveForce;

	private float _moveInJumpForce;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_moveInJumpForce = _moveForce / 3;
	}

	private void Update()
	{
		InputHandle();
	}

	private void FixedUpdate()
	{
		if (Mathf.Abs(_xInput) > _deadInputZone)
			Move(_xInput);

		if (_isJumped)
		{
			Jump();
			_isJumped = false;
		}
	}

	public void Jump()
	{
		if (_isGrounded)
		{
			_jumpEffect.Play();
			_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		}
	}

	public void Move(float xInput)
	{
		if (_isGrounded == false)
			_rigidbody.AddForce(Vector3.right * xInput * _moveInJumpForce * Time.deltaTime, ForceMode.Impulse);

		else if (_isGrounded)
			_rigidbody.AddForce(Vector3.right * xInput * _moveForce * Time.deltaTime, ForceMode.Impulse);
	}

	public void StopBall()
	{
		_rigidbody.isKinematic = true;
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.GetComponent<Coin>() == false)
		{
			ContactPoint contactPoint = collision.contacts[0];
			_jumpEffect.transform.position = contactPoint.point;

			_isGrounded = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.GetComponent<Coin>() == false)
			_isGrounded = false;
	}

	private void InputHandle()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxis);

		if (Input.GetKeyDown(_jumpKey))
		{
			_isJumped = true;
		}
	}
}
