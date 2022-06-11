using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Transform>().localPosition += new Vector3(0,1,0) * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Transform>().localPosition += new Vector3(0,-1,0) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Transform>().localPosition += new Vector3(1,0,0) * Time.deltaTime *20;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Transform>().localPosition += new Vector3(-1,0,0) * Time.deltaTime *20;
        }
    }
}
