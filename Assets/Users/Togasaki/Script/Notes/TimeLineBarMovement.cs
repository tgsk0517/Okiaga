using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INotes
{
    /// <summary>
    /// �N����ʒm
    /// </summary>
    void EnterNotification();
}

public class TimeLineBarMovement : MonoBehaviour
{
    [SerializeField, Header("�����͂��߂̋���")]
    private Transform startPos;

    [SerializeField, Header("�����I���̋���")]
    private Transform endPos;

    /// <summary>
    /// �o�[�̑��x
    /// </summary>
    public float barSpeed = 1f;

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
        transform.position = startPos.position;
    }

    private void MoveToEnd()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos.position, barSpeed * Time.deltaTime);
        if(transform.position == endPos.position)
        {
            transform.position = startPos.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<INotes>();

        if(target != null)
        {
            target.EnterNotification();
        }
    }

}
