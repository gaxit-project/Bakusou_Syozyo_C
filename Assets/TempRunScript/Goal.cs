using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン切り替えに使用するライブラリ

public class Goal : MonoBehaviour
{
    public string sceneName;

    public static bool Tikoku;
    public static bool goal;

    private void Start()
    {
        goal = false;
    }

    //プレイヤーが当たり判定に入った時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ゴールしました！");
            goal = true;
            SceneManager.LoadScene(sceneName);

        }
    }

}