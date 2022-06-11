using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkiagariGenerater : SingletonMonoBehaviour<OkiagariGenerater>
{
    [SerializeField, Header("生成オブジェクト")]
    private GameObject okiagariObj;

    /// <summary>
    /// スタート
    /// </summary>
    public Transform startPos;

    /// <summary>
    /// 定位置
    /// </summary>
    public Transform homePos;

    /// <summary>
    /// 終了
    /// </summary>
    public Transform endPos;

    /// <summary>
    /// 動く速さ
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// 現在の起き上がりオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject okiagariRef;

    int i = 0;

    /// <summary>
    /// 起き上がりを生成
    /// </summary>
    public void GenerateOkiagari()
    {
        i++;
        if(i != 94)
        {
            okiagariRef = Instantiate(okiagariObj, startPos.position, Quaternion.identity);
            okiagariRef.GetComponent<Okiagari>().MoveToHome().Forget();
        }
    }

    /// <summary>
    /// 起き上がりを消去
    /// </summary>
    public void DestroyOkiagari()
    {
        //Capsule.Instance.ResetPos();
        okiagariRef.GetComponent<Okiagari>().MoveToEnd().Forget();
    }

}
