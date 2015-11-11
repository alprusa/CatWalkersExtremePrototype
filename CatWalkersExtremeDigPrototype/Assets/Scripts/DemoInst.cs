using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoInst : MonoBehaviour {

	public Texture[] demoAnimation;
	public RawImage gifImage;
	
	private int index = 0;

	// Update is called once per frame
	void Update () {
	
		if (index > demoAnimation.Length - 1) 
			index = 0;

		gifImage.texture = demoAnimation [index];

		index++;
	}
}
