using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameStateEventHandler(GameStateBase gameState);

public abstract class GameStateBase : MonoBehaviour
{
    public event GameStateEventHandler StateEntered;
    public event GameStateEventHandler StateExited;

    private List<TransitionBase> transitions = new List<TransitionBase>();

    private bool inTransition;

    [SerializeField]
    protected bool isCurrentState = false;
    public bool IsCurrentState
    {
        get { return isCurrentState; }
    }

    private bool wasTransitionedInto = false;
    public bool WasTransitionedInto
    {
        get { return wasTransitionedInto; }
    }

    private GameStateBase previousState = null;

    private void Start()
    {
        inTransition = false;

        foreach(var transition in gameObject.GetComponentsInChildren<TransitionBase>())
        {
            transitions.Add(transition);
        }
    }

    private void Update()
    {
        if (!IsCurrentState)
        {
            return;
        }

        GameStateBase nextState = null;
        if (!inTransition)
        {
            foreach (var transition in transitions)
            {
                if (transition.ShouldTransition())
                {
                    if (transition.TargetState != null)
                    {
                        nextState = transition.TargetState;
                    }
                    else
                    {
                        nextState = previousState;
                    }
                    break;
                }
            }
        }

        if (!inTransition && nextState != null)
        {
            inTransition = true;
            StateExit(nextState);
            inTransition = false;
        }

        if (WasTransitionedInto)
        {
            wasTransitionedInto = false;
        }
    }

    public virtual void StateEnter(GameStateBase previousState)
    {
        this.previousState = previousState;
        if (StateEntered != null)
        {
            StateEntered(this);
        }
        isCurrentState = true;
        wasTransitionedInto = true;
    }

    public virtual void StateExit(GameStateBase nextState)
    {
        isCurrentState = false;
        if (StateExited != null)
        {
            StateExited(this);
        }

        nextState.StateEnter(this);
    }


}
