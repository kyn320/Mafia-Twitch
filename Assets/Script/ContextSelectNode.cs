using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContextSelectNode
{
    /// <summary>
    /// 선택하는 내용
    /// </summary>
    public ContextSelectCategory selectCategory;

    public List<string> contexts;

    public static List<string> FindContextList(ContextSelectCategory _select)
    {
        List<string> selectContextList = new List<string>();

        switch (_select)
        {
            case ContextSelectCategory.Name:
                return GameManager.Instance.GetCharacterNames();
            case ContextSelectCategory.Age:
                for (int i = -2; i < 3; ++i)
                {
                    selectContextList.Add((GameManager.Instance.player.info.age + i).ToString());
                }
                return selectContextList;
            case ContextSelectCategory.Job:
                for (int i = 0; i < 4; ++i)
                {
                    selectContextList.Add(CharacterInfo.GetJobName((CharacterJob)i));
                }
                return selectContextList;
            case ContextSelectCategory.LiveSpace:
                return GameManager.Instance.GetCharacterLiveSpaces();
            case ContextSelectCategory.LikeObject:
                break;
            case ContextSelectCategory.HateObject:
                break;
            case ContextSelectCategory.WellObject:
                break;
            case ContextSelectCategory.NotWellObject:
                break;
            case ContextSelectCategory.JobAction:
                selectContextList.Add("죽였다.");
                selectContextList.Add("수사했다.");
                selectContextList.Add("살렸다.");
                return selectContextList;
            default:
                break;
        }

        return null;
    }


}
