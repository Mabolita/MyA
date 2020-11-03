using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroidFactory : IFactory<Asteroid>
{
    public GameObject prefab;


    public Asteroid Create()
    {
        var obj = Resources.Load<Asteroid>("Prefab/Medium Asteroid");
        var rr = Random.Range(10, 20);
        obj.SetMaxThrust(rr);
        obj.SetMaxTorque(10);
        return Object.Instantiate(obj);



    }
}
