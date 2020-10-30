using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour, IThrow
{
    public Player player;


    public void Throw()
    {
        MultipleObjectPooler.Instance.SpawnFromPool("ExplosiveBullet", player.fireposition.position, player.fireposition.rotation);
    }
  
}
