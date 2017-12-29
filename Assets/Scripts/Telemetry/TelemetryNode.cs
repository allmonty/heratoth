using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using UnityEngine;

public class TelemetryNode {

	TelemetryNodeType nodeType;
	string name;
	float time;
	Vector3 position;
	ExpandoObject info;

	public TelemetryNode(TelemetryNodeType nodeType, string name, Vector3 position, ExpandoObject info) {
		this.nodeType = nodeType;
		this.name = name;
		this.position = position;
		this.info = info;
		this.time = Time.realtimeSinceStartup;
	}

	public TelemetryNode(TelemetryNodeType nodeType, string name, Vector3 position)
    {
        this.nodeType = nodeType;
        this.name = name;
        this.position = position;
        this.time = Time.realtimeSinceStartup;
		this.info = new ExpandoObject();
    }

	public TelemetryNodeType getType() { return this.nodeType; }
	public string getName() { return this.name; }
	public float getTime() { return this.time; }
	public Vector3 getPosition() { return this.position; }
	public ExpandoObject getInfo() { return this.info; }

	public string toJson() {
		dynamic nodeJson = new ExpandoObject();
		nodeJson.type = this.nodeType.Value;
        nodeJson.name = this.name;
        nodeJson.time = this.time;
		nodeJson.position = new ExpandoObject();
			nodeJson.position.x = this.position.x;
			nodeJson.position.y = this.position.y;
			nodeJson.position.z = this.position.z;
		nodeJson.info = this.info;

		return JsonConvert.SerializeObject(nodeJson);
	}
}
