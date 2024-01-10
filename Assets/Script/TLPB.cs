using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using UnityEngine.SceneManagement;

// A behaviour that is attached to a playable
public class TLPB : PlayableBehaviour
{
    //タイムライン再生時に呼ばれる
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        Debug.Log("始まりました？");
        PlayerPrefs.SetInt("TL_Count", 0);
        PlayerPrefs.Save();
    }

    //タイムライン停止時に呼ばれる
    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        Debug.Log("終わっちゃいました？");
    }

    //プレイアブルトラック再生時に呼ばれる
    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log("再生されました？");
        //シーン名が「start」のとき
        if (SceneManager.GetActiveScene().name == "start")
        {
            TL_start_SE();
        }
        if (SceneManager.GetActiveScene().name == "start_hard")
        {
            TL_start_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE 1")
        {
            TL_QTE1_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE 2_hard")
        {
            TL_QTE1_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE seikou2" || SceneManager.GetActiveScene().name == "QTE seikou2_hard")
        {
            TL_QTEseikou_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE sippai1")
        {
            TL_QTEsippai1_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE sippai2")
        {
            TL_QTEsippai2_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE end")
        {
            TL_QTEend_SE();
        }


        PlayerPrefs.SetInt("TL_Count", (PlayerPrefs.GetInt("TL_Count") + 1));
        PlayerPrefs.Save();
    }

    //プレイアブルトラック停止時に呼ばれる
    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log("停止ってこれですか？");
    }

    //プレイアブルトラック再生時フレーム事に呼ばれる
    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }


    void TL_start_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.Start_Alarm();
                break;
            case 1:
                Sound_SE.Start_Clock();
                break;
            case 2:
                Sound_SE.Start_Gasagoso();
                break;
            case 3:
                Sound_SE.Start_DoorOpen();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }

    void TL_QTE1_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.QTE_train();
                break;
            case 1:
                Sound_SE.QTE_Slide();
                break;
            case 2:
                Sound_SE.QTE_Brake();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }
    void TL_QTEseikou_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.QTE_Brake();
                break;
            case 1:
                Sound_SE.QTE_Slide();
                break;
            case 2:
                Sound_SE.QTE_Brake();
                break;
            case 3:
                Sound_SE.QTE_Slide();
                break;
            case 4:
                Sound_SE.QTE_Brake();
                break;
            case 5:
                Sound_SE.QTE_Slide(); 
                break;
            case 6:
                Sound_SE.QTE_Brake();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }
    void TL_QTEsippai1_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.QTE_Slide();
                Sound_SE.QTE_train();
                break;
            case 1:
                Sound_SE.QTE_WomanScream1();
                break;
            case 2:
                Sound_SE.QTE_WomanScream2();
                break;
            case 3:
                Sound_SE.QTE_ManScream1();
                break;
            case 4:
                Sound_SE.QTE_Brake();
                break;
            case 5:
                Sound_SE.QTE_WomanScream1();
                break;
            case 6:
                Sound_SE.QTE_shot2();
                break;
            case 7:
                Sound_SE.QTE_shot2();
                break;
            case 8:
                Sound_SE.QTE_Shot1();
                break;
            case 9:
                Sound_SE.QTE_Shot1();
                break;
            case 10:
                Sound_SE.QTE_shot2();
                break;
            case 11:
                Sound_SE.QTE_Shot1();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }

    void TL_QTEsippai2_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.QTE_Slide();
                Sound_SE.QTE_train();
                break;
            case 1:
                Sound_SE.QTE_WomanScream1();
                break;
            case 2:
                Sound_SE.QTE_WomanScream2();
                break;
            case 3:
                Sound_SE.QTE_ManScream1();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }

        void TL_QTEend_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.End_Run();
                break;
            case 1:
                Sound_SE.AudioStop();
                Sound_SE.End_Close();
                break;
            case 2:
                Sound_SE.AudioStop();
                Sound_SE.End_Run();
                break;
            case 3:
                Sound_SE.AudioStop();
                Sound_SE.End_Close();
                break;
            case 4:
                Sound_SE.AudioStop();
                Sound_SE.End_Run();
                break;
            case 5:
                Sound_SE.AudioStop();
                Sound_SE.End_Close();
                break;
            case 6:
                Sound_SE.AudioStop();
                Sound_SE.End_Run();
                break;
            case 7:
                Sound_SE.AudioStop();
                Sound_SE.End_Run();
                Sound_SE.End_Close();
                break;
            case 8:
                Sound_SE.AudioStop();
                break;
            default:
                Debug.Log("中に誰もいませんよ？");
                break;
        }
    }
}
