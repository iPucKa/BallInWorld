using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	private string _horizontalAxis = "Horizontal";
	private string _verticalAxis = "Vertical";

	private float _xInput;
	private float _yInput;

	private float _deadInputZone = 0.05f;

	[SerializeField] private float _tiltSideForce;

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxis);
		_yInput = Input.GetAxisRaw(_verticalAxis);
	}

	private void FixedUpdate()
	{
		if(Mathf.Abs(_xInput) > _deadInputZone)
		{
			RotateToX(_xInput);
		}

		if (Mathf.Abs(_yInput) > _deadInputZone)
		{
			RotateToZ(_yInput);
		}
	}

	private void RotateToX(float xInput)
	{
		transform.Rotate(Vector3.back * _xInput * _tiltSideForce * Time.deltaTime);
	}

	private void RotateToZ(float yInput)
	{
		transform.Rotate(Vector3.right * _yInput * _tiltSideForce * Time.deltaTime);
	}
}
