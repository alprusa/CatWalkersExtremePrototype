using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Canvas menuUI;
	public Canvas instructions;
	public GameObject title;
	public GameObject demoReal;

	public void StartGame(){
		Application.LoadLevel("mainGame");
	}

	//just turn off menu and turn on instructions visual
	public void Instructions(){
		menuUI.GetComponent<Canvas> ().enabled = false;
		title.GetComponent<MeshRenderer> ().enabled = false;

		//demoReal.GetComponent<MeshRenderer> ().enabled = true;
		instructions.GetComponent<Canvas> ().enabled = true;
	}

	//reverse of Instructions func
	public void ReturnGame () {
		menuUI.GetComponent<Canvas> ().enabled = true;
		title.GetComponent<MeshRenderer> ().enabled = true;
		
		//demoReal.GetComponent<MeshRenderer> ().enabled = false;
		instructions.GetComponent<Canvas> ().enabled = false;
	}
}
