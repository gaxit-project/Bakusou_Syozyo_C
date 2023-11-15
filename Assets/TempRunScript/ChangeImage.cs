using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI処理のクラスを使用する宣言
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    private Image m_Image;
    // スプライトオブジェクトを格納する配列
    public Sprite[] m_Sprite;
    // スプライトオブジェクトを変更するためのフラグ
    int Change;

    // ゲーム開始時に実行する処理
    void Start()
    {
        // スプライトオブジェクトを変更するためのフラグを 
        // Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();
    }

    // ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
        if (QTE1.QTEflag)
        {
            Change = QTE1.QTEcount;

            if (Change == 0)
            {
                // スプライトオブジェクトの変更
                m_Image.sprite = m_Sprite[0];
            }
            if (Change == 1)
            {
                // スプライトオブジェクトの変更
                m_Image.sprite = m_Sprite[1];
            }
            if (Change == 2)
            {
                // スプライトオブジェクトの変更
                m_Image.sprite = m_Sprite[2];
            }
            if (Change == 3)
            {
                // スプライトオブジェクトの変更
                m_Image.sprite = m_Sprite[3];
            }
        }


        if (QTE2.QTEflag)
        {
            Change = QTE2.RandomQTE[QTE2.QTEcount];

            if (Change == 0)
            {
                // スプライトオブジェクトの変更 {X}
                m_Image.sprite = m_Sprite[0];
            }
            if (Change == 1)
            {
                // スプライトオブジェクトの変更 {Y}
                m_Image.sprite = m_Sprite[1];
            }
            if (Change == 2)
            {
                // スプライトオブジェクトの変更 {B}
                m_Image.sprite = m_Sprite[2];
            }
            if (Change == 3)
            {
                // スプライトオブジェクトの変更 {A}
                m_Image.sprite = m_Sprite[3];
            }
        }


        if(Goal.goal)
        {
            if (!Goal.Tikoku)
            {
                m_Image.sprite = m_Sprite[0];
            }
            else
            {
                m_Image.sprite = m_Sprite[1];
            }
        }
    }
}