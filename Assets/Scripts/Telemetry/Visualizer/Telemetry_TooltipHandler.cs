using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telemetry_TooltipHandler : MonoBehaviour {

	[SerializeField] GameObject tooltip = null;

	public void open(Camera camera) {
		tooltip.transform.LookAt(camera.transform.position, camera.transform.up);
		tooltip.SetActive(true);
	}

	public void close() {
		tooltip.SetActive(false);
	}
}
