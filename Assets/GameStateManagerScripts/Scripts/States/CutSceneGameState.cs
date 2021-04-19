using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneGameState : GameStateBase
{
    private bool levelLoaded = false;

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        levelLoaded = true;
    }

    private IEnumerator StateExitAsync(GameStateBase nextState)
    {
        if (!(nextState is IntroGameState) &&
            !(nextState is OptionsGameState))
        {
            SceneManager.LoadSceneAsync(nextState.name.ToString());
            SceneManager.sceneLoaded += SceneLoaded;

            while (!levelLoaded)
            {
                yield return null;
            }
        }

        base.StateExit(nextState);
    }

    public override void StateExit(GameStateBase nextState)
    {
        StartCoroutine(StateExitAsync(nextState));
    }


}
