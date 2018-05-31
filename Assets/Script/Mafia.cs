using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : CharacterBehaviour
{
    public CharacterBehaviour killTarget;

    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Mafia;
    }

    public override void JobWork()
    {
        List<string> list = GameManager.Instance.GetCharacterNames();
        string target = list[Random.Range(0, list.Count)];
        print("mafia kill : " + target);
        GameManager.Instance.FindCharacterWithName(target).isDie = true;
        base.JobWork();
    }

}
