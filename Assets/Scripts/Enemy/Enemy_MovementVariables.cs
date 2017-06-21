using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy_MovementVariables
{
	public List<Transform> wayPointList;
	public int nextWayPoint = 0;
}
