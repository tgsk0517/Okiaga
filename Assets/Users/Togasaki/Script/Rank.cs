using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;


public class Rank : MonoBehaviour
{
    CancellationTokenSource source = new CancellationTokenSource();

    [SerializeField]
    private int time;

    [SerializeField]
    private TextMeshProUGUI txt;

    public async UniTask Appear()
    {
        CancellationToken tkn = source.Token;
        await UniTask.Delay(time, cancellationToken: tkn);
        gameObject.SetActive(true);
        source.Cancel();
    }

    private void OnDestroy()
    {
        source.Cancel();
    }
}
