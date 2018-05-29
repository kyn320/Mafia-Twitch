using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public UIInGame ui;

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


    public float timer = 0;

    public void Awake()
    {

    }

    private void Start()
    {
        LoadPlayer();
        ++day;

        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return null;
        characterList[Random.Range(0, characterList.Count)].Say();
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    void LoadPlayer()
    {
        currentPlayerCount = maxPlayerCount;
        CharacterBehaviour c;
        for (int i = 0; i < maxPlayerCount; ++i)
        {
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    ++civilianCount;
                    c = new GameObject().AddComponent<Civilian>();
                    characterList.Add(c);
                    break;
                case 1:
                    if (mafiaCount > 1)
                    {
                        ++civilianCount;
                        c = new GameObject().AddComponent<Civilian>();
                        characterList.Add(c);
                    }
                    else
                    {
                        ++mafiaCount;
                        c = new GameObject().AddComponent<Mafia>();
                        characterList.Add(c);
                    }
                    break;
                case 2:
                    if (policeCount > 0)
                    {
                        ++civilianCount;
                        c = new GameObject().AddComponent<Civilian>();
                        characterList.Add(c);
                    }
                    else
                    {
                        ++policeCount;
                        c = new GameObject().AddComponent<Police>();
                        characterList.Add(c);
                    }
                    break;
                case 3:
                    if (doctorCount > 0)
                    {
                        ++civilianCount;
                        c = new GameObject().AddComponent<Civilian>();
                        characterList.Add(c);
                    }
                    else
                    {
                        ++doctorCount;
                        c = new GameObject().AddComponent<Doctor>();
                        characterList.Add(c);
                    }
                    break;
                default:
                    break;
            }
        }

    }



    public List<string> GetCharacterNames(bool _isContainDie = false)
    {
        List<string> names = new List<string>();

        for (int i = 0; i < characterList.Count; ++i)
        {
            if ((!_isContainDie && !characterList[i].isDie) || _isContainDie)
            {
                names.Add(characterList[i].openInfo.name);
            }
        }

        return names;
    }

    public List<string> GetCharacterLiveSpaces(bool _isContainDie = false)
    {
        List<string> spaces = new List<string>();

        for (int i = 0; i < characterList.Count; ++i)
        {
            if ((!_isContainDie && !characterList[i].isDie) || _isContainDie)
            {
                spaces.Add(characterList[i].openInfo.liveSpace);
            }
        }

        return spaces;
    }


}
