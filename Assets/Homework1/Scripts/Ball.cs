using UnityEngine;

public class Ball : MonoBehaviour
{
	private string _horizontalAxis = "Horizontal";
	private float _xInput;

	private KeyCode _jumpKey = KeyCode.Space;
	private bool _isJumped;

	private float _deadInputZone = 0.05f;

	[SerializeField] private float _moveForce;
	[SerializeField] private float _jumpForce;
	[SerializeField] private ParticleSystem _jumpEffect;

	private float _moveInJumpForce;

	private Rigidbody _rigidbody;
	private Wallet _wallet;
	private Mover _mover;
	private Jumper _jumper;
	private GroundChecker _groundChecker;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();

		_mover = GetComponent<Mover>();
		_jumper = GetComponent<Jumper>();
		_groundChecker = GetComponent<GroundChecker>();
		_wallet = GetComponent<Wallet>();

		_moveInJumpForce = _moveForce / 3;
	}

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxis);

		if (Input.GetKeyDown(_jumpKey))
			_isJumped = true;
	}

	private void FixedUpdate()
	{
		if (Mathf.Abs(_xInput) > _deadInputZone)
		{
			if (_groundChecker.IsGrounded)
				_mover.Move(_rigidbody, _xInput, _moveForce);
			else
				_mover.Move(_rigidbody, _xInput, _moveInJumpForce);
		}

		if (_isJumped && _groundChecker.IsGrounded)
		{
			PlayJumpEffect();

			_jumper.Jump(_rigidbody, _jumpForce);
			_isJumped = false;
		}
	}
	private void PlayJumpEffect()
	{
		_jumpEffect.transform.position = _groundChecker.ContactPoint;
		_jumpEffect.Play();
	}

	public void StopBall() => _rigidbody.isKinematic = true;

	public void TakeCoin(int value) => _wallet.AddCoin(value);
}
