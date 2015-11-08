using UnityEngine;
using System.Collections;

public class Cat1Controller : MonoBehaviour {
	
	public Rigidbody rigidBody;
	public Boundary boundary;

	public float tilt;
	public float speedVert;
	public float speedHoriz;

	void Start(){
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		float horizontalMovement =  Input.GetAxis("Horizontal");
		float verticalMovement =  Input.GetAxis("Vertical");

		Vector3 vel = new Vector3(horizontalMovement*speedHoriz, 0.0f, verticalMovement*speedVert);
		rigidBody.velocity = vel;
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			0.69f,
			Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
		);
	}
}
