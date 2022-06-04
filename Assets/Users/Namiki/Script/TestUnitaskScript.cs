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
    ////キャンセルトークン
    //private CancellationTokenSource tokenSource;
    ////キャンセルトークン
    //private CancellationTokenSource tokenSource2;
    ////プログレスバーを取得
    //[SerializeField] private Image progressBar;
    ////表示テキストを取得
    //[SerializeField] private TextMeshProUGUI progressText;
    ////時間を取得
    //private float time;
    ////残り時間を取得
    //[SerializeField] private float timeLimit = 60f;

    ////トークンの生成と処理の開始。
    //private async void Start()
    //{
    //    tokenSource = new CancellationTokenSource();
    //    await TimeResult(tokenSource.Token);
    //    await ProgressBarTime(tokenSource2.Token);
    //}

    //// Delay用の非同期処理
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
