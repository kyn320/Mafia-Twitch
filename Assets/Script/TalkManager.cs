using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : Singleton<TalkManager>
{

    /// <summary>
    /// 토픽 말하는 순서
    /// </summary>
    public List<CharacterBehaviour> talkTopicQueue;
    public List<CharacterBehaviour> talkAnswerQueue;
    public List<CharacterBehaviour> talkIntroduceQueue;
    /// <summary>
    /// 말하고 있는 주제
    /// </summary>
    public Context currentTopic;
    /// <summary>
    /// 주제의 대한 현재 이야기
    /// </summary>
    public Context currentAnswer;

    public TalkCategory talkCategory;

    public void AddTalkTopicQueue(CharacterBehaviour _character)
    {
        talkTopicQueue.Add(_character);
    }

    public void SubTalkTopicQueue(CharacterBehaviour _character)
    {
        talkTopicQueue.Remove(_character);
    }

    public void AddTalkAnswerQueue(CharacterBehaviour _character)
    {
        talkAnswerQueue.Add(_character);
    }

    public void SubTalkAnswerQueue(CharacterBehaviour _character)
    {
        talkAnswerQueue.Remove(_character);
    }

    public void SayTopic()
    {
        talkCategory = TalkCategory.Topic;
        currentTopic = talkTopicQueue[0].sayTopic;
        talkTopicQueue[0].SayTopic();
        talkTopicQueue.RemoveAt(0);
    }

    public void SayAnswer()
    {
        talkCategory = TalkCategory.Answer;
        currentAnswer = talkAnswerQueue[0].sayAnswer;
        talkAnswerQueue[0].SayAnswer();
        talkAnswerQueue.RemoveAt(0);
    }

    public void SayIntroduce()
    {
        talkCategory = TalkCategory.Introduce;
        talkIntroduceQueue[0].SayIntroduce();
        talkIntroduceQueue.RemoveAt(0);
    }

    public void EndSay()
    {
        switch (talkCategory)
        {
            case TalkCategory.Topic:

                break;
            case TalkCategory.Answer:

                break;
            case TalkCategory.Introduce:
                if (talkIntroduceQueue.Count < 1)
                {
                    GameManager.Instance.NextTime();
                    talkCategory = TalkCategory.Topic;
                }
                else
                    SayIntroduce();
                break;
            default:
                break;
        }
    }
}

public enum TalkCategory
{
    Topic,
    Answer,
    Introduce
}