using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//�V�[���؂�ւ��Ɏg�p���郉�C�u����
using UnityEngine.SceneManagement;


//�����_����QTE
public class QTE2 : MonoBehaviour
{

    public static int QTEcount;
    [SerializeField] private GameObject QTE_UI;

    //1��ڂ��ǂ���
    bool First;

    //QTE�����ǂ���
    public static bool QTEflag = false;

    /// <summary>
    //�摜�̖���
    const int N = 4;
    //�����i�[
    public static int[] RandomQTE = new int [N];


    private void Start()
    {
        QTEflag = true;
        First = true;
        for (int i = 0; i < N; i++)
        {
            RandomQTE[i] = 4;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "QTEarea1" || other.gameObject.name == "QTEarea2")
        {
            QTEcount = 0;

            for (int i = 0; i < N; i++) 
            {
                int tmp = Random.Range(0, N);
                if (i == 0)
                {
                    RandomQTE[i] = tmp;
                }
                else if(RandomQTE[i-1] != tmp)
                {
                    RandomQTE[i] = tmp;
                }
                else
                {
                    i--;
                }
            }
        }

        //////////////////////////////////////////////////////////////
        if(other.gameObject.name == "QTEarea1")
        {
            for (int i = 0; i < N; i++)
            {
                Debug.Log(RandomQTE[i] +" "+ i + "��QTE�R�}���h");
            }
        }
        if (other.gameObject.name == "QTEarea2")
        {
            for (int i = 0; i < N; i++)
            {
                Debug.Log(RandomQTE[i] +" "+ i + "��QTE�R�}���h2");
            }
        }
        ////////////////////////////////////////////////////////////////////
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "QTEarea1" && First)
        {
            if (!QTE_UI.activeSelf && QTEcount == 0)
            {
                //�@UI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
                QTE_UI.SetActive(!QTE_UI.activeSelf);
            }

            switch (RandomQTE[QTEcount])
            {
                case 0:
                    //X�{�^��
                    X_button();
                    break;
                case 1:
                    //Y�{�^��
                    Y_button();
                    break;
                case 2:
                    //B�{�^��
                    B_button();
                    break;
                case 3:
                    //A�{�^��
                    A_button();
                    break;
                default:
                    Debug.Log("�Ⴄ�̏o���H");
                    break;
            }
            if(QTEcount >= 2)
            {
                if (QTE_UI.activeSelf)
                {
                    QTE_UI.SetActive(!QTE_UI.activeSelf);
                    Debug.Log("RandomQTE");
                    QTEcount = 4;
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
            }

            switch (RandomQTE[QTEcount])
            {
                case 0:
                    //X�{�^��
                    X_button();
                    break;
                case 1:
                    //Y�{�^��
                    Y_button();
                    break;
                case 2:
                    //B�{�^��
                    B_button();
                    break;
                case 3:
                    //A�{�^��
                    A_button();
                    break;
                default:
                    Debug.Log("�Ⴄ�̏o���H");
                    break;
            }
            if (QTEcount >= 4)
            {
                if (QTE_UI.activeSelf)
                {
                    SceneManager.LoadScene("QTE seikou2", LoadSceneMode.Single);
                    QTE_UI.SetActive(!QTE_UI.activeSelf);
                    Debug.Log("RandomQTE2");
                    QTEcount = 4;
                    QTEflag = false;
                    QTETimer.Success = true;
                }
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        //QTE1.QTE_sippai(other, QTE_UI, First);
    }






    void X_button()
    {
        //X�{�^��
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            QTEcount++;
            QTETimer2.Success = true;
        }
        else if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            QTETimer.Miss = true;
            QTETimer2.Miss = true;
        }
    }
    void Y_button()
    {
        //X�{�^��
        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            QTEcount++;
            QTETimer2.Success = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            QTETimer.Miss = true;
            QTETimer2.Miss = true;
        }
    }
    void B_button()
    {
        //X�{�^��
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            QTEcount++;
            QTETimer2.Success = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            QTETimer.Miss = true;
            QTETimer2.Miss = true;
        }
    }
    void A_button()
    {
        //X�{�^��
        if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            QTEcount++;
            QTETimer2.Success = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            QTETimer.Miss = true;
            QTETimer2.Miss = true;
        }
    }
}