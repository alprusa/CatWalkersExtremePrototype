using UnityEngine;
using System.Collections;

public class SpecialAttacks : MonoBehaviour {

	public bool speedBoost = false;
	public bool shortCut = false;
	public bool spUsed = false;

	public float newSpeed;

	private int specialAttacksTimer = 0;
	private int waitTimer = 0;
	
	// Update is called once per frame
	void Update () {
		//set how long a special attack will last and start/stop cooldown time
		if (shortCut || speedBoost) {
			spUsed = true;
			specialAttacksTimer++;
			waitTimer = 0;
		} else
			waitTimer++;

		//finish the time for the sp ghosting
		if (specialAttacksTimer > 50 && speedBoost) {
			speedBoost = false;
			specialAttacksTimer = 0;
		}

		//finish the time for the sp speedboost
		if (specialAttacksTimer > 100 && shortCut) {
			shortCut = false;
			specialAttacksTimer = 0;
		}

		//end cooldown time
		if (waitTimer > 100) {
			spUsed = false;
			waitTimer = 0;
		}
	}
	
	//trigger invisible sphere that sets the "finished" bool
	void OnTriggerStay(Collider other) 
	{
		print (other.GetComponent<Collider>().tag);
		if (other.GetComponent<Collider>().tag == "Player" && shortCut) {
			Destroy(gameObject);
		}
	}

	/*void ghosting(){
		//enable special attack for making cat invisible
		if (sp.ghosting == true) {
			transform.Find ("Cat").GetComponent<MeshRenderer> ().enabled = false;
			transform.Find ("Walker").GetComponent<MeshRenderer> ().enabled = false;
		} else {
			transform.Find ("Cat").GetComponent<MeshRenderer> ().enabled = true;
			transform.Find ("Walker").GetComponent<MeshRenderer> ().enabled = true;
		}
	}*/
}
