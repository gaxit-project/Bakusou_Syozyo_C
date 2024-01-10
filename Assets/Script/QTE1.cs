using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//�V�[���؂�ւ��Ɏg�p���郉�C�u����
using UnityEngine.SceneManagement;


//�Œ��QTE
public class QTE1 : MonoBehaviour
{

    public static int QTEcount;
    [SerializeField] private GameObject QTE_UI, QTE_UI1;

    //1��ڂ��ǂ���
    bool First;

    //QTE�����ǂ���
    public static bool QTEflag = false;

    private void Start()
    {
        QTEflag = true;
        First = true;
    }

    private void Update()
    {
        if (QTETimer.TimeOver)
        {
            QTE_sippai();
        }
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
                //�@UI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
                QTE_UI.SetActive(!QTE_UI.activeSelf);
                QTE_UI1.SetActive(!QTE_UI1.activeSelf);
            }

            //X�{�^��
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)) && QTEcount == 0)
            {
                QTEcount = 3;
                Debug.Log(QTEcount);
            }

            //A�{�^��
            if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton0)) && QTEcount == 3)
            {
                if (QTE_UI.activeSelf)
                {
                    QTE_UI.SetActive(!QTE_UI.activeSelf);
                    QTE_UI1.SetActive(!QTE_UI1.activeSelf);
                    Debug.Log("QTE");
                    //QTEcount = ChangeImage.Length;
                    First = false;
                    QTETimer.Success = true;
                }
            }
        }


        if (other.gameObject.name == "QTEarea2" && !First)
        {
            if (!QTE_UI.activeSelf && QTEcount == 0)
            {
                //�@UI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
                QTE_UI.SetActive(!QTE_UI.activeSelf);
                QTE_UI1.SetActive(!QTE_UI1.activeSelf);
            }

            //X�{�^��
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)) && QTEcount == 0)
            {
                QTEcount = 1;
            }
            //Y�{�^��
            if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3)) && QTEcount == 1)
            {
                QTEcount = 2;
            }
            //B�{�^��
            if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1)) && QTEcount == 2)
            {
                QTEcount = 3;
            }
            //A�{�^��
            if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0)) && QTEcount == 3)
            {
                SceneManager.LoadScene("QTE seikou2", LoadSceneMode.Single);
                QTE_UI.SetActive(!QTE_UI.activeSelf);
                QTE_UI1.SetActive(!QTE_UI1.activeSelf);
                Debug.Log("QTE2");
                //QTEcount = ChangeImage.Length;
                QTEflag = false;
                QTETimer.Success = true;
            }
        }
    }


    void QTE_sippai()
    {
        if (First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            QTE_UI1.SetActive(!QTE_UI1.activeSelf);
            SceneManager.LoadScene("QTE sippai1", LoadSceneMode.Single);
        }

        if (!First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            QTE_UI1.SetActive(!QTE_UI1.activeSelf);
            SceneManager.LoadScene("QTE sippai2", LoadSceneMode.Single);
        }
    }
}