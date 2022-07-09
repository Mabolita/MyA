using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IFactory<Bullet>
{

    public GameObject prefab;


    public Bullet Create()
    {
        var obj = Resources.Load<Bullet>("Prefab/Bullet");
        obj.SetProjectileSpeed(300);
        return Object.Instantiate(obj);
       


    }

}
