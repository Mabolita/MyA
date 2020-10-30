using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IFactory<Bullet>
{
    private readonly ObjectPooler _objectPooler;
    public Player player;
    //public ObjectPooler _objectPooler;


  public Bullet Create()
  {
        //Debug.Log(player);
        GameObject myObject = GameObject.Instantiate(_objectPooler.pooledObject, _objectPooler.transform.position, _objectPooler.transform.rotation);
        Bullet bala = myObject.GetComponent<Bullet>();
        if(myObject == null)
        {
          //Debug.Log("my object is null");

        }
        Debug.Log(bala);

        return bala;
  
  }
    public BulletFactory(ObjectPooler pooler, Player playerObject)
    {
        _objectPooler = pooler;
        player = playerObject;
    }
}
