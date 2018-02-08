using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telemetry_TooltipHandler : MonoBehaviour {

	[SerializeField] GameObject tooltip = null;

	public void open() {
		tooltip.SetActive(true);
	}

	public void close() {
		tooltip.SetActive(false);
	}
}
