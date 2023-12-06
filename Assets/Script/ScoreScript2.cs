using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript2 : MonoBehaviour
{
    public Text ScoreText;
    private int m;
    private int s;

    void Start()
    {
        m = ScoreScript.minute;
        s = (int)ScoreScript.seconds;
        ScoreText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        ScoreText.text = "SCORE " + m.ToString("00") + ":" + s.ToString("00");
    }
}
