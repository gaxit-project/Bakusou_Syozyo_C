using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI処理のクラスを使用する宣言
using UnityEngine.UI;

public class QTEImage : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    [Header("ボタンの画像編集")]
    [SerializeField] public Image[] m_Image;

    // スプライトオブジェクトを格納する配列
    [Header("画像の種類")]
    public Sprite[] m_Sprite;

    // スプライトオブジェクトを変更するためのフラグ
    int Change;
    int[] tmp;

    [Header("ボタンの画像")]
    public GameObject[] Image;
    [Header("画像背景 入力正解時に使用")]
    public GameObject[] ImageB;

    bool No2 = true;
    //public int QTE_No;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (QTE3.QTEflag)
        {
            Change = QTE3.RandomQTE[QTE3.QTEcount];
            tmp = QTE3.RandomQTE;
        }

        if (QTE3.First)
        {
            SetImage_2();
        }
        else
        {
            SetImage_4();
        }
    }

    void SetImage_2()
    {
        m_Image[0].sprite = m_Sprite[tmp[0]];
        m_Image[1].sprite = m_Sprite[tmp[1]];
        m_Image[2].sprite = m_Sprite[tmp[2]];//非表示
        m_Image[3].sprite = m_Sprite[tmp[3]];//非表示

        if (QTE3.QTEcount == 0 && !ImageB[0].activeSelf) 
        {
            ImageB[0].SetActive(!ImageB[0].activeSelf);
        }
        if (QTE3.QTEcount == 1 && !ImageB[1].activeSelf)
        {
            ImageB[0].SetActive(!ImageB[0].activeSelf);
            ImageB[1].SetActive(!ImageB[1].activeSelf);
        }
    }

    void SetImage_4()
    {
        if (No2)
        {
            Image[2].SetActive(!Image[2].activeSelf);
            Image[3].SetActive(!Image[3].activeSelf);
            ImageB[1].SetActive(!ImageB[1].activeSelf);
            No2 = false;
        }

        m_Image[2].sprite = m_Sprite[tmp[0]];
        m_Image[0].sprite = m_Sprite[tmp[1]];
        m_Image[1].sprite = m_Sprite[tmp[2]];
        m_Image[3].sprite = m_Sprite[tmp[3]];

        if (QTE3.QTEcount == 0 && !ImageB[2].activeSelf)
        {
            ImageB[2].SetActive(!ImageB[2].activeSelf);
        }
        if (QTE3.QTEcount == 1 && !ImageB[0].activeSelf)
        {
            ImageB[2].SetActive(!ImageB[2].activeSelf);
            ImageB[0].SetActive(!ImageB[0].activeSelf);
        }
        if (QTE3.QTEcount == 2 && !ImageB[1].activeSelf)
        {
            ImageB[0].SetActive(!ImageB[0].activeSelf);
            ImageB[1].SetActive(!ImageB[1].activeSelf);
        }
        if (QTE3.QTEcount == 3 && !ImageB[3].activeSelf)
        {
            ImageB[1].SetActive(!ImageB[1].activeSelf);
            ImageB[3].SetActive(!ImageB[3].activeSelf);
        }
    }
}
