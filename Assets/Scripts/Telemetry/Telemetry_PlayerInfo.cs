using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Telemetry_PlayerInfo : ISerializable {

	List<Telemetry_RoundInfo> rounds;

	public Telemetry_PlayerInfo() {
		rounds = new List<Telemetry_RoundInfo>();
	}

	public void addRound(Telemetry_RoundInfo roundInfo) {
		this.rounds.Add(roundInfo);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)	{
		info.AddValue("Rounds", this.rounds, typeof(List<Telemetry_RoundInfo>));
	}
}
