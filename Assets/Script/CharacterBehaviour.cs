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

    SpriteRenderer spriteRenderer;
    public PlayerController controller;

    public UINameLabel nameLabel;

    protected virtual void Awake()
    {
        controller = GetComponent<PlayerController>();
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer.sprite = CharacterDB.Instance.GetRandomSprite();
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

}