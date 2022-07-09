using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Vector2 dir;
    public float projectilespeed;
    public ModifiedObjectPooler<Bullet> pool;
    public ModifiedObjectPooler<ExplosiveBullet> _explosivepool;
    public float _spawnTime;
    public float timeToDestroy;
    public Player player;

    public Bullet SetProjectileSpeed(float newspeed)
    {
        projectilespeed = newspeed;
        return this;
    }
    public Bullet SetSpawnTime(float newspawntime)
    {
        projectilespeed = newspawntime;
        return this;
    }

    protected virtual void OnEnable()
    {
        _spawnTime = Time.time;
        player = FindObjectOfType<Player>();
        dir = player.dir;
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(dir * projectilespeed);
    }

    protected virtual void LateUpdate()
    {
        if (_spawnTime + timeToDestroy <= Time.time)
        {
            Explode();
        }
    }

    protected virtual void Explode()
    {
       pool.ReturnToPool(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
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





