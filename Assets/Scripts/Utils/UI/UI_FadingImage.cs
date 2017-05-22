using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_FadingImage : MonoBehaviour {

	public Image text;

	[System.Serializable]
	public class FadeBehaviour {
		public float duration = 2f;
		public float delayToNext = 1f;
		public bool isFadeOut = false;
	}
	public List<FadeBehaviour> steps;
	
	public UnityEvent callNext;

	float timer = 0f;
	int currentStep = -1;
	bool paused = false;

	void Start()
	{
		if(steps.Count > 0)
		{
			currentStep = 0;
		}
		else
		{
			enabled = false;
		}
	}

	void Update () {
		if(!paused)
		{
			timer += Time.deltaTime;

			float alpha;
			if(steps[currentStep].isFadeOut){
				alpha = 1 - (timer / steps[currentStep].duration);
			}
			else{
				alpha = timer / steps[currentStep].duration;
			}

			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

			if(timer > steps[currentStep].duration)
			{
				timer = 0f;
				paused = true;
				Invoke("goToNextBehaviour", steps[currentStep].delayToNext);
			}
		}	
	}

	void goToNextBehaviour()
	{
		currentStep += 1;
		paused = false;

		if(currentStep >= steps.Count)
		{
			callNext.Invoke();
			enabled = false;
		}
	}
}
