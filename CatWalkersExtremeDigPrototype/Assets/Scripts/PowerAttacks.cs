using UnityEngine;
using System.Collections;

public class PowerAttacks : MonoBehaviour {

	public float amount = 50f;
	public Rigidbody rigidBody;

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;
		
		rigidBody.AddTorque(transform.up * h);
		rigidBody.AddTorque(transform.right * v);
	}
	
	void OnCollisionEnter(Collision other) 
	{
		Destroy(gameObject);
	}
}
