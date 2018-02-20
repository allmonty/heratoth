using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

public class Telemetry_NodeInfoWindow : MonoBehaviour {

	[TextArea(5, 50)]
	public string infoText = "";

	public void setInfo(JToken info) {
		infoText = info.ToString();
	}
}
