using UnityEngine;
using System.Collections;

public class Cat1Controller : MonoBehaviour {
	
	public Rigidbody rigidBody;

	public Boundary boundary;
	
	public float speed;
	public float turnSpeed;
	public float turnAmount;
	
	void Start(){
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		float horizontalMovement =  Input.GetAxis("Horizontal");
		float verticalMovement =  Input.GetAxis("Vertical");

		MovementManagement(horizontalMovement, verticalMovement);
	}

	void MovementManagement (float horizontal, float vertical)
	{
		//move the cat forward and such
		if (vertical > 0)
			transform.Translate ((Vector3.forward) * speed * Time.deltaTime);

		if (horizontal != 0)
			Rotating (horizontal, vertical);

		//prevent cat from leaving the game area
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			1.2f,
			Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
		);

	}

	void Rotating (float horizontal, float vertical)
	{
		//allow rotational movement
		if(horizontal < 0.8 || horizontal > -0.8)turnAmount += horizontal * turnSpeed;

		Vector3 rot = new Vector3 (0.0f, turnAmount, 0.0f);
		rigidBody.rotation = Quaternion.Euler (rot);
	}

	/*void OnCollisionEnter(Collision other) 
	{
		if (other.collider.tag == "Wall") {
			//Destroy(other.gameObject);
		}
	}*/
}
