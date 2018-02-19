using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

public class Telemetry_TooltipHandler : MonoBehaviour {

	[SerializeField] GameObject tooltip = null;

	[TextArea(5, 50)]
	public string infoText = "";

	JToken nodeInfo = null;

	public void open() {
		tooltip.SetActive(true);
	}

	public void close() {
		tooltip.SetActive(false);
	}

	public void setInfo(JToken info) {
		nodeInfo = info;
		infoText = info.ToString();
	}
}
