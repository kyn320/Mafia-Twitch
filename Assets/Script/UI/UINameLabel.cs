using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINameLabel : MonoBehaviour
{
    public Transform target;
    public Text nameText;

    public void SetCharacter(CharacterBehaviour _character, string _name)
    {
        target = _character.transform;
        nameText.text = _name;
    }

    public void SetName(string _name)
    {
        nameText.text = _name;
    }

}
