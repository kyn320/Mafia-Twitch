using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : CharacterBehaviour
{
    public List<CharacterBehaviour> findCharacterList = new List<CharacterBehaviour>();

    protected override void Start()
    {
        base.Start();
        job = CharacterJob.Police;
    }

    public override void JobWork()
    {
        List<string> list = GameManager.Instance.GetCharacterNames();
        string target = list[Random.Range(0, list.Count)];
        print("police find : " + target);
        findCharacterList.Add(GameManager.Instance.FindCharacterWithName(target));
        base.JobWork();
    }

}
