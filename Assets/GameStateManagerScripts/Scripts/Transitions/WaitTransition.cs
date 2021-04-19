using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTransition : TransitionBase
{

    private bool TimePassed = false;

    [SerializeField]
    private float WaitTime;

    public override bool ShouldTransition()
    {
        StartCoroutine(WaitForVideo(WaitTime));

        return base.ShouldTransition() && GetTimePassed();

    }

    bool GetTimePassed()
	{
        return TimePassed;

    }


    IEnumerator WaitForVideo(float delay)
	{
		yield return new WaitForSeconds(delay);

        TimePassed = true;

    }
}
