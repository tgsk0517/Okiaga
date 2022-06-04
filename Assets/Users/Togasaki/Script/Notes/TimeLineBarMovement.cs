using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INotes
{
    /// <summary>
    /// N“ü‚ğ’Ê’m
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
