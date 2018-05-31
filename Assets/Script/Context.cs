using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Context
{
    /// <summary>
    /// 최종 문장
    /// </summary>
    public string say;
    /// <summary>
    /// 카테고리
    /// </summary>
    public ContextCategory category;
    /// <summary>
    /// 사실 인가?
    /// </summary>
    public bool isTrueth = true;
    /// <summary>
    /// 긍정적 수치
    /// </summary>
    public int like;
    /// <summary>
    /// 부정적 수치
    /// </summary>
    public int hate;
    /// <summary>
    /// 말하는 대상
    /// </summary>
    public CharacterBehaviour sayCharacter;
    /// <summary>
    /// 지목된 대상
    /// </summary>
    public CharacterBehaviour target;
    /// <summary>
    /// 지목된 직업
    /// </summary>
    public CharacterJob targetjob;
    /// <summary>
    /// 선택한 내용
    /// </summary>
    public List<string> selectData = new List<string>();
}
