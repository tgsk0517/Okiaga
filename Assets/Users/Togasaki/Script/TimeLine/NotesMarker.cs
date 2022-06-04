using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// �e�L�X�g���𑗐M����}�[�J�[
[System.Serializable, DisplayName("�m�[�c�̃}�[�J�[")]
public class NotesMarker : Marker, INotification
{
    /// <summary>
    /// �m�[�c�̃X�s�[�h
    /// </summary>
    public float speed;

    /// <summary>
    /// �m�[�c�̉���
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