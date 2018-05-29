using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITalkBox : MonoBehaviour
{
    public string talkData;
    public Text talk;

    public void Say(string _say)
    {
        talkData = _say;
        StartCoroutine(SayAnimation());
    }

    IEnumerator SayAnimation()
    {
        for (int i = 0; i < talkData.Length; ++i)
        {
            talk.text += talkData[i];
            yield return new WaitForSeconds(0.2f);
        }


    }

}
