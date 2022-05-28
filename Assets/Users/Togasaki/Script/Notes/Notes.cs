using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Notes : MonoBehaviour,INotes
{
    [SerializeField, Header("����obj")]
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
            //TimeLineBar�N�����ɃX�y�[�X�������ꂽ��
            if(Input.GetKey(KeyCode.Space))
            {
                //�c�@��1���炵�A�A�j���[�V�������Ăяo�������ƁA�������f�X�g���C


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
