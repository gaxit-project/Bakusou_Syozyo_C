//stage1シーンのGoalにアタッチ

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{

    [SerializeField] private GameObject target; //target←GoalObject
    [SerializeField] Text counter; //counter←Distance
    [SerializeField] Slider dsSlider; //dsSlider←GoalDistance
    Vector3 targetPos, playerPos;

    void Start()
    {        
        /* ターゲットのポジションを取得 */
        targetPos = target.transform.position;
        /* ターゲットとプレイヤーの距離を取得 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //スライダーの最低値と最大値の設定
        dsSlider.minValue = 0;

        if (!PlayerController2.two)
        {
            dsSlider.maxValue = dis;
            PlayerPrefs.SetInt("Distance", dis);
            PlayerPrefs.Save();
        }
        else
        {
            dsSlider.maxValue = PlayerPrefs.GetInt("Distance");
        }

        //スライダーの現在値の設定
        dsSlider.value = dis;
    }

    void Update()
    {
        /* ターゲットとプレイヤーの距離を取得 */
        int dis = (int)Vector3.Distance(targetPos, CharaSelect.Chara.transform.position);

        //スライダーの現在値の設定
        dsSlider.value = dis;

        //ゴールまでの距離を表示
        counter.text = "あと" + Convert.ToString(dis) + "m";
    }
}
