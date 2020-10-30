using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Vector2 dir;
    private Player pl;
    public float projectilespeed;

    


    protected virtual void OnEnable()
    {
        Invoke("Disable", 2.5f);
        pl = FindObjectOfType<Player>();
        dir = pl.dir;
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(dir * projectilespeed);
    }


    protected virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable()
    {
        CancelInvoke();
    }

    protected abstract void Explode();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }


}





