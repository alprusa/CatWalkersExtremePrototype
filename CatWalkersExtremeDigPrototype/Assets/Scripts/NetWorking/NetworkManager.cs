using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string VERSION = "v0.0.1";
	public string catRoom = "CatWalkers";
	public GameObject catPreFab;
	public Transform spawnPoint;

	// Use this for initialization
/*	void Start () {
		PhotonNetwork.ConnectUsingSettings (VERSION);
	}

	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions (){isVisible = false, maxPlayers = 4};
		PhotonNetwork.JoinOrCreateRoom (catRoom, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		PhotonNetwork.Instantiate (catPreFab.name, spawnPoint.position, spawnPoint.rotation, 0);
	}*/
}
