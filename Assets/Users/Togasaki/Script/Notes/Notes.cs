using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Notes : MonoBehaviour,INotes
{
    [SerializeField, Header("����obj")]
    private GameObject[] bombObj;

    public CancellationTokenSource tokenSource = new CancellationTokenSource();
    CancellationToken token;

    /// <summary>
    /// �o�[�̑��x
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
    /// �ŏ��̈ʒu����Ō�̈ʒu�ֈړ�
    /// </summary>
    private void MoveToEnd()
    {
        transform.position = Vector3.MoveTowards(transform.position, NotesManager.Instance.endPos.position, barSpeed * Time.deltaTime);

    }

    /// <summary>
    /// �C���^�[�t�F�C�X
    /// </summary>
    public void EnterNotification()
    {
        Judge().Forget();
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
