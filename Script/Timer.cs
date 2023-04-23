using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject player;


    private Transform transform;
    private float _timeLeft = 0f;
    private bool _timerOn = false;
    private bool _timerStart = true;

    private void Start()
    {
        transform = player.GetComponent<Transform>();
        _timeLeft = time;
    }

    private void Update()
    {
        if ((transform.transform.position.x != 0.5 || transform.transform.position.y != 0.5) && _timerStart)
        {
            _timerOn = true;
            _timerStart = false;
        }
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        PlayerPrefs.SetString("currentRes", string.Format("{0:00} : {1:00}", minutes, seconds));
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
