﻿using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	[SerializeField]
	string remoteLayerName;

	Camera sceneCamera;

	void Start(){
		if (!isLocalPlayer) {
			DisableComponents ();
			AssignRemoteLayer ();
		} else {
			sceneCamera = Camera.main;
			if (sceneCamera != null) {
				Camera.main.gameObject.SetActive (false);
			}
		}

		RegisterPlayer ();
	}

	void RegisterPlayer(){
		string ID = "Cat" + GetComponent<NetworkIdentity> ().netId;
		transform.name = ID;
	}

	void DisableComponents(){
		for (int i = 0; i < componentsToDisable.Length; i++) {
			componentsToDisable [i].enabled = false;
		}
	}

	void AssignRemoteLayer(){
		gameObject.layer = LayerMask.NameToLayer (remoteLayerName);
	}

	void OnDisable(){
		if (sceneCamera != null) {
			sceneCamera.gameObject.SetActive (true);
		}
	}
}
