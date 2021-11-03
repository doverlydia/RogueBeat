using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public enum EnemyLane
{
    First,
    Middle,
    Bottom
}

public enum EnemyPoint
{
    Left,
    Middle,
    Right
}

public enum EnemyMovement
{
    Stationery,
    FrogJumping,
    TwoSpots
}

public enum EnemyType
{
    Regular,
    Boss
}
public class EnemyLanes : DungeonObject
{
    public float speed = 10;
    public EnemyLane enemyLane;
    public EnemyPoint enemyPoint;
    public EnemyPoint EnemyPoint
    {
        get => enemyPoint;
        set => enemyPoint = (int)value >= Enum.GetValues(typeof(EnemyPoint)).Length ? 0 : value;
    }
    public EnemyMovement enemyMovement;
    public EnemyType enemyType;
    public ProjectileType projectileType;
    public int shootEveryXBeats;
    private int beatCounter;

    [SerializeField] private GameObject pongProjectile;
    [SerializeField] private GameObject squareProjectile;
    [SerializeField] private GameObject normalProjectile;

    private Vector3 Target
    {
        get
        {
            float x = 0;
            float y = 0;
            x = EnemyPoint switch
            {
                EnemyPoint.Left => 0.2f,
                EnemyPoint.Middle => 0.5f,
                EnemyPoint.Right => 0.8f,
                _ => x
            };
            y = enemyLane switch
            {
                EnemyLane.First => 0.9f,
                EnemyLane.Middle => 0.8f,
                EnemyLane.Bottom => 0.7f,
                _ => y
            };

            return new Vector3(x, y, 0);
        }
    }
    public override void OnBeat()
    {
        Movement();
        if (beatCounter >= shootEveryXBeats)
        {
            Attack();
            beatCounter = 0;
        }

        beatCounter+=1;
    }

    private void Update()
    {
        var tar = Camera.main.ViewportToWorldPoint(Target);
        tar.z = 0;
        transform.position = Vector3.Lerp(transform.position, tar, speed*Time.deltaTime);
    }

    protected void Movement()
    {
        switch (enemyMovement)
        {
            case EnemyMovement.Stationery:
                break;
            case EnemyMovement.FrogJumping:
                EnemyPoint++;
                break;
            case EnemyMovement.TwoSpots:
                EnemyPoint += Enum.GetValues(typeof(EnemyPoint)).Length - 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    protected void Attack()
    {
        switch (projectileType)
        {
            case ProjectileType.Pong:
                Instantiate(pongProjectile, transform.position, transform.rotation);
                break;
            case ProjectileType.Squares:
                Instantiate(squareProjectile, transform.position, transform.rotation);
                break;
            case ProjectileType.Normal:
                Instantiate(normalProjectile, transform.position, transform.rotation);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override void OnBossFight()
    {
        if (enemyType == EnemyType.Regular)
            Destroy(this.gameObject);
    }
}
