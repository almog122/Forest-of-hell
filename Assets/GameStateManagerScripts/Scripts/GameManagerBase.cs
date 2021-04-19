using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerBase<T> : Singleton<T> where T : MonoBehaviour
{
    public bool Initialized { get; private set; } = false;

    protected abstract void Initialize();

    private void Start()
    {
        Initialize();
        Initialized = true;
    }
}
