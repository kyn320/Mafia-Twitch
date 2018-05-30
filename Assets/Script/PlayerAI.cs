using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : PlayerController
{
    /// <summary>
    /// 투표하고 싶은 대상
    /// </summary>
    public CharacterBehaviour voteTarget;
    /// <summary>
    /// 의심스러운 대상
    /// </summary>
    public CharacterBehaviour guessTarget;
    /// <summary>
    /// 의심스러운 대상의 추측하고 있는 직업
    /// </summary>
    public CharacterJob guessJob;

    public PlayerAIState state;

    protected override void Awake()
    {
        base.Awake();
        isAI = true;
    }

    private void Start()
    {
        StartCoroutine(UpdateState());
    }

    IEnumerator UpdateState()
    {
        while (true)
        {
            switch (state)
            {
                case PlayerAIState.Idle:
                    break;
                case PlayerAIState.TalkTopic:
                    break;
                case PlayerAIState.TalkAnswer:
                    break;
                case PlayerAIState.TalkIntroduce:
                    break;
                case PlayerAIState.Vote:
                    break;
            }
            yield return null;
        }
    }

    public void SetVoteTarget(CharacterBehaviour _character)
    {
        voteTarget = _character;
    }

    public void SetGuessTarget(CharacterBehaviour _character)
    {
        guessTarget = _character;
    }

    public void SetGuessJob(CharacterJob _job)
    {
        guessJob = _job;
    }

    public void Vote()
    {

    }

    public override void AddTopic()
    {
        character.sayTopic = ContextNodeDB.Instance.GetRandomContext(ContextCategory.ThinkNameAndJob);
        TalkManager.Instance.talkTopicQueue.Add(character);
    }

    public override void SayTopic()
    {
        GameManager.Instance.ui.talkBox.Say(character.sayTopic.say);
    }

    public override void AddAnswer()
    {
        character.sayAnswer = ContextNodeDB.Instance.GetRandomContext(ContextCategory.Answer);
        TalkManager.Instance.talkAnswerQueue.Add(character);
    }

    public override void SayAnswer()
    {
        GameManager.Instance.ui.talkBox.Say(character.sayAnswer.say);
    }

    public override void AddIntroduce()
    {
        character.sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceName, character.info));
        character.openInfo.name = character.sayIntroduce[0].targetName;
        character.sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceAge, character.info));
        character.openInfo.age = int.Parse(character.sayIntroduce[1].selectData[0]);
        TalkManager.Instance.talkIntroduceQueue.Add(character);
    }

    public override void SayIntroduce()
    {
        List<string> sayList = new List<string>();
        for (int i = 0; i < character.sayIntroduce.Count; ++i)
        {
            sayList.Add(character.sayIntroduce[i].say);
        }
        GameManager.Instance.ui.talkBox.Say(sayList);
    }

}

public enum PlayerAIState
{
    Idle,
    TalkTopic,
    TalkAnswer,
    TalkIntroduce,
    Vote
}