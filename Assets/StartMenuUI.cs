using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    [SerializeField] private Button _buttonStart;
    private void Start()
    {
        _buttonStart.onClick.AddListener(() => SceneManager.LoadScene( _nameScene));
    }
}
