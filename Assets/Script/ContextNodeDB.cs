using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextNodeDB : Singleton<ContextNodeDB>
{
    //소개
    public List<ContextNode> IntroduceName;
    public List<ContextNode> IntroduceAge;
    public List<ContextNode> IntroduceLikeObject;
    public List<ContextNode> IntroduceHateObject;
    public List<ContextNode> IntroduceWellObject;
    public List<ContextNode> IntroduceNotWellObject;
    //의심
    public List<ContextNode> GuessName;
    public List<ContextNode> GuessJob;
    //답변
    public List<ContextNode> Answer;
    //생각
    public List<ContextNode> ThinkNameAndJob;
    public List<ContextNode> ThinkNameAndAnswer;
    //확신
    public List<ContextNode> CertainNameAndJob;
    //정보 공유
    public List<ContextNode> ShareNameAndJobAction;
    public List<ContextNode> ShareNameAndJob;


    public ContextNode node;

    public List<ContextNode> GetNodeList(ContextCategory _category)
    {
        switch (_category)
        {
            //소개
            case ContextCategory.IntroduceName:
                return IntroduceName;
            case ContextCategory.IntroduceAge:
                return IntroduceAge;
            case ContextCategory.IntroduceLikeObject:
                return IntroduceLikeObject;
            case ContextCategory.IntroduceHateObject:
                return IntroduceHateObject;
            case ContextCategory.IntroduceWellObject:
                return IntroduceWellObject;
            case ContextCategory.IntroduceNotWellObject:
                return IntroduceNotWellObject;
            //의심
            case ContextCategory.GuessName:
                return GuessName;
            case ContextCategory.GuessJob:
                return GuessJob;
            //답변
            case ContextCategory.Answer:
                return Answer;
            //생각
            case ContextCategory.ThinkNameAndJob:
                return ThinkNameAndJob;
            case ContextCategory.ThinkNameAndAnswer:
                return ThinkNameAndAnswer;
            //확신
            case ContextCategory.CertainNameAndJob:
                return CertainNameAndJob;
            //정보 공유
            case ContextCategory.ShareNameAndJobAction:
                return ShareNameAndJobAction;
            case ContextCategory.ShareNameAndJob:
                return ShareNameAndJob;
        }

        return null;
    }

    public Context GetRandomContext(ContextCategory _category)
    {
        List<ContextNode> nodes = GetNodeList(_category);
        int rand = Random.Range(0, nodes.Count);
        return nodes[rand].SetRandomContextwithCategory();
    }
}
