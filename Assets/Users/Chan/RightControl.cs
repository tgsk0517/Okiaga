using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControl : SingletonMonoBehaviour<RightControl>
{
    public ParticleSystem explosionParticle;
    private Transform m_Transform;
    private Vector3 startPoint;
    public Transform hitPoint;
    private Vector3 hitPointPosition;

    public float speed =0.01f;
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
        if(Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("Move");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            explosionParticle.Play();
        }
    }
    public IEnumerator Move()
    {
        for(float t = 0;t < 1.1;t += 0.1f)
        {
            m_Transform.position = Vector3.Lerp(startPoint, hitPointPosition, t);
            yield return new WaitForSeconds(speed);
        }
        m_Transform.position = startPoint; 
    }

}
