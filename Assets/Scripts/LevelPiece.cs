using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPiece : MonoBehaviour, IPoolable {

	public PoolEvent poolEvent;

	public void Recycle() {
		if(poolEvent != null)
			poolEvent(gameObject);
	}

	public void Init(Transform t) {
		transform.position = t.position;
	}

	public PoolEvent PoolEvent {
		get { return poolEvent; }
		set { poolEvent += value; }
	}
}
