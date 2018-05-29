using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    protected CharacterBehaviour character;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterBehaviour>();
    }

    public void JobWork()
    {
        character.JobWork();
    }

}
