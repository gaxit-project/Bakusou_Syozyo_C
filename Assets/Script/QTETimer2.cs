using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTETimer2 : MonoBehaviour
{
    [SerializeField] Image clockImage; //©”’l‚ğ•Ï‚¦‚½‚¢Image

    //QTE‚ÌŠÔ
    public float QTESeconds, MissSeconds;
    float Seconds = 0;
    public static bool Miss = false, Success = false, Timer = false;

    void Start()
    {

    }

    void Update()
    {
        Seconds += Time.deltaTime;

        if (Miss)
        {
            Seconds += MissSeconds;
            Miss = false;
        }
        if (Success)
        {
            Seconds = 0;
            Success = false;
        }

        clockImage.fillAmount = Seconds / QTESeconds;
    }
}
