using System;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static event Action OnPlayingTimeEnded;
    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timerText;
    private void Update()
    {
        if (_time == 0)
            return;
        if(_time > 0)
            _time -= Time.deltaTime;
        else
        {
            _time = 0;
            OnPlayingTimeEnded?.Invoke();
        }
        DisplayTime(_time);
    }
    /// <summary>
    /// Displays leftover time as UI text
    /// </summary>
    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
            timeToDisplay = 0;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //Setting timer text to 0:00 format
    }
}
