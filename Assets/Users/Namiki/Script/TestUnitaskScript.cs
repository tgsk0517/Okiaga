using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUnitaskScript : MonoBehaviour
{
    ////�L�����Z���g�[�N��
    //private CancellationTokenSource tokenSource;
    ////�L�����Z���g�[�N��
    //private CancellationTokenSource tokenSource2;
    ////�v���O���X�o�[���擾
    //[SerializeField] private Image progressBar;
    ////�\���e�L�X�g���擾
    //[SerializeField] private TextMeshProUGUI progressText;
    ////���Ԃ��擾
    //private float time;
    ////�c�莞�Ԃ��擾
    //[SerializeField] private float timeLimit = 60f;

    ////�g�[�N���̐����Ə����̊J�n�B
    //private async void Start()
    //{
    //    tokenSource = new CancellationTokenSource();
    //    await TimeResult(tokenSource.Token);
    //    await ProgressBarTime(tokenSource2.Token);
    //}

    //// Delay�p�̔񓯊�����
    //private async UniTask TimeResult(CancellationToken token)
    //{
    //    while(true)
    //    {
    //        time += Time.deltaTime;
    //        progressText.text = Mathf.Ceil(timeLimit - time) + "";
    //        if (progressBar.fillAmount < 0)
    //        {
    //            tokenSource.Cancel();
    //            break;
    //        }
    //        await UniTask.Yield(token);
    //    }
    //}

    //private async UniTask ProgressBarTime(CancellationToken token2)
    //{
    //    while(true)
    //    {
    //        progressBar.fillAmount = (timeLimit - time) / timeLimit;
    //        if (progressBar.fillAmount < 0)
    //        {
    //            tokenSource.Cancel();
    //            break;
    //        }
    //        await UniTask.Yield(token2);
    //    }
    //}
}
