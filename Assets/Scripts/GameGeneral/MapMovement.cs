using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public bool StopMoving = false;
    private void Start()
    {
        Events.BossFight.UpsertListener(BossFight);
        Events.InsideRoom.UpsertListener(RoomEnter);
        Events.OutsideRoom.UpsertListener(RoomExit);
    }
    private void Update()
    {
        if (!StopMoving)
            transform.position += (Vector3.down * (speed * Time.deltaTime));
    }

    private void RoomEnter()
    {
        StopMoving = true;
    }
    private void RoomExit()
    {
        StopMoving = false;
    }
    private void BossFight()
    {
        StopMoving = true;
    }
}
