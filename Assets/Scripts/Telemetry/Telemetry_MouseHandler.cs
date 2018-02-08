using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Telemetry_MouseHandler : MonoBehaviour {

  [SerializeField] string tagName = "TelemetryNode";

  Telemetry_TooltipHandler currentTooltipHandler = null;

	void OnEnable() {
		Debug.Log("mouse interaction onenable");
    SceneView.onSceneGUIDelegate += this.OnSceneMouseOver;
  }

  void OnSceneMouseOver(SceneView view) {
    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    RaycastHit hit;
    //And add switch Event.current.type for checking Mouse click and switch tiles
    if (Physics.Raycast (ray, out hit, 100f)) {
      if(currentTooltipHandler != null && hit.transform != currentTooltipHandler) {
        currentTooltipHandler.close();
      }
      if(hit.transform.tag.Equals(tagName)) {
        currentTooltipHandler = hit.transform.GetComponent<Telemetry_TooltipHandler>();
        currentTooltipHandler.open();
      }
    }
  }
	
}
