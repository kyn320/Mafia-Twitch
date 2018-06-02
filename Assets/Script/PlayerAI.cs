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
    public ThinkCharacter guessTarget;
    /// <summary>
    /// 의심스러운 대상의 추측하고 있는 직업
    /// </summary>
    public CharacterJob guessJob;
    /// <summary>
    /// AI가 생각하는 캐릭터
    /// </summary>
    public List<ThinkCharacter> thinkCharacters;

    public PlayerAIState state;

    protected override void Awake()
    {
        base.Awake();
        isAI = true;
        AIManager.Instance.AddAI(this);
        thinkCharacters = new List<ThinkCharacter>();
    }

    private void Start()
    {
        character.nameLabel.SetCharacter(character, character.openInfo.name);
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

    public void SetGuessTarget(ThinkCharacter _character)
    {
        guessTarget = _character;
    }

    public void SetGuessJob(CharacterJob _job)
    {
        guessJob = _job;
    }

    public override void Vote()
    {
        List<ThinkCharacter> thinks = new List<ThinkCharacter>();
        for (int i = 0; i < thinkCharacters.Count; ++i)
        {
            if (thinkCharacters[i].job == CharacterJob.Mafia && !thinkCharacters[i].target.isDie)
            {
                thinks.Add(thinkCharacters[i]);
            }
        }

        if (thinks.Count < 1)
            thinkCharacters[Random.Range(0, thinkCharacters.Count)].target.AddVote();
        else
            thinks[Random.Range(0, thinks.Count)].target.AddVote();
    }

    public override void AddTopic()
    {
        character.sayTopic = ContextNodeDB.Instance.GetRandomContext(ContextCategory.ThinkNameAndJob, character.openInfo);
        TalkManager.Instance.talkTopicQueue.Add(character);
    }

    public void AddTopic(Context _context) {
        character.sayTopic = _context;
        TalkManager.Instance.talkTopicQueue.Add(character);
    }

    public override void SayTopic()
    {
        character.sayTopic.sayCharacter = character;
        AIManager.Instance.ThinkAI(character.sayTopic);
        GameManager.Instance.ui.talkBox.Say(character.sayTopic.say);
    }

    public override void AddAnswer()
    {
        character.sayAnswer = ContextNodeDB.Instance.GetRandomContext(ContextCategory.Answer, character.openInfo);
        TalkManager.Instance.talkAnswerQueue.Add(character);
    }

    public override void SayAnswer()
    {
        character.sayAnswer.sayCharacter = character;
        AIManager.Instance.ThinkAI(character.sayAnswer);
        GameManager.Instance.ui.talkBox.Say(character.sayAnswer.say);
    }

    public override void AddIntroduce()
    {
        character.sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceName, character.info));
        character.openInfo.name = character.sayIntroduce[0].selectData[0];
        character.sayIntroduce.Add(ContextNodeDB.Instance.GetRandomContext(ContextCategory.IntroduceAge, character.info));
        character.openInfo.age = int.Parse(character.sayIntroduce[1].selectData[0]);
        TalkManager.Instance.talkIntroduceQueue.Add(character);
    }

    public override void SayIntroduce()
    {
        List<string> sayList = new List<string>();
        for (int i = 0; i < character.sayIntroduce.Count; ++i)
        {
            character.sayIntroduce[i].sayCharacter = character;
            AIManager.Instance.ThinkAI(character.sayIntroduce[i]);
            sayList.Add(character.sayIntroduce[i].say);
        }
        character.nameLabel.SetName(character.openInfo.name);
        GameManager.Instance.ui.talkBox.Say(sayList);
    }

    public void Think(Context _context)
    {
        ThinkCharacter sayCharacter = null;
        ThinkCharacter target = null;

        if (_context.sayCharacter != null)
            sayCharacter = FindCharacter(_context.sayCharacter);

        if (_context.target != null)
            target = FindCharacter(_context.target);

        if ((int)_context.category < 6)
        {

            ThinkNew(_context, sayCharacter);
            return;
        }

        int truethPercent = 0;
        int liePercent = 0;

        if (sayCharacter != null && target != null)
        {
            truethPercent = 20;
            liePercent = sayCharacter.info.kind.trueth + target.info.kind.lie;
        }
        else if (sayCharacter != null)
        {
            truethPercent = 10;
            liePercent = sayCharacter.info.kind.lie;
        }
        else if (target != null)
        {
            truethPercent = 10;
            liePercent = target.info.kind.lie;
        }
        //진실 혹은 거짓을 랜덤하게 생각
        if (Random.Range(0, truethPercent) <= liePercent)
        {
            //거짓
            ThinkResult(_context, false, sayCharacter, target);
        }
        else
        {
            //진실
            ThinkResult(_context, true, sayCharacter, target);
        }
    }

    public void ThinkPoliceWork(Context _context)
    {
        ThinkCharacter target = null;

        if (_context.target != null)
            target = FindCharacter(_context.target);

        target.job = _context.targetjob;
        target.info = _context.target.info;

        AddTopic(_context);
    }

    public void ThinkNew(Context _context, ThinkCharacter _sayCharacter = null, ThinkCharacter _target = null)
    {

        if (_sayCharacter == null)
        {
            _sayCharacter = new ThinkCharacter(_context.sayCharacter);
            thinkCharacters.Add(_sayCharacter);
        }

        switch (_context.category)
        {
            //소개
            case ContextCategory.IntroduceName:
                _sayCharacter.info.name = _context.selectData[0];
                return;
            case ContextCategory.IntroduceAge:
                _sayCharacter.info.age = int.Parse(_context.selectData[0]);
                return;
            case ContextCategory.IntroduceLikeObject:
                break;
            case ContextCategory.IntroduceHateObject:
                break;
            case ContextCategory.IntroduceWellObject:
                break;
            case ContextCategory.IntroduceNotWellObject:
                break;
        }

    }

    public void ThinkResult(Context _context, bool _isTrueth, ThinkCharacter _sayCharacter = null, ThinkCharacter _target = null)
    {
        switch (_context.category)
        {
            //의심
            case ContextCategory.GuessName:
                break;
            case ContextCategory.GuessJob:
                break;
            //답변
            case ContextCategory.Answer:
                break;
            //생각
            case ContextCategory.ThinkNameAndJob:

                if (_isTrueth)
                {
                    ++_sayCharacter.info.kind.trueth;
                    --_sayCharacter.info.kind.lie;
                    _target.job = _context.targetjob;
                }
                else
                {
                    ++_sayCharacter.info.kind.lie;
                    --_sayCharacter.info.kind.trueth;
                }

                break;
            case ContextCategory.ThinkNameAndAnswer:
                break;
            //확신
            case ContextCategory.CertainNameAndJob:
                break;
            //정보 공유
            case ContextCategory.ShareNameAndJobAction:
                break;
            case ContextCategory.ShareNameAndJob:
                if (_sayCharacter.target != character)
                {
                    ++_sayCharacter.info.kind.trueth;
                    _sayCharacter.job = CharacterJob.Police;
                }
                _target.job = _context.targetjob;
                break;
        }
    }

    public ThinkCharacter FindCharacter(CharacterBehaviour _character)
    {
        if (thinkCharacters == null || thinkCharacters.Count < 1)
            return null;

        return thinkCharacters.Find(item => item.target == _character);
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