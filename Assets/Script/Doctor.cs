using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : CharacterBehaviour
{
    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Doctor;
    }

    public override void JobWork()
    {
        print("doctor Work");
        base.JobWork();
    }
}
