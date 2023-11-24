using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTETimer : MonoBehaviour
{
    [SerializeField] Slider dsSlider; //dsSlider←QTETimer

    //QTEの時間
    public float QTESeconds, MissSeconds;
    public static bool Miss = false, Success = false, Timer = false;

    void Start()
    {
        //スライダーの最低値と最大値の設定
        dsSlider.minValue = 0;
        dsSlider.maxValue = QTESeconds;

        //スライダーの現在値の設定
        dsSlider.value = QTESeconds;
    }

    void Update()
    {
        QTESeconds -= Time.deltaTime;

        if (Miss)
        {
            QTESeconds -= MissSeconds;
            Miss = false;
        }
        if (Success)
        {
            QTESeconds = dsSlider.maxValue;
            Success = false;
        }

        //スライダーの現在値の設定
        dsSlider.value = QTESeconds;
    }
}
