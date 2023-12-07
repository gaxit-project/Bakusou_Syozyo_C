using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//�V�[���؂�ւ��Ɏg�p���郉�C�u����
using UnityEngine.SceneManagement;


//�����_����QTE
public class QTE3 : MonoBehaviour
{

    public static int QTEcount;
    [SerializeField] private GameObject QTE_UI, QTE_UI1;

    //1��ڂ��ǂ���
    public static bool First;

    //QTE�����ǂ���
    public static bool QTEflag = false;

    /// <summary>
    //�摜�̖���
    const int N = 4;
    //�����i�[
    public static int[] RandomQTE = new int[N];

    //0 = X, 1 = Y, 2 = B, 3 = A
    int[] K = { 0, 3, -1, -1 };
    int[] M = { -1, -1, -1, -1 };


    private void Start()
    {
        QTEflag = true;
        First = true;
        for (int i = 0; i < N; i++)
        {
            RandomQTE[i] = -1;
        }
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
        if (other.gameObject.name == "QTEarea1")
        {
            QTEcount = 0;
            SetUp(K);
        }
        if (other.gameObject.name == "QTEarea2")
        {
            QTEcount = 0;
            SetUp(M);
        }

        //////////////////////////////////////////////////////////////
        if (other.gameObject.name == "QTEarea1")
        {
            for (int i = 0; i < N; i++)
            {
                Debug.Log(RandomQTE[i] + " " + i + "��QTE�R�}���h3");
            }
        }
        if (other.gameObject.name == "QTEarea2")
        {
            for (int i = 0; i < N; i++)
            {
                Debug.Log(RandomQTE[i] + " " + i + "��QTE�R�}���h4");
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
                QTE_UI1.SetActive(!QTE_UI1.activeSelf);
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
            if (QTEcount >= 2)
            {
                if (QTE_UI.activeSelf)
                {
                    QTE_UI.SetActive(!QTE_UI.activeSelf);
                    QTE_UI1.SetActive(!QTE_UI1.activeSelf);
                    Debug.Log("RandomQTE");
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
                    QTE_UI1.SetActive(!QTE_UI1.activeSelf);
                    Debug.Log("RandomQTE2");
                    QTEflag = false;
                    QTETimer.Success = true;
                }
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        //QTE_sippai(other);
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
        //Y�{�^��
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
        //B�{�^��
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
        //A�{�^��
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


    void SetUp(int[] Set)
    {
        for (int i = 0; i < N; i++)
        {
            if (0 <= Set[i])
            {
                RandomQTE[i] = Set[i];
            }
        }

        for (int i = 0; i < N; i++)
        {
            if (0 > Set[i])
            {
                int tmp = Random.Range(0, N);
                if (i == 0)
                {
                    if (RandomQTE[i + 1] != tmp)
                    {
                        RandomQTE[i] = tmp;
                    }
                    else
                    {
                        i--;
                    }
                }
                else if (i != N - 1) 
                {
                    if (RandomQTE[i + 1] != tmp && RandomQTE[i - 1] != tmp) 
                    {
                        RandomQTE[i] = tmp;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    if (RandomQTE[i - 1] != tmp)
                    {
                        RandomQTE[i] = tmp;
                    }
                    else
                    {
                        i--;
                    }
                }
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