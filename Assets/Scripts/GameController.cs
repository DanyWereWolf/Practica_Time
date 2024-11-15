using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Пины")]
    [SerializeField] private Text pin_1;
    [SerializeField] private Text pin_2;
    [SerializeField] private Text pin_3;
    [SerializeField] public int pinNumber_1;
    [SerializeField] public int pinNumber_2;
    [SerializeField] public int pinNumber_3;

    [Header("Время")]
    [SerializeField] private Text time;
    [SerializeField] private float timeNumber_;

    [Header("Панели")]
    [SerializeField] private GameObject WinPannel;
    [SerializeField] private GameObject LosPannel;



    public void Start()
    {
        timeNumber_ = 60f;
        time.text = timeNumber_.ToString();
        WinPannel.SetActive(false);
        LosPannel.SetActive(false);
        pinNumber_1 = 7;
        pinNumber_2 = 3;
        pinNumber_3 = 1;
    }
    public void Update()
    {
        //---Ограничение--- 
        if (pinNumber_1 >= 10) pinNumber_1 = 10;
        if (pinNumber_2 >= 10) pinNumber_2 = 10;
        if (pinNumber_3 >= 10) pinNumber_3 = 10;
        if (pinNumber_1 <= 0) pinNumber_1 = 0;
        if (pinNumber_2 <= 0) pinNumber_2 = 0;
        if (pinNumber_3 <= 0) pinNumber_3 = 0;
       
        pin_1.text = pinNumber_1.ToString();
        pin_2.text = pinNumber_2.ToString();
        pin_3.text = pinNumber_3.ToString();
        timeNumber_ -= Time.deltaTime;
        time.text = Mathf.Round(timeNumber_).ToString();

        if (pinNumber_1 == 5 && pinNumber_2 == 5 && pinNumber_3 == 5)
        {
            WinPannel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (timeNumber_ <= 0f)
        {
            LosPannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void onClickPinBatton_drill()
    {
        pinNumber_1 += 1;
        pinNumber_2 -= 1;
        pinNumber_3 -= 1;
    }
    public void onClickPinBatton_hammer()
    {
        pinNumber_1 -= 1;
        pinNumber_2 += 1;
        pinNumber_3 -= 1;
    }
    public void onClickPinBatton_picklock()
    {
        pinNumber_1 -= 1;
        pinNumber_2 += 1;
        pinNumber_3 += 1;
    }
    public void onClickPinBatton_screwdriver()
    {
        pinNumber_1 += 1;
        pinNumber_2 -= 1;
        pinNumber_3 += 1;
    }
    public void onClickReset()
    {
        pinNumber_1 = 7;
        pinNumber_2 = 3;
        pinNumber_3 = 1;
        timeNumber_ = 60f;
        WinPannel.SetActive(false);
        LosPannel.SetActive(false);
        Time.timeScale = 1f;
    }


}
