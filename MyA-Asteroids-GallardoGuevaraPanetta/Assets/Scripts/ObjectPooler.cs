using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willgrow;
    BulletFactory _bulletFactory;
    Player player;
   

    private List<GameObject> pooledObjects = new List<GameObject>();

    void Start()
    {
        _bulletFactory = new BulletFactory(this, player);
        current = this;

        for (int i = 0; i < pooledAmount; i++)
        {
           Bullet obj = _bulletFactory.Create();
            //Bullet bala = GameObject.Instantiate(sarasa, player.transform.position, player.transform.rotation);
          
           // obj = Instantiate(pooledObject);
            obj.gameObject.SetActive(false);
            pooledObjects.Add(obj.gameObject);

        }

    }


    public GameObject GetPooledObject(Vector2 pos, Quaternion rot)
    {
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                pooledObjects[i].transform.position = pos;
                pooledObjects[i].transform.rotation = rot;
                return pooledObjects[i];
              

            }
        }
        if (willgrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

}
