using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PoolEvent(GameObject p);

public interface IPoolable {
	void Recycle();
	void Init(Transform t);
	PoolEvent PoolEvent {
		get;
		set;
	}
}
