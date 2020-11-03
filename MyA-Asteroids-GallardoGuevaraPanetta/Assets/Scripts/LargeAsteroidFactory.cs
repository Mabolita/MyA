using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroidFactory : IFactory<Asteroid>
{
    public GameObject prefab;


    public Asteroid Create()
    {
        var obj = Resources.Load<Asteroid>("Prefab/Large Asteroid");
        var rr = Random.Range(50, 80);
        obj.SetMaxThrust(rr);
        obj.SetMaxTorque(14);
        return Object.Instantiate(obj);



    }
}
