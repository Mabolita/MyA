using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour, IThrow
{
    public Player player;


    public void Throw()
    {
        var bullet = player._explosiveBulletPool.Get();
        bullet._explosivepool = player._explosiveBulletPool;
        bullet.transform.position = player.fireposition.transform.position;
        bullet.transform.rotation = transform.rotation;
    }
    public static void TurnOn(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    public static void TurnOff(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

}
