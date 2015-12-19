using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIElements : MonoBehaviour {

	public SpecialAttacks sp;
	public PlayersPowerAttack pPA;

	public Text timer;
	public Button SA1;
	public Button SA2;
	public Button PA;

	public bool finished = false;

	public RectTransform energyBar;
	public RectTransform finishBanner;
	public Text finishText;

	private int reduceTimer = 0;
	private int prevTimer =0;
	private int timeCurr = 0;

	private RectTransform panel;

	private int finishTimer = 0;
	
	// Update is called once per frame
	void Update () {
		timeCurr = ((int)Time.timeSinceLevelLoad) - reduceTimer;

		if (!finished)
			timer.GetComponent<Text> ().text = timeCurr.ToString ();
		else
			Finished ();

		depleteEnergy ();

		if(timeCurr > prevTimer + 1)
			timer.GetComponent<Text> ().color = new Color(255, 255, 255);
	}

	//maybe best to change this one to short-cuts instead
	//turn cat invisible
	public void SpecialAttack1(){
		if(!sp.spUsed)
			sp.speedBoost = true;
	}

	//speed up walk
	public void SpecialAttack2(){
		if (!sp.spUsed) 
			sp.shortCut = true;
	}

	public void depleteEnergy(){
		energyBar.localScale = new Vector3 (sp.energy, 1,1);
	}

	public void PowerAttack(){
		if (pPA.cat.pVars.collected) {
			/*reduceTimer += 4;
			timer.GetComponent<Text> ().color = new Color(255, 0, 0);
			prevTimer = timeCurr - reduceTimer;*/
			pPA.ActivatePowerAttack ();
		}
	}

	//display finish banner
	void Finished () {
		finishBanner.GetComponent<Image>().color = new Color(0, 12, 255, 180);
		finishText.GetComponent<Text>().color = new Color(255.0f, 0.0f, 0.0f, 255.0f);

		//to end the race once you've crossed the finish line for a period of time
		finishTimer++;

		if (finishTimer > 50)
			Quit ();
	}

	//return the main menu
	void Quit(){
		Application.LoadLevel ("Menu");
	}

	//restarts the game
	public void restartLevel()
	{
		Application.LoadLevel (Application.loadedLevelName);

	}
}
