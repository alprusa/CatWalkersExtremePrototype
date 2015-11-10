using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void StartGame(){
		Application.LoadLevel("mainGame");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
