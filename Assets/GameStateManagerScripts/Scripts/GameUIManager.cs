using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : GameManagerBase<GameUIManager>
{
    [SerializeField]
    private RectTransform intro;

    [SerializeField]
    private RectTransform mainMenu;

    [SerializeField]
    private RectTransform optionsMenu;

    private void OnStateEntered(GameStateBase gameState)
    {
        if (gameState is IntroGameState)
        {
            SetMainMenuActive(false);
            SetIntroActive(true);
        }
        else if (gameState is MainMenuGameState)
        {
            SetMainMenuActive(true);
        }
        else if (gameState is OptionsGameState)
        {
            SetOptionsMenuActive(true);
        }
    }

    private void OnStateExited(GameStateBase gameState)
    {
        if (gameState is IntroGameState)
        {
            SetIntroActive(false);
        }
        else if (gameState is OptionsGameState)
        {
            SetOptionsMenuActive(false);
        }
        else if (gameState is MainMenuGameState)
        {
            SetMainMenuActive(false);
        }
    }

    public void SetIntroActive(bool isActive)
    {
        intro.gameObject.SetActive(isActive);
    }

    public void SetMainMenuActive(bool isActive)
    {
        mainMenu.gameObject.SetActive(isActive);
    }

    public void SetOptionsMenuActive(bool isActive)
    {
        optionsMenu.gameObject.SetActive(isActive);
    }

    protected override void Initialize()
    {
        SetMainMenuActive(false);
        SetOptionsMenuActive(false);

        var transitions = FindObjectsOfType<NamedActionTransition>();

        var buttons = GetComponentsInChildren<Button>(true);

        foreach (var transition in transitions)
        {
            foreach (var button in buttons)
            {
                if (transition.ActionName.Equals(button.name))
                {
                    button.onClick.AddListener(transition.DoAction);
                }
            }
        }

        GameStateManager.Instance.StateEntered += OnStateEntered;
        GameStateManager.Instance.StateExited += OnStateExited;
    }
}
