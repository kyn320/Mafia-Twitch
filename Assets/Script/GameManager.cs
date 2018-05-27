using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<CharacterInfo> characterInfoList;

    public CharacterBehaviour player;

    public List<string> GetCharactersName()
    {
        List<string> names = new List<string>();

        for (int i = 0; i < characterInfoList.Count; ++i)
        {
            names.Add(characterInfoList[i].name);
        }

        return names;
    }


}
