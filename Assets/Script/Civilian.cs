using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : CharacterBehaviour
{
    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Civilian;
    }
    

	
}
