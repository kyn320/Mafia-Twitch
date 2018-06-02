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

        Context context = new Context();
        context.category = ContextCategory.ShareNameAndJob;
        context.sayCharacter = this;
        context.target = findCharacterList[findCharacterList.Count - 1];
        context.targetjob = findCharacterList[findCharacterList.Count - 1].job;

        context.say = "내가 수사 한 결과 " + context.target.openInfo.name + "은 사실 " + context.target.info.name + "이고,\n 직업은 " + CharacterInfo.ParseJobToName(context.targetjob) + "이다.";
        context.target.SetTruethInfo();

        if (controller.isAI)
        {
            print("ai add");
            ((PlayerAI)controller).ThinkPoliceWork(context);
        }

        print("find name :" + context.target.info.name);
        print("find age :" + context.target.info.age);
        print("find job :" + CharacterInfo.ParseJobToName(context.targetjob));
        base.JobWork();
    }

}
