using UnityEngine;

public class Mover : MonoBehaviour
{
	private string _horizontalAxis = "Horizontal";
	private float _xInput;

	private float _deadInputZone = 0.05f;

	[SerializeField] private float _moveForce;

	private Rigidbody _rigidbody;
	private Ball _ball;

	private float _moveInJumpForce;

	private void Awake()
	{
		_ball = GetComponent<Ball>();
		_rigidbody = GetComponent<Rigidbody>();

		_moveInJumpForce = _moveForce / 3;
	}

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxis);
	}

	private void FixedUpdate()
	{
		if (Mathf.Abs(_xInput) > _deadInputZone)
			Move(_xInput);
	}

	public void Move(float xInput)
	{
		if (_ball.IsGrounded == false)
			_rigidbody.AddForce(Vector3.right * xInput * _moveInJumpForce * Time.deltaTime, ForceMode.Impulse);

		else if (_ball.IsGrounded)
			_rigidbody.AddForce(Vector3.right * xInput * _moveForce * Time.deltaTime, ForceMode.Impulse);
	}
}
