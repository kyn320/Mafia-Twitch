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
        totalContext.category = category;

        for (int i = 0; i < contexts.Count; ++i)
        {
            totalContext.say += contexts[i] + " ";

            if (selectContexts[i].selectCategory != ContextSelectCategory.None)
            {
                ContextSelectNode selectNode = selectContexts[i];
                selectNode.contexts = ContextSelectNode.FindContextList(selectContexts[i].selectCategory, _info);
                string selectStr = "";
                switch (selectNode.selectCategory)
                {
                    case ContextSelectCategory.AllName:
                    case ContextSelectCategory.AliveName:
                        if (category.Equals(ContextCategory.IntroduceName))
                        {
                            if (Random.Range(0, 11) <= 10 - _info.kind.lie)
                            {
                                int loop = 0;
                                do
                                {
                                    selectStr = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                                    ++loop;

                                    if (loop > 30)
                                    {
                                        Debug.Log("loopOver");
                                        break;
                                    }

                                } while (CharacterDB.Instance.CheckUseFakeName(selectStr));

                                CharacterDB.Instance.AddUseFakeName(selectStr);
                                totalContext.isTrueth = false;
                            }
                            else
                            {
                                selectStr = _info.name;
                                CharacterDB.Instance.AddUseFakeName(selectStr);
                            }
                        }
                        else
                        {
                            selectStr = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                            totalContext.target = GameManager.Instance.FindCharacterWithFakeName(selectStr);
                        }
                        break;
                    case ContextSelectCategory.Job:
                        selectStr = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                        totalContext.targetjob = CharacterInfo.PareseNameToJob(selectStr);
                        break;
                    default:
                        selectStr = selectNode.contexts[Random.Range(0, selectNode.contexts.Count)];
                        break;
                }

                totalContext.selectData.Add(selectStr);
                totalContext.say += selectStr + " ";
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
    AllName,
    AllCharactersName,
    AliveName,
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