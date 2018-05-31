using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINameLabel : MonoBehaviour
{
    public Transform target;
    public Text nameText;

    public Vector3 margin;

    void Update() {

        transform.position = Camera.main.WorldToScreenPoint(target.position + margin);
    }

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
