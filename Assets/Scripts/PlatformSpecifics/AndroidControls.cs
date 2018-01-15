using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidControls : ControlSet {

	private Canvas androidControls;
	private Button button;

	protected override void Start() {
		base.Start();
		Debug.Log("Android controls initialised!");
		androidControls = GameObject.FindWithTag("MainCanvas").GetComponent<Canvas>();
		button = GameObject.Find("AndroidControls").GetComponentInChildren<Button>();
		button.gameObject.SetActive(true);

		//Sets the UI button's function to the Boost function
		button.onClick.AddListener(Boost);
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
