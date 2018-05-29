using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContextDialog : MonoBehaviour
{

    public List<ContextNode> nodeList;
    
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
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return null;
        CreateNode(ContextCategory.IntroduceName);
    }

    public void GetNodeList(ContextCategory _category)
    {
        nodeList = ContextNodeDB.Instance.GetNodeList(_category);
    }

    public void CreateNode(ContextCategory _category)
    {
        print("create");

        GetNodeList(_category);
        viewContext = nodeList[Random.Range(0, nodeList.Count)];

        GameObject g;
        UIContextNode node;

        maxSelectIndex = -1;

        for (int i = 0; i < viewContext.contexts.Count; ++i)
        {
            ++maxSelectIndex;

            g = Instantiate(nodeViewPrefab, transform);
            node = g.GetComponent<UIContextNode>();

            node.SetNode(maxSelectIndex, viewContext.contexts[i], false);

            if (viewContext.selectContexts[i].selectCategory != ContextSelectCategory.None)
            {
                ++maxSelectIndex;

                if (viewContext.selectContexts[i].contexts.Count < 1)
                {
                    viewContext.selectContexts[i].contexts = ContextSelectNode.FindContextList(viewContext.selectContexts[i].selectCategory);
                }

                CreateSelectNode(maxSelectIndex, i);
            }
        }
    }

    public void CreateSelectNode(int _index, int _selectIndex)
    {
        GameObject g;
        Transform group;
        UIContextNode node;

        List<string> selectContextList = viewContext.selectContexts[_selectIndex].contexts;

        if (selectContextList.Count < 1)
            return;

        group = Instantiate(nodeSelectViewPrefab, transform).transform;

        for (int i = 0; i < selectContextList.Count; ++i)
        {
            g = Instantiate(nodeViewPrefab, group);
            node = g.GetComponent<UIContextNode>();
            node.SetSelectNode(_index, i, selectContextList[i], false);
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
        Context totalContext = new Context();

        totalContext.category = viewContext.category;

        List<int> selector = new List<int>();

        for (int i = 0; i < selectNodeList.Count; ++i)
        {
            totalContext.say += selectNodeList[i].textData + " ";

            if (selectNodeList[i].selectIndex != -1)
            {
                selector.Add(selectNodeList[i].selectIndex);
            }
        }

        //Context의 타겟 이름과, 타겟 직업을 적용
        for (int i = 0; i < viewContext.selectContexts.Count; ++i)
        {
            ContextSelectNode selectNode = viewContext.selectContexts[i];
            switch (selectNode.selectCategory)
            {
                case ContextSelectCategory.Name:
                    totalContext.targetName = selectNode.contexts[selector[i]];
                    break;
                case ContextSelectCategory.Job:
                    totalContext.targetjob = selectNode.contexts[selector[i]];
                    break;
                default:
                    break;
            }
        }

        context = totalContext;

    }

}
