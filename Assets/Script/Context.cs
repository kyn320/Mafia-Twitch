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
    /// 거짓말 인가?
    /// </summary>
    public bool isLIe = false;
    /// <summary>
    /// 긍정적 수치
    /// </summary>
    public int like;
    /// <summary>
    /// 부정적 수치
    /// </summary>
    public int hate;
    /// <summary>
    /// 지목된 이름
    /// </summary>
    public string targetName;
    /// <summary>
    /// 지목된 직업
    /// </summary>
    public string targetjob;
    /// <summary>
    /// 선택한 내용
    /// </summary>
    public List<string> selectData = new List<string>();
}
