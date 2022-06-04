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
    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<INotes>();

        if(target != null)
        {
            target.EnterNotification();
        }
    }

}
