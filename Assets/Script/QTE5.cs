using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//�V�[���؂�ւ��Ɏg�p���郉�C�u����
using UnityEngine.SceneManagement;


//�A�ł�QTE
public class QTE5 : MonoBehaviour
{
    int QTEmax = 10;
    int QTEcount = 0;

    bool left = false, right = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2))//X
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))//Y
        {
            right = true;
        }
        if(left && right)
        {
            left = false; right = false;
            QTEcount++;
            Debug.Log(QTEcount);
        }
        if (QTEmax <= QTEcount)
        {
            Sound_SE.Omake();
            QTEcount = 0;
        }
    }
}