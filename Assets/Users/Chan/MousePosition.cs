using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public GameObject cursor;
    public GameObject hitPoint;
    public float time = 50f;

    // Update is called once per frame
    void Update()
    {
       //float distance = Vector2.Distance(hitPoint.position,cursor.position);
        if(Input.GetMouseButton(0))
        {
           
        }
         MousePositionReturn();
    }

    void MousePositionReturn()
    {
        if(cursor.transform.position != hitPoint.transform.position){
       cursor.transform.position = Vector3.MoveTowards(cursor.transform.position,hitPoint.transform.position,time * Time.deltaTime);
        }
    }
}
