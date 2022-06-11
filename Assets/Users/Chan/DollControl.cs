using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollControl : MonoBehaviour
{
    public Transform tf;
    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    private void Start() 
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return;
        }
        
    }


}
