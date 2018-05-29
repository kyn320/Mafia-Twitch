using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDB : Singleton<CharacterDB>
{
    /// <summary>
    /// 이름 리스트
    /// </summary>
    public List<string> nameList;

    private List<int> useNameIndex = new List<int>();
    /// <summary>
    /// 사는 곳 리스트
    /// </summary>
    public List<string> liveSpaceList;
    /// <summary>
    /// 좋아하는 것/싫어하는 것 리스트
    /// </summary>
    public List<string> likeAndHateObjectList;
    /// <summary>
    /// 잘하는 것/ 못하는 것 리스트
    /// </summary>
    public List<string> wellAndNotWellObjectList;

    private void Awake()
    {
        ReSetUseNameIndex();
    }

    void ReSetUseNameIndex()
    {
        for (int i = 0; i < nameList.Count; ++i)
        {
            useNameIndex.Add(i);
        }
    }

    public string GetNameToUse()
    {
        int rand = Random.Range(0, useNameIndex.Count);
        int index = useNameIndex[rand];
        useNameIndex.RemoveAt(rand);

        return nameList[index];
    }

    public string GetLiveSpace()
    {
        return liveSpaceList[Random.Range(0, liveSpaceList.Count)];
    }

    public Dictionary<int, List<string>> GetLikeAndHateObjects(int _likeCount, int _hateCount)
    {
        Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
        List<int> useIndex = new List<int>();

        for (int i = 0; i < likeAndHateObjectList.Count; ++i)
        {
            useIndex.Add(i);
        }

        int rand = -1;
        int index = -1;

        List<string> likeData = new List<string>();
        //like
        for (int i = 0; i < _likeCount; ++i)
        {
            rand = Random.Range(0, useIndex.Count);
            index = useIndex[rand];

            likeData.Add(likeAndHateObjectList[index]);
            useIndex.RemoveAt(rand);
        }
        dic.Add(1, likeData);

        List<string> hateData = new List<string>();
        //hate
        for (int i = 0; i < _hateCount; ++i)
        {
            rand = Random.Range(0, useIndex.Count);
            index = useIndex[rand];

            hateData.Add(likeAndHateObjectList[index]);
            useIndex.RemoveAt(rand);
        }
        dic.Add(-1, hateData);
        return dic;
    }

    public Dictionary<int, List<string>> GetWellAndNotWellObjects(int _wellCount, int _notWellCount)
    {
        Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
        List<int> useIndex = new List<int>();

        for (int i = 0; i < wellAndNotWellObjectList.Count; ++i)
        {
            useIndex.Add(i);
        }

        int rand = -1;
        int index = -1;
        List<string> wellData = new List<string>();
        //well
        for (int i = 0; i < _wellCount; ++i)
        {
            rand = Random.Range(0, useIndex.Count);
            index = useIndex[rand];
            wellData.Add(wellAndNotWellObjectList[index]);
            useIndex.RemoveAt(rand);
        }
        dic.Add(1, wellData);

        List<string> notWellData = new List<string>();
        //notWell
        for (int i = 0; i < _notWellCount; ++i)
        {
            rand = Random.Range(0, useIndex.Count);
            index = useIndex[rand];
            notWellData.Add(wellAndNotWellObjectList[index]);
            useIndex.RemoveAt(rand);
        }
        dic.Add(-1, notWellData);

        return dic;
    }

}
