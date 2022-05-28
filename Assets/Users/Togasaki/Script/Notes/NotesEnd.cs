using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesEnd : MonoBehaviour, INotes
{
    [SerializeField, Header("色変更用メッシュレンダラー参照")]
    private MeshRenderer meshRenderer;

    [SerializeField, Header("ミス時色")]
    private Color missColor;

    [SerializeField, Header("ディレイ")]
    private float delayTime;

    /// <summary>
    /// ミスした時の処理
    /// HPを減らし、ノーツを消す
    /// </summary>
    public void EnterNotification()
    {
        //HPを減らす処理

        //ノーツを消す処理
        StartCoroutine("MissPerformance");
    }

    /// <summary>
    /// ミスした時、ノーツの色を変えてノーツを消す
    /// </summary>
    IEnumerator MissPerformance()
    {
        meshRenderer.material.color = missColor;

        yield return new WaitForSeconds(delayTime);
        
        Destroy(transform.parent.gameObject);

        yield break;
    }

}
