using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoLanes : DungeonObject
{
    public float speed = 10;
    public EnemyPoint enemyPoint;
    public EnemyPoint EnemyPoint
    {
        get => enemyPoint;
        set => enemyPoint = (int)value >= Enum.GetValues(typeof(EnemyPoint)).Length ? 0 : value;
    }
    public EnemyMovement enemyMovement;
    public EnemyType enemyType;
    public ProjectileType projectileType;

    [SerializeField] private GameObject pongProjectile;
    [SerializeField] private GameObject squareProjectile;
    [SerializeField] private GameObject normalProjectile;

    private PlayerManager player;

    private float TargetX
    {
        get
        {
            float x = 0;
            x = EnemyPoint switch
            {
                EnemyPoint.Left => -2,
                EnemyPoint.Middle => 0,
                EnemyPoint.Right => 2,
                _ => x
            };

            return x;
        }
    }
    private float TargetY;

    private Vector3 Target => new Vector3(TargetX, TargetY, 0);

    private void Start()
    {
        TargetY = transform.localPosition.y;
        player = FindObjectOfType<PlayerManager>();
    }
    public override void OnBeat()
    {
        Movement();
        if (Vector2.Distance(transform.position, player.gameObject.transform.position) <= 6)
            Attack();
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Target, speed * Time.deltaTime);
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
