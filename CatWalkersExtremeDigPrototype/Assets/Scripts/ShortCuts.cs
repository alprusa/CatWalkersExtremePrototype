using UnityEngine;
using System.Collections;

public class ShortCuts : MonoBehaviour {

	public GameObject citty;
	public int distanceAway;

	// Update is called once per frame
	void Update () {
		Vector3 catPos = citty.transform.position;
		bool shortCut = citty.GetComponent<SpecialAttacks>().shortCut;
		float distance = Distance (transform.position.x, catPos.x, transform.position.y, catPos.y);

		if (distance < distanceAway && shortCut) {
			Destroy (gameObject);
		}
	}

	//trigger destroy short-cut box
	float Distance(float x1, float x2, float y1, float y2) 
	{
		return Mathf.Sqrt(Mathf.Pow(x2-x1, 2) + Mathf.Pow(y2-y1, 2));
	}
}
