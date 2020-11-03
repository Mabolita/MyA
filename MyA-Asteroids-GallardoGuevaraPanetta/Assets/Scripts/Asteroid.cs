using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public int Size;
    private GameHandler gameHandler;
    public ParticleSystem PS;
    public ModifiedObjectPooler<Asteroid> pool;
    public AsteroidSpawner _asteroidSpawner;//no se si esto lo deberiamos poner aqui

    public Asteroid SetMaxThrust(float newThrust)
    {
        maxThrust = newThrust;
        return this;
    }
    public Asteroid SetMaxTorque(float newTorque)
    {
        maxTorque = newTorque;
        return this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //preguntar donde podriamos conseguir el asteroidspawner, ya que estoy llamando creacion de asteroids dentro de asteroids, esta bien?
        _asteroidSpawner = FindObjectOfType<AsteroidSpawner>();

    }
    private void OnEnable()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
            transform.Rotate(Vector3.right * torque * Time.deltaTime);
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (Size == 3)
            {
                EventManager.Instance.CallEvent("SendScore", 10);
                for (int i = 0; i < 2; i++)
                {
                    var asteroid = _asteroidSpawner._mediumAsteroidPool.Get();
                    asteroid.pool = _asteroidSpawner._mediumAsteroidPool;
                    asteroid.transform.position = transform.position;
                    
                }
               
            }
            else if (Size == 2)
            {
                EventManager.Instance.CallEvent("SendScore", 25);
               
                var asteroid = _asteroidSpawner._smallAsteroidPool.Get();
                asteroid.pool = _asteroidSpawner._smallAsteroidPool;
                asteroid.transform.position = transform.position;

            }
            else
            {
                EventManager.Instance.CallEvent("SendScore", 50);
                           

            }
            
            ParticleSystem obj = Instantiate(PS, transform.position, transform.rotation);
            obj.Play();
            Destroy(obj.gameObject, 2f);
            Die();
        }
    }
    public static void TurnOn(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(true);
    }
    public static void TurnOff(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(false);
    }
    public void Die()
    {
        pool.ReturnToPool(this);
    }



}
