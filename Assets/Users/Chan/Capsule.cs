using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Transform tf;
    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    private Vector3 startPosition;
    private void Start() 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
        startPosition = m_Transform.localPosition;
    }
    void Update () 
    {
        m_Rigidbody.centerOfMass = tf.localPosition;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<Transform>().position = new Vector3(0, 2, 0);
            GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_Rigidbody.constraints = RigidbodyConstraints.None; 
        }
        
    }

    void PositionLock()
    {
        if(m_Transform.localPosition != startPosition) 
            m_Transform.localPosition = startPosition;
    }

    void AngleLock()
    {
        if(!(m_Transform.localEulerAngles.x < 45 || m_Transform.localEulerAngles.x > 315))
            //m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            {
                GetComponent<Transform>().localRotation = new Quaternion(0, 0, 0, 0);
            }
    }
}
