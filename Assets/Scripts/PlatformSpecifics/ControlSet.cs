using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ControlEventJump();
public delegate void ControlEventAxis(float axis);

public class ControlSet {

	public ControlEventJump jumpInput;
	public ControlEventAxis moveInput;

	protected virtual void Start() {
	}

	public static ControlSet GetControls() {
		if(Application.isEditor)
			return new PcControls();
		switch(Application.platform) {
#if !DISABLE_SYSTEM
			case RuntimePlatform.WindowsPlayer:
				return new PcControls();
			case RuntimePlatform.Android:
				return new AndroidControls();
#endif
			default:
				return new DummyControls();
		}
	}

	public virtual void CheckInput() {
	}

}
