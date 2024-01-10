
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用

public class PauseScript : MonoBehaviour
{
    Button b1;
    Button b2;
    Button b3;
    Slider bgm;
    Slider se;
    //　ポーズした時に表示するUI
    [SerializeField] private GameObject pauseUI;
    //　ゲーム再開ボタン
    [SerializeField] private GameObject reStartButton;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("Q");
            //　ポーズUIが表示されてる時は停止
            if (!pauseUI.activeSelf)
            {
                //　ポーズUIのアクティブ、非アクティブを切り替え
                pauseUI.SetActive(!pauseUI.activeSelf);
                Time.timeScale = 0f;
                Pause();
            }
            else
            {
                pauseUI.SetActive(!pauseUI.activeSelf);
                Time.timeScale = 1f;
            }
        }
    }

    public void ReStartGame()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        bgm = GameObject.Find("/Canvas/Panel/Slider_BGM").GetComponent<Slider>();
        se = GameObject.Find("/Canvas/Panel/Slider_SE").GetComponent<Slider>();
        b1 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        b2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        b3 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        // 最初に選択状態にしたいボタンの設定
        bgm.Select();
    }

}