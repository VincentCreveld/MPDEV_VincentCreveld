using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : ControlSet {

	protected override void Start() {
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
