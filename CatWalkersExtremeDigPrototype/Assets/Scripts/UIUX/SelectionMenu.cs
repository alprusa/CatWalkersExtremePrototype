using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionMenu : MonoBehaviour {

	public static SelectionMenu control;

	//Cat Walker Screen
	public Canvas catScreen;
	public RawImage catImg;
	public Texture catSpeedBoost;
	public Texture catShortCuts;
	public Text catDescription;

	private string shortCutsCatStr = "This cat allows you to take shortcuts.\n\nActivate by pressing the SA1 button on the HUD.";
	private string speedboostCatStr = "This cat gives a temporary speed boost\n\nActivate by pressing the SA1 button on the HUD.";

	public Canvas walkerScreen;
	public RawImage walkerImg;
	public Texture walkerSpeedBoost;
	public Texture walkerShortCuts;
	public Text descriptionWalker;
	//public Button walkerButton;

	private string shortCutsWalkerStr = "This walker allows you to take shortcuts.\n\nActivate by pressing the SA2 button on the HUD.";
	private string speedboostWalkerStr = "This walker gives a temporary speed boost\n\nActivate by pressing the SA2 button on the HUD.";

	public int catChosen = 0;
	public int walkerChosen = 0;

	// Update is called once per frame
	void Update () {
		if(control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy(gameObject);
		}
	}

	public void Cancel(){
		Application.LoadLevel ("Menu");
	}

	public void ConfirmCat(){
		catScreen.GetComponent<Canvas> ().enabled = false;

		walkerScreen.GetComponent<Canvas> ().enabled = true;

	}

	public void ConfirmWalker(){
		Application.LoadLevel ("mainGame");
	}

	public void cycleCats(){
		//player gets speedboost
		if (catChosen == 0) {
			catImg.GetComponent<RawImage> ().texture = catSpeedBoost;
			catDescription.GetComponent<Text> ().text = speedboostCatStr;
		}

		//player gets to take shortcuts
		if (catChosen == 1) {
			catImg.GetComponent<RawImage> ().texture = catShortCuts;
			catDescription.GetComponent<Text> ().text = shortCutsCatStr;
		}

		if (catChosen == 0)
			catChosen = 1;
		else
			catChosen = 0;
	}

	public void cycleWalkers(){
		//player gets speedboost
		if (walkerChosen == 0) {
			walkerImg.GetComponent<RawImage> ().texture = walkerSpeedBoost;
			descriptionWalker.GetComponent<Text> ().text = speedboostWalkerStr;
		}
		
		//player gets to take shortcuts
		if (walkerChosen == 1) {
			walkerImg.GetComponent<RawImage> ().texture = walkerShortCuts;
			descriptionWalker.GetComponent<Text> ().text = shortCutsWalkerStr;
		}
		
		if (walkerChosen == 0)
			walkerChosen = 1;
		else
			walkerChosen = 0;
	}
}
