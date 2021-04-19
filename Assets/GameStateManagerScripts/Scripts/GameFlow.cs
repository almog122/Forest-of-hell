using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [Header("Game States")]

    [SerializeField]
    private GameStateManager gameStateManagerPrefab;

    [Header("Game UI")]

    [SerializeField]
    private GameUIManager gameUIManagerPrefab;

    private IEnumerator InitializeManagers()
    {
        GameStateManager.Instantiate(gameStateManagerPrefab);
        while (!GameStateManager.Instance.Initialized)
        {
            yield return null;
        }

        GameUIManager.Instantiate(gameUIManagerPrefab);
        while (!GameUIManager.Instance.Initialized)
        {
            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(InitializeManagers());
    }
}
