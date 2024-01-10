using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//シーン切り替えに使用するライブラリ
using UnityEngine.SceneManagement;


//アナログスティックのQTE
public class QTE4 : MonoBehaviour
{
    //コントローラーのボタン取得
    float L_axisH = 0.0f;
    float L_axisV = 0.0f;
    float R_axisH = 0.0f;
    float R_axisV = 0.0f;
    float D_axisH = 0.0f;
    float D_axisV = 0.0f;
    float T_axis  = 0.0f;

    float seido = 0.6f;

    bool R_up = false, R_down = false, R_left = false, R_right = false, Gul = false;
    bool R_left_up = false, R_left_down = false, R_right_up = false, R_right_down = false;

    void Start()
    {
        
    }

    void Update()
    {
        //コントローラー読み込み
        L_axisH = Input.GetAxisRaw("L_Stick_H");
        L_axisV = Input.GetAxisRaw("L_Stick_V");
        R_axisH = Input.GetAxisRaw("R_Stick_H");
        R_axisV = Input.GetAxisRaw("R_Stick_V");
        D_axisH = Input.GetAxisRaw("D_Pad_H");
        D_axisV = Input.GetAxisRaw("D_Pad_V");
        T_axis  = Input.GetAxisRaw("L_R_Trigger");

        if (!Gul)
        {
            if (R_axisH != 0.0f || R_axisV != 0.0f)
            {
                Gul = true;
            }
        }
        GulGul();
    }

    void GulGul()
    {
        if (Gul)
        {
            if (R_axisV > seido)//上
            {
                R_up = true;
            }
            if (R_axisH < seido/2*-1 && R_axisV > seido/2)//左上
            {
                R_left_up = true;
            }
            if (R_axisH < seido*-1)//左
            {
                R_left = true;
            }
            if (R_axisH < seido/2*-1 && R_axisV < seido/2*-1)//左下
            {
                R_left_down = true;
            }
            if (R_axisV < seido*-1)//下
            {
                R_down = true;
            }
            if (R_axisH > seido/2 && R_axisV < seido/2*-1)//右下
            {
                R_right_down = true;
            }
            if (R_axisH > seido)//右
            {
                R_right = true;
            }
            if (R_axisH > seido/2 && R_axisV > seido/2)//右上
            {
                R_right_up = true;
            }

            if (R_up && R_left_up && R_left && R_left_down && R_down && R_right_down && R_right && R_right_up)
            {
                Sound_SE.Omake();
                R_up = false; R_down = false; R_left = false; R_right = false;
                R_left_up = false; R_left_down = false; R_right_up = false; R_right_down = false;
            }

            if (R_axisH == 0.0f && R_axisV == 0.0f)//真ん中
            {
                Gul = false;
                R_up = false; R_down = false; R_left = false; R_right = false;
                R_left_up = false; R_left_down = false; R_right_up = false; R_right_down = false;
            }
        }
    }
}