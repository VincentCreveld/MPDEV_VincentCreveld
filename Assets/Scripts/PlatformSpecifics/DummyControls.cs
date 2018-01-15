using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControls : ControlSet {

	protected override void Start() {
		base.Start();
		Debug.Log("No controls initialised, platform not compatible!");
		Application.Quit();
	}
}
