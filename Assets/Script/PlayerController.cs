using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterBehaviour))]
public class PlayerController : MonoBehaviour
{
    public bool isAI = false;

    public CharacterBehaviour character;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterBehaviour>();
        character.controller = this;
    }

    public virtual void JobWork()
    {
        character.JobWork();
    }

    public virtual void Vote() {

    }

    public virtual void AddTopic()
    {

    }

    public virtual void SayTopic()
    {

    }

    public virtual void AddAnswer()
    {

    }

    public virtual void SayAnswer()
    {

    }

    public virtual void AddIntroduce()
    {

    }

    public virtual void SayIntroduce()
    {

    }

}
