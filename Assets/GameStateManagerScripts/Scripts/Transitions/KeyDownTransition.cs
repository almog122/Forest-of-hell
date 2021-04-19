using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDownTransition : TransitionBase
{
    [Tooltip("Pressing this key will activate this transition")]
    [SerializeField]
    private KeyCode key;

    public override bool ShouldTransition()
    {
        return base.ShouldTransition() && Input.GetKeyDown(key);
    }
}
