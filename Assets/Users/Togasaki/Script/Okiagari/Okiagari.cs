using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Okiagari : MonoBehaviour
{
    CancellationTokenSource source = new CancellationTokenSource();
    CancellationTokenSource endSource = new CancellationTokenSource();

    //private void Awake()
    //{
    //    gameObject.transform.position = OkiagariGenerater.Instance.startPos.position;
    //}

    public async UniTask MoveToHome()
    {
        CancellationToken tkn = source.Token;

        while(true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, OkiagariGenerater.Instance.homePos.position, OkiagariGenerater.Instance.moveSpeed);
            if (gameObject.transform.position == OkiagariGenerater.Instance.homePos.position)
            {
                source.Cancel();
            }
            await UniTask.Delay(20, cancellationToken: tkn);
        }
    }

    public async UniTask MoveToEnd()
    {
        CancellationToken tkn = endSource.Token;

        while (true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, OkiagariGenerater.Instance.endPos.position, OkiagariGenerater.Instance.moveSpeed);
            if (gameObject.transform.position == OkiagariGenerater.Instance.endPos.position)
            {
                endSource.Cancel();
                Destroy(gameObject);
            }
            await UniTask.Delay(20, cancellationToken: tkn);
        }

    }

}
