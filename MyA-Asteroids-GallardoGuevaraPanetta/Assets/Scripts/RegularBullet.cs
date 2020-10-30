using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
 

    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Disable()
    {
        base.Disable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
    protected override void Explode()
    {
        this.gameObject.SetActive(false);
    }

}

