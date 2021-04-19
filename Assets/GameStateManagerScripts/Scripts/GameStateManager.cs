using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : GameManagerBase<GameStateManager>
{
    private List<GameStateBase> gameStates = new List<GameStateBase>();

    public event GameStateEventHandler StateEntered
    {
        add
        {
            foreach(var gameState in gameStates)
            {
                gameState.StateEntered += value;
            }
        }
        remove
        {
            foreach (var gameState in gameStates)
            {
                gameState.StateEntered -= value;
            }
        }
    }

    public event GameStateEventHandler StateExited
    {
        add
        {
            foreach (var gameState in gameStates)
            {
                gameState.StateExited += value;
            }
        }
        remove
        {
            foreach (var gameState in gameStates)
            {
                gameState.StateExited -= value;
            }
        }
    }

    protected override void Initialize()
    {
        GameStateBase initialState = null;

        foreach (var gameState in gameObject.GetComponentsInChildren<GameStateBase>())
        {
            if (gameState.IsCurrentState)
            {
                if (initialState == null)
                {
                    initialState = gameState;
                }
                else
                {
                    Debug.LogError("Invalid state machine! More than one initial states!");
                }
            }

            gameStates.Add(gameState);
        }

        initialState.StateEnter(null);
    }
}
