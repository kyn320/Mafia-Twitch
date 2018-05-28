using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<CharacterInfo> characterInfoList;
    public List<CharacterBehaviour> characterList;

    public CharacterBehaviour player;

    public int day = 0;
    public bool isNight = false;

    public int currentPlayerCount = 0;
    public int maxPlayerCount = 8;

    public int civilianCount = 0;
    public int mafiaCount = 0;
    public int policeCount = 0;
    public int doctorCount = 0;

    public void Awake()
    {
        LoadPlayer();
    }

    void LoadPlayer()
    {
        currentPlayerCount = maxPlayerCount;
        for (int i = 0; i < maxPlayerCount; ++i)
        {
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    ++civilianCount;
                    new GameObject().AddComponent<Civilian>();
                    break;
                case 1:
                    if (mafiaCount > 1)
                    {
                        ++civilianCount;
                        new GameObject().AddComponent<Civilian>();
                    }
                    else {
                        ++mafiaCount;
                        new GameObject().AddComponent<Mafia>();
                    }
                    break;
                case 2:
                    if (policeCount > 0)
                    {
                        ++civilianCount;
                        new GameObject().AddComponent<Civilian>();
                    }
                    else {
                        ++policeCount;
                        new GameObject().AddComponent<Police>();
                    }
                    break;
                case 3:
                    if (doctorCount > 0)
                    {
                        ++civilianCount;
                        new GameObject().AddComponent<Civilian>();
                    }
                    else {
                        ++doctorCount;
                        new GameObject().AddComponent<Doctor>();
                    }
                    break;
                default:
                    break;
            }
        }
    }



    public List<string> GetCharacterNames()
    {
        List<string> names = new List<string>();

        for (int i = 0; i < characterInfoList.Count; ++i)
        {
            names.Add(characterInfoList[i].name);
        }

        return names;
    }

    public List<string> GetCharacterLiveSpaces()
    {
        List<string> spaces = new List<string>();

        for (int i = 0; i < characterInfoList.Count; ++i)
        {
            spaces.Add(characterInfoList[i].liveSpace);
        }

        return spaces;
    }


}
