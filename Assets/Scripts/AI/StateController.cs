using UnityEngine;
using UnityEngine.AI;

public abstract class StateController : MonoBehaviour
{
	public State currentState;

	[HideInInspector] public NavMeshAgent navMeshAgent;

	protected virtual void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	protected virtual void Update()
	{
		currentState.UpdateState(this);
	}

	public virtual void TransitionToState(State nextState)
	{
		if (nextState != currentState)
		{
			currentState = nextState;
			OnExitState();
		}
	}

	protected virtual void OnExitState() {/*Reset the states attribute here*/}
}