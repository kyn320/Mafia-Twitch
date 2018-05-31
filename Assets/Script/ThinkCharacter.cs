using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ThinkCharacter
{
    public CharacterBehaviour target;

    public CharacterInfo info;

    public CharacterJob job;

    public ThinkCharacter()
    {

    }

    public ThinkCharacter(CharacterBehaviour _character)
    {
        target = _character;
        info = new CharacterInfo();
        info.kind.SetRandom();
        job = CharacterInfo.GetRandomJob();
    }
}
