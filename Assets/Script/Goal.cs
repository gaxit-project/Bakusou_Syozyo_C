using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���؂�ւ��Ɏg�p���郉�C�u����

public class Goal : MonoBehaviour
{
    public string sceneName;

    public static bool Tikoku;
    public static bool goal;

    private void Start()
    {
        goal = false;
    }

    //�v���C���[�������蔻��ɓ��������̏���
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�S�[�����܂����I");
            goal = true;
            SceneManager.LoadScene(sceneName);

        }
    }

}