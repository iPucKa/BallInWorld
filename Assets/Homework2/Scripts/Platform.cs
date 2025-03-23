using UnityEngine;

public class Platform : MonoBehaviour
{
	private string _horizontalAxis = "Horizontal";
	private string _verticalAxis = "Vertical";

	private float _xInput;
	private float _yInput;

	private float _deadInputZone = 0.01f;

	private bool _canRotate;

	[SerializeField] private float _rotateUpDownForce;
	[SerializeField] private float _rotateRightLeftForce;

	private void Awake()
	{
		_canRotate = true;
	}
	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxis);
		_yInput = Input.GetAxisRaw(_verticalAxis);
	}

	private void FixedUpdate()
	{
		if (_canRotate)
		{
			if (Mathf.Abs(_xInput) > _deadInputZone)
				TiltRightLeft(_xInput);

			if (Mathf.Abs(_yInput) > _deadInputZone)
				TiltUpDown(_yInput);
		}
	}

	private void TiltRightLeft(float xInput) => 
		transform.Rotate(Vector3.back * _xInput * _rotateRightLeftForce * Time.deltaTime, Space.World);
	
	private void TiltUpDown(float yInput) => 
		transform.Rotate(Vector3.right * _yInput * _rotateUpDownForce * Time.deltaTime, Space.World);	

	public void Stop()
	{
		_canRotate = false;
	}
}
