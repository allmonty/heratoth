using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_StateController : StateController
{
    public CharacterStatus  characterStatus = null;    
    public AttackHandler attackHandler = null;
    
    public Transform eyes = null;    
    public Transform chaseTarget = null;

    public Enemy_MovementVariables movementVariables;

    private bool aiActive = true;

	override protected void Awake () 
    {
		base.Awake();
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
}