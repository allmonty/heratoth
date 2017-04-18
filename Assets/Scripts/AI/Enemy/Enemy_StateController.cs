using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_StateController : StateController
{
    public Transform eyes;
    public List<Transform> wayPointList;
    public Transform chaseTarget;
    public StaminaSystem stamina;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;

    public SerializableDictionary properties;

	override protected void Awake () 
    {
		base.Awake();
        SetupAI(true, wayPointList);

        wayPointList.Where(obj => obj.name == "teste").SingleOrDefault();
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