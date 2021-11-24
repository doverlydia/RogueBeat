using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missle : ApplyDamage
{
    public Vector2 targetPos;
    public float speed = 10f;
    public float lifetime = 2f;
    private void Start()
    {
        if (FindObjectOfType<EnemyLanes>())
            targetPos = FindObjectOfType<EnemyLanes>().transform.position;
        else
            targetPos = FindObjectOfType<BossFight>().transform.position;
    }
    private void Update()
    {
        if (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (lifetime <= 0 || Vector2.Distance(transform.position, targetPos) <= 0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
