using UnityEngine;

public class Mover : MonoBehaviour
{
	public void Move(Rigidbody rigidbody, float xInput, float force) =>
		rigidbody.AddForce(Vector3.right * xInput * force * Time.deltaTime, ForceMode.Impulse);
}
