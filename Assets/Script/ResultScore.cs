using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    public Text ResultText;
    private int m;
    private int s;
    private int sum;
    // Start is called before the first frame update
    void Start()
    {
        m = ScoreScript.minute;
        s = (int)ScoreScript.seconds;
        sum = m * 60 + s;
        ResultText = GetComponentInChildren<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Goal.Tikoku)
        {
            ResultText.text = "•]‰¿:Z";
        }
        else if (GameManager.countdownSeconds >= 90)
        {
            ResultText.text = "•]‰¿:A";
        }
        else if (GameManager.countdownSeconds >= 60)
        {
            ResultText.text = "•]‰¿:B";
        }
        else if (GameManager.countdownSeconds >= 0)
        {
            ResultText.text = "•]‰¿:C";
        }
    }
}