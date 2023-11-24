using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using UnityEngine.SceneManagement;

// A behaviour that is attached to a playable
public class TLPB : PlayableBehaviour
{
    //�^�C�����C���Đ����ɌĂ΂��
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        Debug.Log("�n�܂�܂����H");
        PlayerPrefs.SetInt("TL_Count", 0);
        PlayerPrefs.Save();
    }

    //�^�C�����C����~���ɌĂ΂��
    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        Debug.Log("�I������Ⴂ�܂����H");
    }

    //�v���C�A�u���g���b�N�Đ����ɌĂ΂��
    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log("�Đ�����܂����H");
        //�V�[�������ustart�v�̂Ƃ�
        if (SceneManager.GetActiveScene().name == "start")
        {
            TL_start_SE();
        }
        if (SceneManager.GetActiveScene().name == "QTE 1")
        {
            TL_QTE1_SE();
        }


        PlayerPrefs.SetInt("TL_Count", (PlayerPrefs.GetInt("TL_Count") + 1));
        PlayerPrefs.Save();
    }

    //�v���C�A�u���g���b�N��~���ɌĂ΂��
    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        Debug.Log("��~���Ă���ł����H");
    }

    //�v���C�A�u���g���b�N�Đ����t���[�����ɌĂ΂��
    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }


    void TL_start_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.Omake();
                break;
            case 1:
                Sound_SE.Hidan();
                break;
            default:
                Debug.Log("���ɒN�����܂����H");
                break;
        }
    }

    void TL_QTE1_SE()
    {
        switch (PlayerPrefs.GetInt("TL_Count"))
        {
            case 0:
                Sound_SE.Hidan();
                break;
            case 1:
                Sound_SE.Omake();
                break;
            default:
                Debug.Log("���ɒN�����܂����H");
                break;
        }
    }
}
