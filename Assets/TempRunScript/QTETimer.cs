using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTETimer : MonoBehaviour
{
    [SerializeField] Slider dsSlider; //dsSlider��QTETimer

    //QTE�̎���
    public float QTESeconds, MissSeconds;
    public static bool Miss = false, Success = false, Timer = false;

    void Start()
    {
        //�X���C�_�[�̍Œ�l�ƍő�l�̐ݒ�
        dsSlider.minValue = 0;
        dsSlider.maxValue = QTESeconds;

        //�X���C�_�[�̌��ݒl�̐ݒ�
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

        //�X���C�_�[�̌��ݒl�̐ݒ�
        dsSlider.value = QTESeconds;
    }
}
