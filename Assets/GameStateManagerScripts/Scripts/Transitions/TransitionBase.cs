using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBase : MonoBehaviour
{
    protected GameStateBase sourceState;

    [SerializeField]
    protected GameStateBase targetState;
    public GameStateBase TargetState
    {
        get { return targetState; }
    }

    private void Start()
    {
        if (transform.parent == null)
        {
            Debug.LogError("Unable to find parent object. Transition must have a parent");
        }

        sourceState = GetComponentInParent<GameStateBase>();

        if (sourceState == null)
        {
            Debug.LogError("Unable to find state component in parent. Parent must have a state component");
        }
    }

    public virtual bool ShouldTransition()
    {
        return sourceState.IsCurrentState && !sourceState.WasTransitionedInto;
    }
}
