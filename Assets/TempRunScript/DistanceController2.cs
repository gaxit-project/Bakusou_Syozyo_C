using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DistanceController2 : MonoBehaviour
{

    [SerializeField] private GameObject target; //target←GoalObject
    [SerializeField] private GameObject player; //player←Girl
    [SerializeField] Text counter; //counter←Distance
    [SerializeField] Slider dsSlider; //dsSlider←GoalDistance

    void Start()
    {

        /* ターゲットのポジションを取得 */
        Vector3 targetPos = target.transform.position;
        /* プレイヤーのポジションを取得 */
        Vector3 playerPos = player.transform.position;
        /* ターゲットとプレイヤーの距離を取得 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //スライダーの最低値と最大値の設定
        dsSlider.minValue = 0;
        dsSlider.maxValue = DistanceController.max;

        //スライダーの現在値の設定
        dsSlider.value = dis;
    }

    void Update()
    {
        /* ターゲットのポジションを取得 */
        Vector3 targetPos = target.transform.position;

        /* プレイヤーのポジションを取得 */
        Vector3 playerPos = player.transform.position;

        /* ターゲットとプレイヤーの距離を取得 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //スライダーの現在値の設定
        dsSlider.value = dis;

        //ゴールまでの距離を表示
        counter.text = "あと" + Convert.ToString(dis) + "m";
    }
}