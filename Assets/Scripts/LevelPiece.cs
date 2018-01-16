using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPiece : MonoBehaviour {
	private void FixedUpdate() {
		if(Vector3.Distance(transform.position, PlayerManager.instance.transform.position) > 35 && transform.position.z < PlayerManager.instance.transform.position.z) {
			PlayerManager.instance.score++;
			Init(LevelManager.InitPlace);
		}
	}
	public void Init(Transform t) {
		transform.position = t.position;
	}
}
