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

    private void Start()
    {
        StartCoroutine(UpdateState());
    }

    IEnumerator UpdateState()
    {
        while (true)
        {

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

    public void CreateTopic()
    {

    }

    public void CreateAnswer() {

    }

    public void Vote()
    {

    }
}

public enum PlayerAIState
{
    Idle,
    TalkTopic,
    TalkAnswer,
    Vote
}