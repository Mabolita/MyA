using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroidFactory : IFactory<Asteroid>
{
    private readonly ObjectPooler _objectPooler;
    public AsteroidSpawner spawner;

    public Asteroid Create()
    {
        GameObject myObject = GameObject.Instantiate(_objectPooler.pooledObject, _objectPooler.transform.position, _objectPooler.transform.rotation);
        Asteroid asteroid = myObject.GetComponent<Asteroid>();
        return asteroid;
    }

    public MediumAsteroidFactory(ObjectPooler pooler, AsteroidSpawner _spawner)
    {
        _objectPooler = pooler;
        _spawner = spawner;
    }
}
