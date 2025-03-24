using UnityEngine;

public class Jumper : MonoBehaviour
{
	public void Jump(Rigidbody rigidbody, float force) =>
		rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
}
