using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusTime : MonoBehaviour
{

    public float tmp;
    public float max;

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
            }
            else 
            {
                tmp = GameManager.countdownSeconds;
                GameManager.countdownSeconds = 0;
                ScoreScript.seconds += tmp;
                if (ScoreScript.seconds > max)
                {
                    ScoreScript.seconds = max;
                }
            }
        }
    }
}
