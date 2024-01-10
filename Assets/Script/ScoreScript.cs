using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText; //得点の文字の変数
    [SerializeField]
    public static int minute;
    [SerializeField]
    public static float seconds;
    private float oldSeconds;
    bool ready = true;
    //private Text timerText;

    IEnumerator StartCall() // コルーチンの追記
    {
        for (int i = 2; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        ready = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "";
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            ScoreText.text = "";
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            ScoreText = GetComponentInChildren<Text>();
            StartCoroutine(StartCall());
        }
        if (SceneManager.GetActiveScene().name == "stage2")
        {
            ScoreText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            return;
        }
        seconds += Time.deltaTime;
        while (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        oldSeconds = seconds;

    }

}
