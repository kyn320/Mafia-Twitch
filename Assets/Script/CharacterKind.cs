using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterKind
{
    /// <summary>
    /// 사실
    /// </summary>
    public int trueth;
    /// <summary>
    /// 거짓
    /// </summary>
    public int lie;
    /// <summary>
    /// 선
    /// </summary>
    public int angel;
    /// <summary>
    /// 악
    /// </summary>
    public int devil;
    /// <summary>
    /// 긍정
    /// </summary>
    public int like;
    /// <summary>
    /// 부정
    /// </summary>
    public int hate;

    public void SetRandom()
    {
        trueth = Random.Range(0, 11);
        lie = Mathf.Clamp(10 - trueth, 0, 10);

        angel = Random.Range(0, 11);
        devil = Mathf.Clamp(10 - angel, 0, 10);

        like = Random.Range(0, 11);
        hate = Mathf.Clamp(10 - like, 0, 10);
    }
}
