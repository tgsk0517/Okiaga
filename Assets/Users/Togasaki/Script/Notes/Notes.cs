using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Notes : MonoBehaviour,INotes
{
    [SerializeField, Header("爆発obj")]
    private GameObject[] bombObj;

    public CancellationTokenSource tokenSource = new CancellationTokenSource();
    CancellationToken token;

    /// <summary>
    /// バーの速度
    /// </summary>
    public float barSpeed = 1f;

    private void Awake()
    {
        token = tokenSource.Token;
    }

    private void Start()
    {
        BarInit();
    }

    private void FixedUpdate()
    {
        MoveToEnd();
    }


    private void BarInit()
    {
        transform.position = NotesManager.Instance.startPos.position;
    }

    /// <summary>
    /// 最初の位置から最後の位置へ移動
    /// </summary>
    private void MoveToEnd()
    {
        transform.position = Vector3.MoveTowards(transform.position, NotesManager.Instance.endPos.position, barSpeed * Time.deltaTime);

    }

    /// <summary>
    /// インターフェイス
    /// </summary>
    public void EnterNotification()
    {
        Judge().Forget();
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
