using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _deadScreen;
    [SerializeField] private GameObject _timerText;
    private void Awake()
    {
        _winScreen.SetActive(false);
        _deadScreen.SetActive(false);
        CountdownTimer.OnPlayingTimeEnded += ShowWinScreen;
    }
    private void ShowWinScreen()
    {
        _winScreen.SetActive(true);
        _timerText.SetActive(false);
    }
    private void ShowDeadScreen()
    {
        _deadScreen.SetActive(true);
        _timerText.SetActive(false);
    }
}
