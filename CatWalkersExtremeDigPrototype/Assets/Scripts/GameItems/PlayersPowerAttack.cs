using UnityEngine;
using UnityEngine.Networking;

public class PlayersPowerAttack : NetworkBehaviour {
	private const string PLAYER_TAG = "Player";

	public float range = 0;
	public CatController cat;

	[SerializeField]
	public LayerMask mask;

	[SerializeField]
	private Camera cam;

	void Start(){
		if (cam == null) {
			Debug.LogError ("No Camera");
			this.enabled = false;
		}

		cat.pVars.collected = false;
	}

	void FixedUpdate ()
	{
		print (cat.pVars.collected);
		if (Input.GetKeyDown (KeyCode.Q)) {
			ActivatePowerAttack ();
		}
	}

	public void ActivatePowerAttack(){
		switch(cat.pVars.powerAttackVal){
			default:
				Meat();
				break;
		}

		cat.pVars.collected = false;
	}

	[Client]
	public void Meat(){
		RaycastHit powerMeat;
		if(Physics.Raycast(cam.transform.position, GetComponent<Camera>().transform.forward, out powerMeat, range, mask)){
			if (powerMeat.collider.tag == PLAYER_TAG && powerMeat.collider.name != cat.name) {
				//CmdPlayerPowerAttack (powerMeat.collider.name);
				print(powerMeat.collider.name);
			}
		}
	}

	[Command]
	void CmdPlayerPowerAttack(string ID){
		Debug.Log (ID + " Cats");
	}
}
