using UnityEngine;

[CreateAssetMenu (menuName = "AI/State")]
public class State : ScriptableObject 
{
    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.gray;

    public void Init(StateController controller) {
        foreach(Action action in actions) {
            action.Init(controller);
        }
    }

    public void UpdateState(StateController controller)
    {
        DoActions (controller);
        CheckTransitions (controller);
    }

    public virtual void Clear(StateController controller){
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Clear(controller);
        }
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                if(transitions[i].trueState != controller.currentState && transitions[i].trueState != null)
                    controller.TransitionToState(transitions[i].trueState);
            } else 
            {
                if(transitions[i].trueState != controller.currentState && transitions[i].falseState != null)
                    controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}