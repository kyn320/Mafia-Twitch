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
    /// 고정된 내용
    /// </summary>
    public List<string> fixContext;
    /// <summary>
    /// 선택하는 내용
    /// </summary>
    public List<ContextSelect> selectContext;

    public static List<string> FindContextList(ContextSelect _select)
    {
        List<string> selectContextList = new List<string>();

        switch (_select)
        {
            case ContextSelect.Name:
                return GameManager.Instance.GetCharactersName();
            case ContextSelect.Age:
                for (int i = -2; i < 3; ++i)
                {
                    selectContextList.Add((GameManager.Instance.player.info.age + i).ToString());
                }
                return selectContextList;
            case ContextSelect.Job:
                for (int i = 0; i < 4; ++i)
                {
                    selectContextList.Add(CharacterInfo.GetJobName((CharacterJob)i));
                }
                return selectContextList;
            case ContextSelect.Think:
                selectContextList.Add("그렇다");
                selectContextList.Add("그렇지 않다");
                return selectContextList;

            default:
                Debug.LogError("Context Node Find Error! not found category");
                break;
        }

        return null;
    }
}

public enum ContextCategory
{
    IntroduceName,
    IntroduceAge,
    GuessJob,
    ThinkAnswer,
    FindJob
}

public enum ContextSelect
{
    None,
    Name,
    Age,
    Job,
    Think
}