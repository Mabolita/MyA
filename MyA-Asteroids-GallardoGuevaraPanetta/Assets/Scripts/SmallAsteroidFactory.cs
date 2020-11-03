using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidFactory : IFactory<Asteroid>
{
    public GameObject prefab;


    public Asteroid Create()
    {
        var obj = Resources.Load<Asteroid>("Prefab/Small Asteroid");
        var rr = Random.Range(4, 12);
        obj.SetMaxThrust(rr);
        obj.SetMaxTorque(300);
        return Object.Instantiate(obj);



    }
}
