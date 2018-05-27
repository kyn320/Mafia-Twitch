using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContextNode : MonoBehaviour {

    public Text nodeText;

    public bool isSelect = false;

    public void SetNode(string _context, bool _isSelect) {
        nodeText.text = _context;
        isSelect = _isSelect;
    }

}
