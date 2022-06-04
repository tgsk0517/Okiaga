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

    public PropertyName id
    {
        get
        {
            return new PropertyName("method");
        }
    }
}