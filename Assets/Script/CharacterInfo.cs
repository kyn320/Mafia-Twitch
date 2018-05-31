using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    /// <summary>
    /// 이름
    /// </summary>
    public string name;
    /// <summary>
    /// 고유 아이디
    /// </summary>
    public int id;
    /// <summary>
    /// 소개
    /// </summary>
    public string context;
    /// <summary>
    /// 나이
    /// </summary>
    public int age;
    /// <summary>
    /// 사는곳
    /// </summary>
    public string liveSpace;
    /// <summary>
    /// 성격
    /// </summary>
    public CharacterKind kind = new CharacterKind();
    /// <summary>
    /// 좋아하는 것
    /// </summary>
    public List<string> likeObjectList = new List<string>();
    /// <summary>
    /// 싫어하는 것
    /// </summary>
    public List<string> hateObjectList = new List<string>();
    /// <summary>
    /// 잘하는 것
    /// </summary>
    public List<string> wellObjectList = new List<string>();
    /// <summary>
    /// 못하는 것
    /// </summary>
    public List<string> notWellObjectList = new List<string>();

    /// <summary>
    /// Job Enum을 String으로 변환합니다.
    /// </summary>
    /// <param name="_job"></param>
    /// <returns></returns>
    public static string ParseJobToName(CharacterJob _job)
    {
        switch (_job)
        {
            case CharacterJob.Civilian:
                return "시민";
            case CharacterJob.Mafia:
                return "마피아";
            case CharacterJob.Police:
                return "경찰";
            case CharacterJob.Doctor:
                return "의사";
        }
        return "";
    }

    public static CharacterJob PareseNameToJob(string _name)
    {
        if (_name == "시민")
        {
            return CharacterJob.Civilian;
        }

        if (_name == "마피아")
        {
            return CharacterJob.Mafia;
        }

        if (_name == "경찰")
        {
            return CharacterJob.Police;
        }

        if (_name == "의사")
        {
            return CharacterJob.Doctor;
        }

        return CharacterJob.Civilian;
    }

    public static CharacterJob GetRandomJob()
    {
        return (CharacterJob)Random.Range(0, 4);
    }

    public void SetRandomInfo()
    {
        name = CharacterDB.Instance.GetNameToUse();
        age = Random.Range(18, 41);
        liveSpace = CharacterDB.Instance.GetLiveSpace();

        Dictionary<int, List<string>> likeAndHate = CharacterDB.Instance.GetLikeAndHateObjects(Random.Range(1, 4), Random.Range(1, 4));
        Dictionary<int, List<string>> wellAndNotWell = CharacterDB.Instance.GetWellAndNotWellObjects(Random.Range(1, 4), Random.Range(1, 4));

        likeObjectList = likeAndHate[1];
        hateObjectList = likeAndHate[-1];

        wellObjectList = wellAndNotWell[1];
        notWellObjectList = wellAndNotWell[-1];

        kind.SetRandom();
    }

    public void SetFakeInfo()
    {
        name = "?";
        age = 0;
        liveSpace = "?";

        likeObjectList.Add("?");
        hateObjectList.Add("?");

        wellObjectList.Add("?");
        notWellObjectList.Add("?");

        kind.SetRandom();
    }
}

public enum CharacterJob
{
    None,
    Civilian,
    Mafia,
    Police,
    Doctor
}
