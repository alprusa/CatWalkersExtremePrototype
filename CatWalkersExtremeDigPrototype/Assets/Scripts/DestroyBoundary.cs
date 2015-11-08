using UnityEngine;
using System.Collections;

public class DestroyBoundary : MonoBehaviour {

	void OnTriggerExit(Collider obj){
		Destroy (obj.gameObject);
	}

	//create a restart respawn function so that the game doesn't just end cause you've left the field
}
