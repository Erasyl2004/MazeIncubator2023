using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveTime : MonoBehaviour
{
    [SerializeField] private Text BestTime;
    public void Start()
    {
        if (PlayerPrefs.HasKey("time"))
        {
            BestTime.text = PlayerPrefs.GetString("time");
        }
        else
            BestTime.text = "00 : 00";
    }
    public void Save() 
    {
        int timesnewRoman = 0;
        if (PlayerPrefs.HasKey("currentRes"))
        {
            timesnewRoman = int.Parse(PlayerPrefs.GetString("currentRes").Split(" :")[0]) * 60 + int.Parse(PlayerPrefs.GetString("currentRes").Split(": ")[1]);
        }
        Debug.Log(timesnewRoman);
        int timesBest = 0;
        if (PlayerPrefs.HasKey("time")) 
        {
            timesBest = int.Parse(PlayerPrefs.GetString("time").Split(" :")[0]) * 60 + int.Parse(PlayerPrefs.GetString("time").Split(": ")[1]);
        }
        if (timesBest < timesnewRoman) 
        {
            PlayerPrefs.SetString("time", PlayerPrefs.GetString("currentRes"));
        }
    }
}
