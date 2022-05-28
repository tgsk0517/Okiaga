using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    //�^�C�}�[�p�ϐ�
    [SerializeField]float LimitTime;                   //�^�C�}�[�̐ݒ莞��
    private bool counting;�@�@�@�@�@�@�@�@�@�@//�^�C�}�[�ғ��t���O

    //�f�W�^���\��
    [SerializeField]private GameObject digetalText;
    private TextMeshProUGUI digetalTextComponent;

    void Start()
    {
        digetalTextComponent = digetalText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(counting)
        {
            TimerCount();
        }
    }

    //�^�C�}�[�@�\
    void TimerCount()
    {
        //60�b����o�ߎ��Ԃ�����
        LimitTime -= Time.deltaTime;

        DigitalDisplay();

        //�^�C�}�[�̒�~
        if (LimitTime <= 0)
        {
            counting = false;
        }
    }

    //�^�C�}�[�̃f�W�^���\��
    void DigitalDisplay()
    {
        digetalTextComponent.text = LimitTime.ToString("F2");
    }

    //�^�C�}�[�X�^�[�g
    public void PushStart()
    {
        counting = true;
    }
}
