using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI�����̃N���X���g�p����錾
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    // Image �R���|�[�l���g���i�[����ϐ�
    private Image m_Image;
    // �X�v���C�g�I�u�W�F�N�g���i�[����z��
    public Sprite[] m_Sprite;
    // �X�v���C�g�I�u�W�F�N�g��ύX���邽�߂̃t���O
    int Change;

    // �Q�[���J�n���Ɏ��s���鏈��
    void Start()
    {
        // �X�v���C�g�I�u�W�F�N�g��ύX���邽�߂̃t���O�� 
        // Image �R���|�[�l���g���擾���ĕϐ� m_Image �Ɋi�[
        m_Image = GetComponent<Image>();
    }

    // �Q�[�����s���ɖ��t���[�����s���鏈��
    void Update()
    {
        if (QTE1.QTEflag)
        {
            Change = QTE1.QTEcount;

            if (Change == 0)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                m_Image.sprite = m_Sprite[0];
            }
            if (Change == 1)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                m_Image.sprite = m_Sprite[1];
            }
            if (Change == 2)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                m_Image.sprite = m_Sprite[2];
            }
            if (Change == 3)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                m_Image.sprite = m_Sprite[3];
            }
        }


        if (QTE2.QTEflag)
        {
            Change = QTE2.RandomQTE[QTE2.QTEcount];

            if (Change == 0)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX {X}
                m_Image.sprite = m_Sprite[0];
            }
            if (Change == 1)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX {Y}
                m_Image.sprite = m_Sprite[1];
            }
            if (Change == 2)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX {B}
                m_Image.sprite = m_Sprite[2];
            }
            if (Change == 3)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX {A}
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