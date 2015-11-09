using UnityEngine;
using System.Collections;

[System.Serializable]
public class PS4_Controller : MonoBehaviour {

	public byte[] _inputBuffer;

	void FixedUpdate(){
		SpecialAttack();
		PowerAttack();
		Cancel ();
		//motionSensor ();
	}

	void SpecialAttack(){
		if(Input.GetButton("PS4_R1")) print("PS4_R1");
		if(Input.GetButton("PS4_L1")) print("PS4_L1");
	}
	
	void PowerAttack(){
		if(Input.GetButton("PS4_X")) print("PS4_X");
	}

	void Cancel(){
		if(Input.GetButton("PS4_O")) print("PS4_O");
	}

	void Confirm(){
		if(Input.GetButton("PS4_X")) print("PS4_X");
	}

	/*void motionSensor(){
		Vector3 acceleration = new Vector3 (
			System.BitConverter.ToInt16 (_inputBuffer, 19),
			System.BitConverter.ToInt16 (_inputBuffer, 21),
			System.BitConverter.ToInt16 (_inputBuffer, 23)
		) / 8192f;
		
		Vector3 gyro = new Vector3 (
			System.BitConverter.ToInt16 (_inputBuffer, 13),
			System.BitConverter.ToInt16 (_inputBuffer, 15),
			System.BitConverter.ToInt16 (_inputBuffer, 17)
		) / 1024f;

		print (acceleration);
	}*/
}
