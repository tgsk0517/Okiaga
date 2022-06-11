using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Transform tf;
    private Rigidbody m_Rigidbody;
    private Transform m_Transform;
    [SerializeField]private float power = 15f;
    private void Start() 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
    }
    void Update () 
    {
        m_Rigidbody.centerOfMass = tf.localPosition;

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(0, 0, 1) * power);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(0, 0, -1) * power);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(-1, 0, 0) * power);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(1, 0, 0) * power);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<Transform>().localPosition = new Vector3(0, 2, 0);
            GetComponent<Transform>().localRotation = new Quaternion(0, 0, 0, 0);
        }
        PositionLock();
    }

    void PositionLock()
    {
        if(!(m_Transform.localEulerAngles.x < 45 || m_Transform.localEulerAngles.x > 315))
            //m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            {
                GetComponent<Transform>().localPosition = new Vector3(0, 2, 0);
            GetComponent<Transform>().localRotation = new Quaternion(0, 0, 0, 0);
            }
    }

    void AngleRange()
    {

    }
}
