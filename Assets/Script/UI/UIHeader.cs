using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeader : MonoBehaviour
{

    public Text timerText;
    public Text jobText;
    public Text aliveText;
    public Text dayText;
    public Text dayTimeText;


    public void UpdateTimer(float _time)
    {
        float leftTime = 120 - _time;
        timerText.text = string.Format("{0:D2} : {1:D2}", (int)leftTime / 60, (int)leftTime % 60);
    }

    public void UpdateDay(int _day) {
        dayText.text = _day.ToString();
    }

    public void UpdateAlive(int _aliveCount) {
        aliveText.text = _aliveCount.ToString();
    }

    

}
