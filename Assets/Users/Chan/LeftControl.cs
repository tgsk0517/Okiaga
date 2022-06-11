using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftControl : MonoBehaviour
{
    private Transform m_Transform;
    private Vector3 startPoint;
    [SerializeField]public Transform hitPoint;
    private Vector3 hitPointPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        startPoint = m_Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hitPointPosition = hitPoint.position;
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("Move");
        }
    }
    IEnumerator Move()
    {
        for(float t = 0;t < 1.1;t += 0.2f)
        {
            m_Transform.position = Vector3.Lerp(startPoint, hitPointPosition, t);
            yield return new WaitForSeconds(0.1f);
        }
        m_Transform.position = startPoint; 
    }
}
