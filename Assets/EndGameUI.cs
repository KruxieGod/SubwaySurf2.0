using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI TextScore;
    [SerializeField]private TextMeshProUGUI _recordText;
    [SerializeField] private TimerSpeedManager _timerSpeedManager;
    [SerializeField] private Button _restartButton;
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(() => SceneManager.LoadScene("StartScene"));
    }

    public async void Activate()
    {
        var str = ((int)_timerSpeedManager.Time).ToString();
        var recordStr = PlayerPrefs.GetString("RecordScore");
        _recordText.SetText(recordStr);
        TextScore.SetText(str);
        if (int.Parse(recordStr) < (int)_timerSpeedManager.Time)
            PlayerPrefs.SetString("RecordScore",str);
        await Task.Delay(TimeSpan.FromSeconds(2f));
        gameObject.SetActive(true);
    }
}
