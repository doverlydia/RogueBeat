using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

public enum ProjectileType
{
    Normal,
    Pong,
    Squares
}
public class Projectile : DungeonObject
{
    private Vector3 targetPos;
    private float dir = 1;
    private float targetY;

    public ProjectileType type;

    public float speed = 10f;
    public float lifetime = 2f;

    private Vector3 rightEdge;
    private Vector3 leftEdge;

    private Vector3 startingPos;

    [SerializeField] private float addedVal = 3;

    private bool addedToY1 = false;
    private bool addedToX = false;
    private bool addedToY2 = false;
    private bool removedFromX = false;

    private void Start()
    {
        startingPos = transform.position;
        targetPos = startingPos;
        rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right);
        leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero);

        if (type != ProjectileType.Pong) return;
        targetY = transform.position.y - addedVal;
    }
    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (!(lifetime >= 0)) return;
        switch (type)
        {
            case ProjectileType.Normal:

                transform.position += (Vector3)Vector2.down * speed * Time.deltaTime;

                break;

            case ProjectileType.Pong:

                targetPos = dir == 0 ? rightEdge : leftEdge;
                targetPos.y = targetY;
                targetPos.z = 0;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, targetPos) <= 0.5f)
                {
                    dir = dir == 0 ? dir = 1 : dir = 0;
                    targetY -= addedVal;
                }

                break;

            case ProjectileType.Squares:
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                if (!(Vector2.Distance(transform.position, targetPos) <= 0.5f)) return;
                switch (addedToY1)
                {
                    case false when !addedToX && !addedToY2 && !removedFromX:
                        targetPos.y -= addedVal;
                        addedToY1 = true;
                        break;
                    case true when !addedToX && !addedToY2 && !removedFromX:
                        targetPos.x += addedVal;
                        addedToX = true;
                        break;
                    case true when addedToX && !addedToY2 && !removedFromX:
                        targetPos.y -= addedVal;
                        addedToY2 = true;
                        break;
                    case true when addedToX && addedToY2 && !removedFromX:
                        targetPos.x -= addedVal;
                        removedFromX = true;
                        break;
                    case true when addedToX && addedToY2 && removedFromX:
                        addedToY1 = false;
                        addedToX = false;
                        addedToY2 = false;
                        removedFromX = false;
                        break;
                }

                break;

        }
    }

    public override void OnBeat()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
