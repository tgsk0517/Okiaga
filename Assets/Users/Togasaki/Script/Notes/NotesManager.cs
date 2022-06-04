using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NotesManager : SingletonMonoBehaviour<NotesManager>, INotificationReceiver
{
    /// <summary>
    /// �m�[�g�X�s�[�h
    /// </summary>
    private float notesSpeed;

    [SerializeField, Header("�m�[�g�I�u�W�F�N�g")]
    private GameObject notesObj;

    /// <summary>
    /// �����͂��߂̋���
    /// </summary>
    public Transform startPos;

    /// <summary>
    /// �����I���̋���
    /// </summary>
    public Transform endPos;

    /// <summary>
    /// HP�o�[�X�N���v�g
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
