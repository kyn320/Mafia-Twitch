using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContextDialog : MonoBehaviour
{

    public List<ContextNode> nodeList;

    public List<UIContextNode> nodeViewList;

    public GameObject nodeViewPrefab;
    public GameObject nodeSelectViewPrefab;

    [SerializeField]
    ContextNode viewContext;

    void Start() {
        CreateNode(ContextCategory.FindJob);
    }

    public void CreateNode(ContextCategory _category)
    {
        viewContext = nodeList.Find(item => item.category == _category);
        GameObject g;
        UIContextNode node;
        for (int i = 0; i < viewContext.fixContext.Count; ++i)
        {
            g = Instantiate(nodeViewPrefab, transform);
            node = g.GetComponent<UIContextNode>();

            node.SetNode(viewContext.fixContext[i], false);

            if (viewContext.selectContext[i] != ContextSelect.None)
            {
                CreateSelectNode(viewContext.selectContext[i]);
            }
        }
    }

    public void CreateSelectNode(ContextSelect _select)
    {
        GameObject g;
        Transform group;
        UIContextNode node;

        List<string> selectContextList = new List<string>();
        selectContextList = ContextNode.FindContextList(_select);

        if (selectContextList == null)
            return;

        group = Instantiate(nodeSelectViewPrefab, transform).transform;

        for (int i = 0; i < selectContextList.Count; ++i)
        {
            g = Instantiate(nodeViewPrefab, group);
            node = g.GetComponent<UIContextNode>();
            node.SetNode(selectContextList[i], false);
        }

    }




}
