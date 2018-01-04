using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryController {
	
	static Telemetry_PlayerInfo playerInfo = new Telemetry_PlayerInfo();
	
	static Telemetry_RoundInfo currentRound = null;
	static float roundInitialTime = 0f;

	public static Telemetry_PlayerInfo getPlayerInfo() {
		return playerInfo;
	}

	public static void newRound(string sceneName){
		currentRound = new Telemetry_RoundInfo(sceneName);
		roundInitialTime = Time.realtimeSinceStartup;
	}

	public static void addNode(TelemetryNode node){
		currentRound.addNode(node);
	}

	public static void endRound(){
		float roundDuration = Time.realtimeSinceStartup - roundInitialTime;
		currentRound.setDuration(roundDuration);
		
		playerInfo.addRound(currentRound);
	}
}