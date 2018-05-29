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
    }

    public void Say()
    {
        sayTopic = ContextNodeDB.Instance.GetRandomContext(ContextCategory.ThinkNameAndJob);
        GameManager.Instance.ui.talkBox.Say(openInfo.name + " : " + sayTopic.say);
    }

}