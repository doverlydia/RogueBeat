using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ApplyDamage
{
    public float speed = 10f;
    public float lifetime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
            transform.position += (Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
