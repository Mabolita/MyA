using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFactory : IFactory<ExplosiveBullet>
{
    public GameObject prefab;


    public ExplosiveBullet Create()
    {
        var obj = Resources.Load<ExplosiveBullet>("Prefab/Bomber");
        obj.SetProjectileSpeed(300);
        return Object.Instantiate(obj);



    }
}
