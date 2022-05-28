using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Notes : MonoBehaviour,INotes
{
    [SerializeField, Header("爆発obj")]
    private GameObject[] bombObj;

    CancellationTokenSource tokenSource = new CancellationTokenSource();
    CancellationToken token;

    public void EnterNotification()
    {
        Judge().Forget();
    }

    private void Awake()
    {
        token = tokenSource.Token;
    }

    async UniTask Judge()
    {
        while(true)
        {
            //TimeLineBar侵入中にスペースが押されたら
            if(Input.GetKey(KeyCode.Space))
            {
                //残機を1減らし、アニメーションを呼び出したあと、自分をデストロイ


                Instantiate(bombObj[Random.Range(0, bombObj.Length)], new Vector3(transform.position.x,transform.position.y + 3,transform.position.z), Quaternion.identity);

                Destroy(gameObject);
            }

            await UniTask.Delay(20, cancellationToken: token);
        }

    }

    private void OnDestroy()
    {
        tokenSource.Cancel();
    }

}
