using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour
{


    public UITalkBox talkBox;

    public GameObject nameLabelPrefab;

    public UINameLabel CreateNameLabel(CharacterBehaviour _character)
    {
        return Instantiate(nameLabelPrefab, transform).GetComponent<UINameLabel>();
    }
}
