using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//シーン切り替えに使用するライブラリ
using UnityEngine.SceneManagement;


//固定のQTE
public class QTE1 : MonoBehaviour
{

    public static int QTEcount;
    [SerializeField] private GameObject QTE_UI;

    //1回目かどうか
    bool First;

    //QTE中かどうか
    public static bool QTEflag = false;

    private void Start()
    {
        QTEflag = true;
        First = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "QTEarea1" || other.gameObject.name == "QTEarea2")
        {
            QTEcount = 0;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "QTEarea1" && First)
        {
            if (!QTE_UI.activeSelf && QTEcount == 0)
            {
                //　UIのアクティブ、非アクティブを切り替え
                QTE_UI.SetActive(!QTE_UI.activeSelf);
            }

            //Xボタン
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)) && QTEcount == 0)
            {
                QTEcount = 3;
                Debug.Log(QTEcount);
            }

            //Aボタン
            if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton0)) && QTEcount == 3)
            {
                if (QTE_UI.activeSelf)
                {
                    QTE_UI.SetActive(!QTE_UI.activeSelf);
                    Debug.Log("QTE");
                    QTEcount = ChangeImage.Length;
                    First = false;
                }
            }
        }


        if (other.gameObject.name == "QTEarea2" && !First)
        {
            if (!QTE_UI.activeSelf && QTEcount == 0)
            {
                //　UIのアクティブ、非アクティブを切り替え
                QTE_UI.SetActive(!QTE_UI.activeSelf);
            }

            //Xボタン
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)) && QTEcount == 0)
            {
                QTEcount = 1;
            }
            //Yボタン
            if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3)) && QTEcount == 1)
            {
                QTEcount = 2;
            }
            //Bボタン
            if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1)) && QTEcount == 2)
            {
                QTEcount = 3;
            }
            //Aボタン
            if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0)) && QTEcount == 3)
            {
                SceneManager.LoadScene("QTE seikou2", LoadSceneMode.Single);
                QTE_UI.SetActive(!QTE_UI.activeSelf);
                Debug.Log("QTE2");
                QTEcount = ChangeImage.Length;
                QTEflag = false;
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        QTE_sippai(other, QTE_UI, First);
    }


    public static void QTE_sippai(Collider other, GameObject QTE_UI,bool First)
    {
        if (other.gameObject.name == "QTEarea1" && First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            SceneManager.LoadScene("QTE sippai1", LoadSceneMode.Single);
        }

        if (other.gameObject.name == "QTEarea2" && !First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            SceneManager.LoadScene("QTE sippai2", LoadSceneMode.Single);
        }
    }
}