using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : CharacterBehaviour
{
    List<CharacterBehaviour> aliveList = new List<CharacterBehaviour>();

    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Doctor;
    }


    public void SetAliveList(List<CharacterBehaviour> _alives)
    {
        aliveList = _alives;
    }


    public override void JobWork()
    {
        print("doctor Work");

        aliveList[Random.Range(0, aliveList.Count)].Heal();

        base.JobWork();
    }
}
