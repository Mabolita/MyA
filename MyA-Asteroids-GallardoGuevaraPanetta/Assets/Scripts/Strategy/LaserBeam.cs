using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour, IThrow
{
    // public GameObject ShootPoint;
    //public float distance;
    public GameObject laser;




    public void Throw()
    {

            laser.SetActive(true);
 
        // RaycastHit2D[] hitInfo = Physics2D.RaycastAll(ShootPoint.transform.position, transform.up, distance);
        // foreach (var item in hitInfo)
        //  {
        //    if(item.transform.gameObject.layer == 9)
        //   {
        //       item.transform.gameObject.SetActive(false);
        //   }
        // }
    }
}
