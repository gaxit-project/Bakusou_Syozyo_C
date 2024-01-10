//stage1�V�[����Goal�ɃA�^�b�`

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{

    [SerializeField] private GameObject target; //target��GoalObject
    [SerializeField] Text counter; //counter��Distance
    [SerializeField] Slider dsSlider; //dsSlider��GoalDistance
    Vector3 targetPos, playerPos;

    void Start()
    {        
        /* �^�[�Q�b�g�̃|�W�V�������擾 */
        targetPos = target.transform.position;
        /* �^�[�Q�b�g�ƃv���C���[�̋������擾 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //�X���C�_�[�̍Œ�l�ƍő�l�̐ݒ�
        dsSlider.minValue = 0;

        if (!PlayerController2.two)
        {
            dsSlider.maxValue = dis;
            PlayerPrefs.SetInt("Distance", dis);
            PlayerPrefs.Save();
        }
        else
        {
            dsSlider.maxValue = PlayerPrefs.GetInt("Distance");
        }

        //�X���C�_�[�̌��ݒl�̐ݒ�
        dsSlider.value = dis;
    }

    void Update()
    {
        /* �^�[�Q�b�g�ƃv���C���[�̋������擾 */
        int dis = (int)Vector3.Distance(targetPos, CharaSelect.Chara.transform.position);

        //�X���C�_�[�̌��ݒl�̐ݒ�
        dsSlider.value = dis;

        //�S�[���܂ł̋�����\��
        counter.text = "����" + Convert.ToString(dis) + "m";
    }
}
