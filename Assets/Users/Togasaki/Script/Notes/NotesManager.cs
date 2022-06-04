using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NotesManager : SingletonMonoBehaviour<NotesManager>, INotificationReceiver
{
    /// <summary>
    /// ノートスピード
    /// </summary>
    private float notesSpeed;

    [SerializeField, Header("ノートオブジェクト")]
    private GameObject notesObj;

    /// <summary>
    /// 動きはじめの距離
    /// </summary>
    public Transform startPos;

    /// <summary>
    /// 動き終わりの距離
    /// </summary>
    public Transform endPos;

    /// <summary>
    /// HPバースクリプト
    /// </summary>
    public HPControler bar;

    public void SpawnNotes(float spd,float wid)
    {
        GameObject obj = Instantiate(notesObj, startPos.position, Quaternion.identity);
        obj.transform.localScale = new Vector3(wid, obj.transform.localScale.y, obj.transform.localScale.z);
    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        var target = notification as NotesMarker;
        if (target == null)
            return;

        SpawnNotes(target.speed, target.notesWidth);
    }

}
