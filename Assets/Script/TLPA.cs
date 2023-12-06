using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TLPA : PlayableAsset
{
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        //ScriptPlayable<�u�X�N���v�g���v>�ō쐬�����X�N���v�g��Ή�������
        return ScriptPlayable<TLPB>.Create(graph);
    }
}
