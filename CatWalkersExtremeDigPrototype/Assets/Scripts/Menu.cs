using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void StartGame(){
		Application.LoadLevel("mainGame");
	}

	public void Instructions(){
		//disable menu ui and create instructions interface
	}
}
