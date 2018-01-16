using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcControls : ControlSet {

	public override void Start() {
		base.Start();
		Debug.Log("Pc controls initialised!");
	}

	public override void CheckInput() {
		base.CheckInput();

		//Gets A/D or <-/-> input
		moveInput(Input.GetAxisRaw("Horizontal"));

		//Gets jump input
		if(Input.GetButtonDown("Jump")) {
			jumpInput();
			Debug.Log("Boost!");
		}
	}


}
