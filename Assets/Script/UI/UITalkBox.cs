using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITalkBox : MonoBehaviour
{
    public List<string> talkData;
    public Text talk;

    public void Say(string _say)
    {
        talkData.Clear();
        talkData.Add(_say);
        StartCoroutine(SayAnimation());
    }

    public void Say(List<string> _say)
    {
        talkData.Clear();
        talkData = _say;
        StartCoroutine(SayAnimation());
    }

    IEnumerator SayAnimation()
    {
        talk.text = "";
        for (int i = 0; i < talkData.Count; ++i)
        {
            for (int j = 0; j < talkData[i].Length; ++j)
            {
                talk.text += talkData[i][j];
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.15f);
            talk.text += "\n";
        }

        TalkManager.Instance.EndSay();
    }

}
