using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public float timer;
    public float timertospawn;


    private void Awake()
    {
    }

    private void Start()
    {
       // _objectPooler.GetPooledObject(this.transform.position, this.transform.rotation);
       //  MultipleObjectPooler.Instance.SpawnFromPool("LargeAsteroid", transform.position, transform.rotation);
       // MultipleObjectPooler.Instance.SpawnFromPool("LargeAsteroid", transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timertospawn)
        {
             MultipleObjectPooler.Instance.SpawnFromPool("LargeAsteroid", transform.position, transform.rotation);
           // _objectPooler.GetPooledObject(gameObject.transform.position, gameObject.transform.rotation);

            timer = 0;
        }
    }
}
