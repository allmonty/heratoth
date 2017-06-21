using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_StateController : StateController
{
    public Transform eyes = null;    
    public Enemy_MovementVariables movementVariables;
    
    public bool heardSound = false;
    
    [HideInInspector] public Animator anim                      = null;
    [HideInInspector] public Transform chaseTarget              = null;

	override protected void Awake () 
    {
		base.Awake();

        anim            = transform.GetComponentInChildren<Animator>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) chaseTarget = player.transform;
    }

    override protected void Update()
    {
		base.Update();
    }

    public void turnOffAI()
    {
        currentState.Clear(this);
        navMeshAgent.isStopped = true;
        enabled = false;
    }

    void OnDrawGizmos()
    {
        if (currentState != null) 
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere (transform.position, 1f);
        }
    }
}