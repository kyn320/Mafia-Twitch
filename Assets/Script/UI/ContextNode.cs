using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContextNode
{
    /// <summary>
    /// 카테고리
    /// </summary>
    public ContextCategory category;
    /// <summary>
    /// 문맥 내용
    /// </summary>
    public List<string> contexts;
    public List<ContextSelectNode> selectContexts;

    public Context SetRandomContextwithCategory(CharacterInfo _info = null)
    {
        Context totalContext = new Context();

        for (int i = 0; i < contexts.Count; ++i)
        {
            totalContext.say += contexts[i] + " ";

            if (selectContexts[i].selectCategory != ContextSelectCategory.None)
            {
                ContextSelectNode selectNode = selectContexts[i];
                selectNode.contexts = ContextSelectNode.FindContextList(selectContexts[i].selectCategory, _info);
                switch (selectNode.selectCategory)
                {
                    case ContextSelectCategory.Name:
                        totalContext.targetName = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                        break;
                    case ContextSelectCategory.Job:
                        totalContext.targetjob = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                        break;
                    default:
                        break;
                }
                totalContext.say += selectNode.contexts[Random.Range(0, selectNode.contexts.Count)] + " ";
            }
        }

        return totalContext;
    }
}

public enum ContextCategory
{
    //소개
    IntroduceName,
    IntroduceAge,
    IntroduceLikeObject,
    IntroduceHateObject,
    IntroduceWellObject,
    IntroduceNotWellObject,
    //의심
    GuessName,
    GuessJob,
    //답변
    Answer,
    //생각
    ThinkNameAndJob,
    ThinkNameAndAnswer,
    //확신
    CertainNameAndJob,
    //정보 공유
    ShareNameAndJobAction,
    ShareNameAndJob
}

public enum ContextSelectCategory
{
    None,
    Name,
    Age,
    Job,
    LiveSpace,
    LikeObject,
    HateObject,
    WellObject,
    NotWellObject,
    Think,
    JobAction
}