using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeTracker : MonoBehaviour {
	
	static public GameTimeTracker instance = null;

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}
		
	}
}
