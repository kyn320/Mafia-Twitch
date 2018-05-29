using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVoteDialog : MonoBehaviour
{
    public GameObject voteSlotPrefab;

    public List<UIVoteSlot> voteSlotList;

    GridLayoutGroup grid;

    private void Awake()
    {
        grid = GetComponent<GridLayoutGroup>();
        Create(GameManager.Instance.GetCharacterNames(true));
    }

    void Create(List<string> voteNameList)
    {
        GameObject g;
        UIVoteSlot v;

        int col = voteNameList.Count % 2 == 0 ? (voteNameList.Count / 2) : ((voteNameList.Count / 2) + 1);
        print(col);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = col;

        float size = 100 * col;

        grid.cellSize = Vector2.one * size;

        for (int i = 0; i < voteNameList.Count; ++i)
        {
            g = Instantiate(voteSlotPrefab, transform);
            v = g.GetComponent<UIVoteSlot>();

            v.SetData(voteNameList[i]);
            voteSlotList.Add(v);
        }

    }

}
