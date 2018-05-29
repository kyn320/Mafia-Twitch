using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public CharacterInfo info;
    public CharacterInfo openInfo;
    /// <summary>
    /// 직업
    /// </summary>
    public CharacterJob job;
    /// <summary>
    /// 사망 했는가?
    /// </summary>
    public bool isDie = false;

    public Context sayTopic;
    public Context sayAnswer;
    public List<Context> sayIntroduce = new List<Context>();

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        info = new CharacterInfo();
        info.SetRandomInfo();
        openInfo = new CharacterInfo();
        openInfo.SetFakeInfo();

    }

    public virtual void JobWork()
    {

        GameManager.Instance.EndNightWork();
    }

    public void AddTopic()
    {
        sayTopic = ContextNodeDB.Instance.GetRandomContext(ContextCategory.ThinkNameAndJob);
        TalkManager.Instance.talkTopicQueue.Add(this);
    }

    public void SayTopic()
    {
        GameManager.Instance.ui.talkBox.Say(sayTopic.say);
    }

    public void AddAnswer()
    {
        sayAnswer = ContextNodeDB.Instance.GetRandomContext(ContextCategory.Answer);
        TalkManager.Instance.talkAnswerQueue.Add(this);
    }

    public void SayAnswer()
    {
        GameManager.Instance.ui.talkBox.Say(sayAnswer.say);
    }

    public void AddIntroduce()
    {
        sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceName, info));
        sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceAge, info));
        TalkManager.Instance.talkIntroduceQueue.Add(this);
    }

    public void SayIntroduce()
    {
        List<string> sayList = new List<string>();
        for (int i = 0; i < sayIntroduce.Count; ++i)
        {
            sayList.Add(sayIntroduce[i].say);
        }
        GameManager.Instance.ui.talkBox.Say(sayList);
    }

}