using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{   
    public float maxZoom;
    public float minZoom;
    public float sensitivity;
    public float blablabla = 10 ;


    void Update()
    {
        Vector3 direction = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        GetComponent<Camera>().transform.position += direction;
        
        ZoomCamera(0.01f);
    }

    void ZoomCamera(float increment)
    {
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize - increment * sensitivity, minZoom, maxZoom);
    }
}
