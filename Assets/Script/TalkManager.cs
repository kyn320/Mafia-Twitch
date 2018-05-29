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
    /// <summary>
    /// 말하고 있는 주제
    /// </summary>
    public Context currentTopic;
    /// <summary>
    /// 주제의 대한 현재 이야기
    /// </summary>
    public Context currentAnswer;

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

    public void SayTopic() {
        currentTopic = talkTopicQueue[0].sayTopic;
        talkTopicQueue.RemoveAt(0);
    }

    public void SayAnswer() {
        currentAnswer = talkAnswerQueue[0].sayAnswer;
        talkAnswerQueue.RemoveAt(0);
    }
}
