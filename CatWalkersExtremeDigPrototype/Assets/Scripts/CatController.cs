using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {
	
	public Rigidbody rigidBody;

	public Boundary boundary;
	public UIElements ui;
	public SpecialAttacks sp;

	public float turnSpeed;
	public float minTilt, maxTilt, pauseTime;

	private bool stop = false;
	
	private float preVertical;
	private float turnAmount;
	private float speed;

	private int shakeTimer = 0;

	void FixedUpdate(){
		//get phone accerometer data
		float horizontalMovement =  Input.acceleration.x;
		float verticalMovement =  Input.acceleration.y;

		//make move forward
		Movement(horizontalMovement, verticalMovement);

		//make rotation
		Rotating (horizontalMovement);

		//only start the shakeTimer once they returned to start of rotaional cycle
		if(verticalMovement > minTilt) shakeTimer++;
	}

	//move the cat forward and such
	void Movement (float horizontal, float vertical)
	{
		//make it so you do not go backwards
		if (vertical < 0)
			vertical = 0;

		//speedboost enabled move foward faster
		if (sp.speedBoost)
			speed = sp.newSpeed;
		else
			speed = sp.oldSpeed;

		//reset the shakeTimer after they've cycled back so player can move forward again
		if (vertical < minTilt && stop) {
			shakeTimer = 0;
			stop = false;
		}

		//force player to shake by stopping movement once they've accelerated forward a set amount of time
		if (shakeTimer > pauseTime) {
			vertical = 0;
			stop = true;
		}

		//makes it so players don't tilt at certain degrees
		if(vertical > minTilt && vertical < maxTilt)
			transform.Translate ((Vector3.forward) * vertical * speed * Time.deltaTime);

		//prevent cat from leaving the game area
		rigidBody.position = new Vector3 (
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
			1.2f,
			Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
		);
	}

	//set the rotation so players can turn
	void Rotating (float horizontal)
	{
		//allow rotational movement
		if(horizontal < 0.2 || horizontal > -0.2) turnAmount += (horizontal * turnSpeed);

		Vector3 rot = new Vector3 (0.0f, turnAmount, 0.0f);
		rigidBody.rotation = Quaternion.Euler (rot);
	}

	//trigger invisible sphere that sets the "finished" bool
	void OnTriggerEnter(Collider other) 
	{
		if (other.GetComponent<Collider>().tag == "Finish") {
			ui.finished = true;
		}

		if (other.GetComponent<Collider> ().tag == "ShortCut" && sp.shortCut == true)
			Destroy (other.gameObject);
	}

	//trigger destroy short-cut box
	void OnTriggerStay(Collider other) 
	{
		if (other.GetComponent<Collider> ().tag == "ShortCut" && sp.shortCut == true)
			Destroy (other.gameObject);

		print (other.GetComponent<Collider> ().tag);
	}
}
