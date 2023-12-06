using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�V�[���؂�ւ��Ɏg�p���郉�C�u����
using UnityEngine.SceneManagement;

//�^�C�����C���֌W
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class TLSceneIDOU : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private int explosionIndex;

    
    [SerializeField] private string IDOUsaki;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "start")
        {
            IDOUsaki = StartStage.StageName;
        }
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        // Clip�̊J�n���Ԏ擾
        float explosionTime = (float)timelineAsset.GetOutputTrack(explosionIndex).GetClips().ToList()[0].start;

        // Clip�J�n���ԂŎ��s
        Invoke(nameof(CreateExplosion), explosionTime);
    }

    private void CreateExplosion()
    {
        SceneManager.LoadScene(IDOUsaki, LoadSceneMode.Single);
    }
}