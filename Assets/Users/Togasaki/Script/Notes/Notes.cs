using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notes : MonoBehaviour,INotes
{
    public CancellationTokenSource tokenSource = new CancellationTokenSource();
    CancellationToken token;

    /// <summary>
    /// バーの速度
    /// </summary>
    public float barSpeed = 1f;

    /// <summary>
    /// 叩く回数
    /// </summary>
    public int attackNum =1;

    [SerializeField, Header("テキスト")]
    private TextMeshProUGUI txt;

    public int typeNum =0;

    public bool isFailed = false;

    private void Awake()
    {
        token = tokenSource.Token;
    }

    private void FixedUpdate()
    {
        if (transform != null)
            MoveToEnd();
    }

    public void BarInit()
    {
        transform.position = NotesManager.Instance.startPos.position;
        txt.text = attackNum.ToString();
    }

    /// <summary>
    /// 最初の位置から最後の位置へ移動
    /// </summary>
    private void MoveToEnd()
    {
        switch(typeNum)
        {
            case 0:
                transform.position = Vector3.MoveTowards(transform.position, NotesManager.Instance.endPos.position, barSpeed * Time.deltaTime);
                break;
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, NotesManager.Instance.mugenEndPos.position, barSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// インターフェイス
    /// </summary>
    public void EnterNotification()
    {
        Judge();
    }

    void Judge()
    {
        attackNum--;
        NotesManager.Instance.beatedOkiagari++;
        OkiagariGenerater.Instance.DestroyOkiagari();
        OkiagariGenerater.Instance.GenerateOkiagari();
        txt.text = attackNum.ToString();
        if (attackNum <= 0)
        {
            //残機を1減らし、アニメーションを呼び出したあと、自分をデストロイ
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        tokenSource.Cancel();
    }

    public void MissNotification()
    {

    }
}
