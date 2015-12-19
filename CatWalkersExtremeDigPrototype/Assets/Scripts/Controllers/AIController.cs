using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	public Rigidbody rigidBody;
	
	public Boundary boundary;
	public SpecialAttacks sp;
	
	public float turnSpeed;
	public float minTilt, maxTilt, pauseTime;
	
	//private bool stop = false;
	
	private float preVertical;
	private float turnAmount;
	private float speed;
	
	//private int shakeTimer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
