using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLocalUpVector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //draw a blue line that represents the local up vector of the object
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 5f);
    }
}
