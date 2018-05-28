using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContextDialog : MonoBehaviour
{

    public List<ContextNode> nodeList;

    public List<UIContextNode> nodeViewList;

    public List<UIContextNode> selectNodeList;

    public GameObject nodeViewPrefab;
    public GameObject nodeSelectViewPrefab;

    [SerializeField]
    ContextNode viewContext;


    public Context context;

    int selectIndex = -1;
    int maxSelectIndex = 0;

    private void Awake()
    {
        UIContextNode.contextDialog = this;
    }

    void Start()
    {
        CreateNode(ContextCategory.GuessJob);
    }

    public void CreateNode(ContextCategory _category)
    {
        viewContext = nodeList.Find(item => item.category == _category);
        GameObject g;
        UIContextNode node;

        maxSelectIndex = -1;

        for (int i = 0; i < viewContext.fixContext.Count; ++i)
        {
            ++maxSelectIndex;

            g = Instantiate(nodeViewPrefab, transform);
            node = g.GetComponent<UIContextNode>();

            node.SetNode(maxSelectIndex, viewContext.fixContext[i], false);

            if (viewContext.selectContext[i] != ContextSelect.None)
            {
                ++maxSelectIndex;
                CreateSelectNode(maxSelectIndex, viewContext.selectContext[i]);
            }
        }


    }

    public void CreateSelectNode(int _index, ContextSelect _select)
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
            node.SetNode(_index, selectContextList[i], false);
        }

    }

    public void AddSelectNode(UIContextNode _node)
    {
        if (selectIndex + 1 != _node.nodeIndex)
            return;

        ++selectIndex;

        selectNodeList.Add(_node);
        Debug.Log("select Node Adding");

        if (maxSelectIndex == selectIndex)
        {
            Debug.Log("success context");
            CreateContext();
        }
    }

    public void CreateContext()
    {
        //TODO :: Context로 변환 하는 로직 구현
        string say = "";
        for (int i = 0; i < selectNodeList.Count; ++i)
        {
            say += selectNodeList[i].textData + " ";
        }

        print(say);
    }

}
