using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static public GameManager instance = null;

	public GameObject gameOverDisplay;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(this);
	}

	public void gameOver() {
		gameOverDisplay.SetActive(true);
		StartCoroutine(reloadCurrentScene(5));
	}

	IEnumerator reloadCurrentScene(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
