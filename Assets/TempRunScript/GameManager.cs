using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float playTime2;
    [SerializeField] Text timeCdText;
    [SerializeField] Text timeCuText;

    [SerializeField] Text callText; // 追記
    bool ready = true; // 追記
    [SerializeField] Text scoreText;

    public static int countdownMinutes = 3;
    public static float countdownSeconds;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerController2.two)
        {
            timeCdText.text = "";
            StartCoroutine(StartCall()); // 追記
        }
        else
        {
            timeCdText.text = "";
            StartCoroutine(ContinueCall()); // 追記
        }
    }


    IEnumerator ContinueCall()
    {
        countdownSeconds = PlayerController2.twoscond;
        callText.text = "";
        ready = false;
        yield return new WaitForSeconds(1f);
    }




    IEnumerator StartCall() // コルーチンの追記
    {
        countdownSeconds = countdownMinutes * 60;

        for (int i = 3; i > 0; i--)
        {
            callText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        callText.text = "GO!";
        ready = false;
        Goal.Tikoku = false;
        yield return new WaitForSeconds(1f);
        callText.text = "";
    }

    IEnumerator GameOver()
    {
        callText.text = "GAME OVER";
        Goal.Tikoku = true;
        Debug.Log(Goal.Tikoku);
        SceneManager.LoadScene("result");
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ready) // 追記
        {
            return;
        }

        if (countdownSeconds <= 0) // 時間切れ処理の追記
        {
            ready = true;
            StartCoroutine(GameOver());
        }

        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeCdText.text = span.ToString(@"mm\:ss");

    }

    public void OnClickClearBtn() // ボタンで呼ぶ関数の追記
    {
        ready = true;
        callText.text = "クリア！";
    }
}
