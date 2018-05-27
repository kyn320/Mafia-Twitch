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

    public int age;

    public static string GetJobName(CharacterJob _job) {
        switch (_job) {
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

}

public enum CharacterJob
{
    Civilian,
    Mafia,
    Police,
    Doctor
}
