using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//シーン切り替えに使用するライブラリ
using UnityEngine.SceneManagement;

//タイムライン関係
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
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        // Clipの開始時間取得
        float explosionTime = (float)timelineAsset.GetOutputTrack(explosionIndex).GetClips().ToList()[0].start;

        // Clip開始時間で実行
        Invoke(nameof(CreateExplosion), explosionTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(IDOUsaki);
        }
    }

    private void CreateExplosion()
    {
        SceneManager.LoadScene(IDOUsaki, LoadSceneMode.Single);
    }
}