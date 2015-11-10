using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIElements : MonoBehaviour {

	public SpecialAttacks sp;

	public Text timer;
	public Button SA1;
	public Button SA2;
	public Button PA;

	public bool finished = false;

	public RectTransform finishBanner;
	public Text finishText;

	private RectTransform panel;
	
	// Update is called once per frame
	void Update () {
		if (!finished)
			timer.GetComponent<Text> ().text = ((int)Time.timeSinceLevelLoad).ToString ();
		else
			Finished ();
	}

	//maybe best to change this one to short-cuts instead
	//turn cat invisible
	public void SpecialAttack1(){
		if(!sp.spUsed)
			sp.speedBoost = true;
	}

	//speed up walk
	public void SpecialAttack2(){
		if(!sp.spUsed)
			sp.shortCut = true;
	}

	//display finish banner
	void Finished () {
		finishBanner.GetComponent<Image>().color = new Color(0, 12, 255, 180);
		finishText.GetComponent<Text>().color = new Color(255.0f, 0.0f, 0.0f, 255.0f);
	}

	//restarts the game
	public void restartLevel()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
}
