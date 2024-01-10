using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusTime : MonoBehaviour
{

    float tmp;
    float max;
    public static int minusScore = 0; //Rankingスクリプトで使う

    void Start()
    {
        max = GameManager.countdownMinutes * 60f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            if (GameManager.countdownSeconds >= 5.0f)
            {
                GameManager.countdownSeconds -= 5.0f;
                ScoreScript.seconds += 5.0f;
                minusScore -= 500; //障害物にぶつかるとスコアを-500
            }
            else 
            {
                tmp = GameManager.countdownSeconds;
                GameManager.countdownSeconds = 0;
                minusScore = 0; //残り時間が5秒未満ならスコアを0にする
                ScoreScript.seconds += tmp;
                if (ScoreScript.seconds > max)
                {
                    ScoreScript.seconds = max;
                }
            }
        }
    }
}
