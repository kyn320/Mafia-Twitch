using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForMethod : CustomYieldInstruction
{
    public bool isFinish = false;


    public override bool keepWaiting
    {
        get
        {
            return !isFinish;
        }
    }

    public WaitForMethod(bool _isFinish)
    {
        isFinish = _isFinish;
    }

}
