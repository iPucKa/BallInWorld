using UnityEngine;

public class Jumper : MonoBehaviour
{
	private bool _isJumped;
	public bool IsJumped => _isJumped;

	private KeyCode _jumpKey = KeyCode.Space;

	private Rigidbody _rigidbody;
	private Ball _ball;

	[SerializeField] private ParticleSystem _jumpEffect;
	[SerializeField] private float _jumpForce;

	private void Awake()
	{
		_ball = GetComponent<Ball>();
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(_jumpKey))
			_isJumped = true;
	}

	private void FixedUpdate()
	{
		if (_isJumped)
		{
			Jump();
			_isJumped = false;
		}
	}

	public void Jump()
	{
		if (_ball.IsGrounded)
		{
			_jumpEffect.transform.position = _ball.ContactPoint;
			_jumpEffect.Play();
			_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		}
	}
}
