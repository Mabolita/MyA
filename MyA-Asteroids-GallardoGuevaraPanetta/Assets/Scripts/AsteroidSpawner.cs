using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public float timer;
    public float timertospawn;
    public GameObject[] _spawnpoints;
    //preguntar en tutoria si esta bien hecho
    public ModifiedObjectPooler<Asteroid> _largeAsteroidPool;
    public ModifiedObjectPooler<Asteroid> _mediumAsteroidPool;
    public ModifiedObjectPooler<Asteroid> _smallAsteroidPool;

    private void Start()
    {
        var largeFactory = new LargeAsteroidFactory();
        _largeAsteroidPool = new ModifiedObjectPooler<Asteroid>(largeFactory.Create, Asteroid.TurnOn, Asteroid.TurnOff, 2);

        var smallFactory = new SmallAsteroidFactory();
        _smallAsteroidPool = new ModifiedObjectPooler<Asteroid>(smallFactory.Create, Asteroid.TurnOn, Asteroid.TurnOff, 2);


        var mediumfactory = new MediumAsteroidFactory();
        _mediumAsteroidPool = new ModifiedObjectPooler<Asteroid>(mediumfactory.Create, Asteroid.TurnOn, Asteroid.TurnOff, 5);
        for (int i = 0; i < _spawnpoints.Length; i++)
        {
            var asteroid = _largeAsteroidPool.Get();
            asteroid.pool = _largeAsteroidPool;
            asteroid.transform.position = _spawnpoints[i].transform.position;

        }

    }

    void Update()
    {
        //hay que ver como mejorar, a ver si se puede hacer con un for, puede ser?
        timer += Time.deltaTime;
        if(timer >= timertospawn)
        {
            var rr = Random.Range(0, 4);
            var asteroid = _largeAsteroidPool.Get();
            asteroid.pool = _largeAsteroidPool;
            if(rr == 0)
            {
                asteroid.transform.position = _spawnpoints[0].transform.position;
            }
            else if(rr == 1)
            {
                asteroid.transform.position = _spawnpoints[1].transform.position;
            }
            else if(rr == 2)
            {
                asteroid.transform.position = _spawnpoints[2].transform.position;
            }
            else
            {
                asteroid.transform.position = _spawnpoints[3].transform.position;
            }
           
            timer = 0;
        }
    }
}
