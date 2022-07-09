using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{

    public bool isWrappingX = false;
    public bool isWrappingY = false;
    private Camera cam;

    private void Awake()
    {
         cam = Camera.main;
    }

    private void Update()
    {
        ScreenWrapp();
    }
    void ScreenWrapp()
    {
       

        var viewportPosition = cam.WorldToViewportPoint(transform.position);
       
      
        Vector3 newPosition = transform.position;

        if (isWrappingX == false && viewportPosition.x > 1.04f || viewportPosition.x < -0.07f)
        {
            isWrappingX = true;
            newPosition.x = -(newPosition.x / 1.2f);
            isWrappingX = false;
        }

        if (isWrappingY == false && viewportPosition.y > 1.04f || viewportPosition.y < -0.07f)
        {
            isWrappingY = true;
            newPosition.y = -(newPosition.y / 1.2f);
            isWrappingY = false;
        }


        transform.position = newPosition;
    }

    private void OnBecameVisible()
    {
        isWrappingX = false;
        isWrappingY = false;
    }
    


}
  


