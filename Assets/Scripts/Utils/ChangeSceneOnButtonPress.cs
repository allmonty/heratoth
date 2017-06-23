using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeSceneOnButtonPress : MonoBehaviour {

	public string sceneName = "Game";
    public string inputButton;

    public void Update() {
		if(Input.GetButtonDown(inputButton)) {
			GameManager.instance.changeScene(sceneName);
		}
	}
}
