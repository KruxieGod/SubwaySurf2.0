using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TimerSpeedManager : MonoBehaviour
{
    [SerializeField] private TimerCounterUI _timerCounterUI;
    [SerializeField] private MovementHandler _movementHandler;
    [SerializeField] private Pair[] _timeBorders;
    [HideInInspector] public float Time;
    private int _index = 0;
    private int _length;

    private void Start()
    => _length = _timeBorders.Length;

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        _timerCounterUI.TextCounter.SetText(((int)Time).ToString());
        if (_index >= _length || _timeBorders[_index].Time >= Time) 
            return;
        _movementHandler.Coefficient = _timeBorders[_index].Coefficient;
        _index++;
    }
}

[Serializable]
public class Pair
{
    public int Time;
    public float Coefficient;
}
