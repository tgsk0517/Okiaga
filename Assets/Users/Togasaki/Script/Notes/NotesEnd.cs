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

    [SerializeField, Header("ノーツ")]
    private GameObject notes;


    /// <summary>
    /// ミスした時の処理
    /// HPを減らし、ノーツを消す
    /// </summary>
    public void EnterNotification()
    {
        
    }

    public void MissNotification()
    {
        //HPを減らす処理
        NotesManager.Instance.bar.TakeDamage();

        //ノーツを消す処理
        StartCoroutine("MissPerformance");

    }

    /// <summary>
    /// ミスした時、ノーツの色を変えてノーツを消す
    /// </summary>
    IEnumerator MissPerformance()
    {
        notes.GetComponent<Notes>().tokenSource.Cancel();
        notes.GetComponent<Notes>().isFailed = true;
        meshRenderer.material.color = missColor;
        NotesManager.Instance.missNum++;

        yield return new WaitForSeconds(0.5f);

        Destroy(transform.parent.gameObject);

        yield break;
    }

}
