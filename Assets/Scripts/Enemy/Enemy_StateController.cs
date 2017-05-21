using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CharacterStatus))]
[RequireComponent(typeof(AttackHandler))]
public class Enemy_StateController : StateController
{
    public Transform eyes = null;    
    public Enemy_MovementVariables movementVariables;
    public Enemy_HitProcessingVariales hitProcessingVariables;
    
    [HideInInspector] public CharacterStatus  characterStatus   = null;
    [HideInInspector] public AttackHandler attackHandler        = null;
    [HideInInspector] public Animator anim                      = null;
    [HideInInspector] public Transform chaseTarget              = null;

	override protected void Awake () 
    {
		base.Awake();

        characterStatus = GetComponent<CharacterStatus>();
        attackHandler   = GetComponent<AttackHandler>();
        anim            = transform.GetComponentInChildren<Animator>();
        chaseTarget     = GameObject.FindGameObjectWithTag("Player").transform;
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

    public void processHitReceived()
    {
        //stays marked as wasHit until timeToForgetHit
        CancelInvoke("setHitNotReceived");
        hitProcessingVariables.wasHit = true;
        Invoke("setHitNotReceived", hitProcessingVariables.timeToForgetHit);
    }

    private void setHitNotReceived()
    {
        hitProcessingVariables.wasHit = false;
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