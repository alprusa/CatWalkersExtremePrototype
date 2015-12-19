using UnityEngine;

public class PowerAttacks : MonoBehaviour {

	public Rigidbody rigidBody;
	public float amount = 50f;

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;
		
		rigidBody.AddTorque(transform.up * h);
		rigidBody.AddTorque(transform.right * v);
	}
	
	void OnCollisionStay(Collision other) 
	{
		//if(other.collider.tag == "Player")
		other.gameObject.GetComponent<CatController>().setRandomPA ();
		Destroy (gameObject);
	}
}
