using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// テキスト情報を送信するマーカー
[System.Serializable, DisplayName("ノーツのマーカー")]
public class NotesMarker : Marker, INotification
{
    /// <summary>
    /// ノーツのスピード
    /// </summary>
    public float speed;

    /// <summary>
    /// ノーツの横幅
    /// </summary>
    public float notesWidth = 1.0f;

    /// <summary>
    /// ノートを叩く回数
    /// </summary>
    public int notesNum = 1;

    /// <summary>
    /// ノーツのタイプ
    /// </summary>
    public int type = 0;

    public PropertyName id
    {
        get
        {
            return new PropertyName("method");
        }
    }
}