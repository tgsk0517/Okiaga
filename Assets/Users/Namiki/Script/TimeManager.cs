using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //�v���O���X�o�[���擾
    [SerializeField]private Image progressBar;
    //�\���e�L�X�g���擾
    [SerializeField]private TextMeshProUGUI progressText;
    //���Ԃ��擾
    private float time;
    //�c�莞�Ԃ��擾
    [SerializeField] private float timeLimit = 60f;

    void Start()
    {
        StartCoroutine(ProgressBarTime());
        StartCoroutine(TimeResult());
    }

    #region �c�莞�Ԃ�\������
    IEnumerator TimeResult()
    {
        while(true)
        {
            time += Time.deltaTime;
            progressText.text = Mathf.Ceil(timeLimit - time) + "";
            if (progressBar.fillAmount < 0)
            {
                break;
            }
            yield return null;
        }
    }
    #endregion

    #region �v���O���X�o�[���c��b��/timeLimit��������
    IEnumerator ProgressBarTime()
    {
        while(true)
        {
            progressBar.fillAmount = (timeLimit - time)/ timeLimit;
            if(progressBar.fillAmount < 0)
            {
                break;
            }
            yield return null;
        }
    }
    #endregion
}
