using UnityEngine;
using System.Collections;

public class AudioKeep : MonoBehaviour {

	public string chosenCat = "SpeedBoost";
	public string chosenWalker = "Shortcuts";

	// Update is called once per frame
	void Awake () {
		//DontDestroyOnLoad (transform.gameObject);
	}

	public void CatChosen0(){
		chosenCat = "SpeedBoost";
		LoadWalkerSelection ();
	}

	public void CatChosen1(){
		chosenCat = "Shortcuts";
		LoadWalkerSelection ();
	}

	public void WalkerChosen0(){
		chosenWalker = "SpeedBoost";
		LoadGame ();
	}
	
	public void WalkerChosen1(){
		chosenWalker = "Shortcuts";
		LoadGame ();
	}

	private void LoadWalkerSelection(){
		Application.LoadLevel ("WalkerSelection");
	}

	private void LoadGame(){
		Application.LoadLevel ("mainGame");
	}
}
