using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missle : ApplyDamage
{
    [HideInInspector]public Vector3 targetPos;
    public float speed = 10f;
    public float lifetime = 2f;
    private void Update()
    {
        if (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (lifetime <= 0 || Vector3.Distance(transform.position, targetPos)<=0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
