using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVoteSlot : MonoBehaviour
{
    public Text nameText;

    public void SetData(string _name)
    {
        nameText.text = _name;
    }
    
}
