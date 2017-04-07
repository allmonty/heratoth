using System.Collections.Generic;
using UnityEngine;

public class Enemy_StateController : StateController
{
    public Transform eyes;
    public List<Transform> wayPointList;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;
	
	override protected void Awake () 
    {
		base.Awake();
        SetupAI(true, wayPointList);
    }

    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive) 
        {
            navMeshAgent.enabled = true;
        } else 
        {
            navMeshAgent.enabled = false;
        }
    }

    override protected void Update()
    {
        if (!aiActive) return;

		base.Update();
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null) 
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere (eyes.position, 0.5f);
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

	override protected void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}