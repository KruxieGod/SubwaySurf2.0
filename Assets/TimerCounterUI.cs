using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private float _timeCount = 0;
    
    private void Update()
    {
        _timeCount += Time.deltaTime;
        _text.SetText(((int)_timeCount).ToString());
    }
}
