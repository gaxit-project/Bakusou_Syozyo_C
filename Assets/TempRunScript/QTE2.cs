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
    /// </summary>


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
                    if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)))
                    {
                        QTEcount++;
                        Debug.Log(QTEcount);
                    }
                    break;
                case 1:
                    //Y�{�^��
                    if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3)))
                    {
                        QTEcount++;
                        Debug.Log(QTEcount);
                    }
                    break;
                case 2:
                    //B�{�^��
                    if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1)))
                    {
                        QTEcount++;
                        Debug.Log(QTEcount);
                    }
                    break;
                case 3:
                    //A�{�^��
                    if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0)))
                    {
                        QTEcount++;
                        Debug.Log(QTEcount);
                    }
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
                    if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)))
                    {
                        QTEcount++;
                    }
                    break;
                case 1:
                    //Y�{�^��
                    if ((Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.JoystickButton3)))
                    {
                        QTEcount++;
                    }
                    break;
                case 2:
                    //B�{�^��
                    if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton1)))
                    {
                        QTEcount++;
                    }
                    break;
                case 3:
                    //A�{�^��
                    if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.JoystickButton0)))
                    {
                        QTEcount++;
                    }
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
                    QTEflag = false;
                    QTEcount = 4;
                }
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "QTEarea1" && First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            Debug.Log(Goal.Tikoku + "1");
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            SceneManager.LoadScene("QTE sippai1", LoadSceneMode.Single);
        }

        if (other.gameObject.name == "QTEarea2" && !First)
        {
            QTEflag = false;
            Goal.Tikoku = true;
            Debug.Log(Goal.Tikoku + "2");
            QTE_UI.SetActive(!QTE_UI.activeSelf);
            SceneManager.LoadScene("QTE sippai2", LoadSceneMode.Single);
        }
    }
}