using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public UIInGame ui;

    public List<CharacterBehaviour> characterList;

    public List<CharacterBehaviour> nightWorkQueue;

    public List<CharacterBehaviour> mafia;
    public List<CharacterBehaviour> police;
    public List<CharacterBehaviour> doctor;

    public CharacterBehaviour player;

    public int day = -1;
    public bool isNight = false;

    public int currentPlayerCount = 0;
    public int maxPlayerCount = 8;

    public int civilianCount = 0;
    public int mafiaCount = 0;
    public int policeCount = 0;
    public int doctorCount = 0;

    public float timer = 0;

    public int nightWorkCount;
    public int maxNightWorkCount;

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
        Introduce();
    }

    void Introduce()
    {
        for (int i = 0; i < characterList.Count; ++i)
        {
            characterList[i].AddIntroduce();
        }

        TalkManager.Instance.SayIntroduce();
    }

    public void NextDay()
    {
        ++day;
        StartSunWork();
    }

    public void NextTime()
    {
        isNight = !isNight;
        if (isNight)
        {
            //밤 시간대 액션 시작
            StartNightWork();
        }
        else {
            //밤 시간대 액션 결과 표시
            //2분 토의 시간 시작
            NextDay();
        }
    }

    public void StartSunWork()
    {

    }

    public void EndSunWork()
    {

    }

    public void StartNightWork()
    {
        nightWorkCount = 0;
        mafia = FindCharacterJob(CharacterJob.Mafia);
        police = FindCharacterJob(CharacterJob.Police);
        doctor = FindCharacterJob(CharacterJob.Doctor);

        if (day < 2)
        {
            maxNightWorkCount = mafiaCount + policeCount;

            for (int i = 0; i < mafia.Count; ++i)
            {
                nightWorkQueue.Add(mafia[i]);
            }

            for (int i = 0; i < police.Count; ++i)
            {
                nightWorkQueue.Add(police[i]);
            }

        }
        else {
            maxNightWorkCount = mafiaCount + policeCount + doctorCount;

            for (int i = 0; i < mafia.Count; ++i)
            {
                nightWorkQueue.Add(mafia[i]);
            }

            for (int i = 0; i < police.Count; ++i)
            {
                nightWorkQueue.Add(police[i]);
            }

            for (int i = 0; i < doctor.Count; ++i)
            {
                nightWorkQueue.Add(doctor[i]);
            }
        }

        //for (int i = 0; i < mafia.Count; ++i)
        //{
        //    mafia[i].JobWork();
        //}

        nightWorkQueue[0].JobWork();
    }

    public void EndNightWork()
    {
        nightWorkQueue.RemoveAt(0);

        ++nightWorkCount;

        if (nightWorkQueue.Count < 1)
        {
            NextTime();
        }
        else
            nightWorkQueue[0].JobWork();

        //if (day < 2)
        //{
        //    if (mafiaCount <= nightWorkCount)
        //    {
        //
        //    }
        //    else if (mafiaCount + policeCount <= nightWorkCount)
        //    {
        //
        //    }
        //}
        //else {
        //    if (mafiaCount <= nightWorkCount)
        //    {
        //
        //    }
        //    else if (mafiaCount + policeCount <= nightWorkCount)
        //    {
        //
        //    }
        //    else if (mafiaCount + policeCount + doctorCount <= nightWorkCount)
        //    {
        //
        //    }
        //}
    }

    public void StartVote()
    {

    }

    public void EndVote()
    {

    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    void LoadPlayer()
    {
        currentPlayerCount = maxPlayerCount;
        CharacterBehaviour c = null;
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
            if (i == 0)
                player = c;
        }

    }



    public List<string> GetCharacterNames(bool _isContainDie = false)
    {
        List<string> names = new List<string>();

        for (int i = 0; i < characterList.Count; ++i)
        {
            if ((!_isContainDie && !characterList[i].isDie) || _isContainDie)
            {
                names.Add(characterList[i].info.name);
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
                spaces.Add(characterList[i].info.liveSpace);
            }
        }

        return spaces;
    }

    public List<CharacterBehaviour> FindCharacterJob(CharacterJob _job)
    {
        List<CharacterBehaviour> resultList = new List<CharacterBehaviour>();

        for (int i = 0; i < characterList.Count; ++i)
        {
            if (characterList[i].job == _job)
                resultList.Add(characterList[i]);
        }

        return resultList;
    }


}
