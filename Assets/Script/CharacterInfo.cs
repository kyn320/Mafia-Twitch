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
    public CharacterKind kind;
    /// <summary>
    /// 좋아하는 것
    /// </summary>
    public List<string> likeObject;
    /// <summary>
    /// 싫어하는 것
    /// </summary>
    public List<string> hateObject;
    /// <summary>
    /// 잘하는 것
    /// </summary>
    public List<string> wellObject;
    /// <summary>
    /// 못하는 것
    /// </summary>
    public List<string> notWellObject;

    /// <summary>
    /// Job Enum을 String으로 변환합니다.
    /// </summary>
    /// <param name="_job"></param>
    /// <returns></returns>
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
