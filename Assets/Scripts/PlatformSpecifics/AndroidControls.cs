using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidControls : ControlSet {

	private RectTransform androidControls;

	public override void Start() {
		base.Start();
		Debug.Log("Android controls initialised!");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		androidControls = GameObject.Find("AndroidControls").GetComponent<RectTransform>();
		androidControls.GetChild(0).gameObject.SetActive(true);

		//Sets the UI button's function to the Boost function
		androidControls.GetChild(0).GetComponent<Button>().onClick.AddListener(Boost);
	}

	public override void CheckInput() {
		base.CheckInput();

		//Gets A/D or <-/-> input
		moveInput(Input.acceleration.x);
	}

	public void Boost() {
		jumpInput();
	}




}
