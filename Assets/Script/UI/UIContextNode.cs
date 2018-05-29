using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIContextNode : MonoBehaviour, IPointerDownHandler
{
    public static UIContextDialog contextDialog;

    public int nodeIndex = -1;

    public int selectIndex = -1;

    public Text nodeText;
    public string textData;

    public bool isSelect = false;

    public void SetNode(int _index, string _context, bool _isSelect)
    {
        nodeIndex = _index;
        selectIndex = -1;
        nodeText.text = textData = _context;
        isSelect = _isSelect;
    }

    public void SetSelectNode(int _index, int _selectIndex, string _context, bool _isSelect)
    {
        nodeIndex = _index;
        selectIndex = _selectIndex;
        nodeText.text = textData = _context;
        isSelect = _isSelect;
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        //Select Node
        contextDialog.AddSelectNode(this);

    }
}
