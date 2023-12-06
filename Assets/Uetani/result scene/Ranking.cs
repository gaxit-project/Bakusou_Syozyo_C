//result�V�[����Canvas��Panel����Score�ɃA�^�b�`�ARank Text�ɂ�Score������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static int[] rank = new int[3] {0, 0, 0}; //1�ʂ���3�ʂ܂ł̃����L���O�A�����l��0�Ȃ̂Ń}�C�i�X�̂Ƃ��̓����L���O���X�V���Ȃ�
    [SerializeField] Text rankText;
    private bool flag = true; //flag��true�Ȃ烉���L���O�̍X�V���ł���Afalse�Ȃ�X�V���~����
    private int tmp = 0;
    public static int rankScore; //�S�[���������̃X�R�A

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        rankScore = (int)GameManager.countdownSeconds * 1000 + MinusTime.minusScore; //�c��̐�������*1000+��Q���ɓ����������̃}�C�i�X
        MinusTime.minusScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rank.Length; i++)
        {
            if (rank[i] < rankScore && flag && Goal.goal) //flag��0�Ń����L���O���̃X�R�A���傫���ꍇ�X�V
            {
                if(rank[0] < rankScore) //1�ʂ̃X�R�A���傫���ꍇ�A1�ʂ�2�ʂ̃X�R�A���ꊷ���A2�ʂ�3�ʂ̃X�R�A����ꊷ����
                {
                    tmp = rank[1];
                    rank[2] = tmp;
                    tmp = rank[0];
                    rank[1] = tmp;
                }else if(rank[1] < rankScore) //2�ʂ̃X�R�A���傫���ꍇ�A2�ʂ�3�ʂ̃X�R�A����ꊷ����
                {
                    tmp = rank[1];
                    rank[2] = tmp;
                }
                rank[i] = rankScore;
                flag = false;
            }
        }
        rankText.text = "1�ʁF" + rank[0].ToString() + "\n2�ʁF" + rank[1].ToString() + "\n3�ʁF" + rank[2].ToString(); //�����L���O�̕\��
    }
}
