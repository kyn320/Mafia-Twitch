using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : CharacterBehaviour
{
    protected override void Start()
    {
        base.Start();
        
        job = CharacterJob.Mafia;
    }

    public override void JobWork()
    {
        print("mafia work");
        base.JobWork();
    }

}
