using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : CharacterBehaviour
{
    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Police;
    }

    public override void JobWork()
    {
        print("police Work");
        base.JobWork();
    }

}
