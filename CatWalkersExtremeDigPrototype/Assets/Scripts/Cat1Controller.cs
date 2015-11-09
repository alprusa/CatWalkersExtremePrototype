using UnityEngine;
using System.Collections;

public class Cat1Controller : MonoBehaviour {
	
	public Rigidbody rigidBody;

	public Boundary boundary;
	
	public float speed;
	public float turnSpeed;

	private float preVertical;
	private float shakeAmount;
	private float turnAmount;

	private bool stoppedMoving = false;
	
	void Start(){
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		float horizontalMovement =  Input.acceleration.x;
		float verticalMovement =  Input.acceleration.y;

		//check if play has stopped shaking
		if (preVertical == verticalMovement)
			stoppedMoving = true;
		else
			stoppedMoving = false;

		//make move forward
		if (verticalMovement != 0 && !stoppedMoving)
			Movement(horizontalMovement, verticalMovement);

		//make rotation
		if (horizontalMovement != 0)
			Rotating (horizontalMovement, verticalMovement);
	}

	void Movement (float horizontal, float vertical)
	{
		//move the cat forward and such
		if (vertical < 0)
			vertical = -vertical;

		if(shakeAmount < 0.5)
			shakeAmount += (vertical * speed);

		transform.Translate ((Vector3.forward) * turnAmount * Time.deltaTime);

		//prevent cat from leaving the game area
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			1.2f,
			Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
		);

		preVertical = vertical;
		print (Input.acceleration);
	}

	void Rotating (float horizontal, float vertical)
	{
		//allow rotational movement
		if(horizontal < 0.2 || horizontal > -0.2) turnAmount += (horizontal * turnSpeed);

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
