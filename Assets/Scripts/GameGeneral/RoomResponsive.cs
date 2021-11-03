using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomResponsive : MonoBehaviour
{
    void Awake()
    {
        Events.InsideRoom.UpsertListener(OnRoomEnter);
        Events.OutsideRoom.UpsertListener(OnRoomExit);
    }
    public virtual void OnRoomEnter()
    {
    }
    public virtual void OnRoomExit()
    {
    }
    void OnDestroy()
    {
        Events.InsideRoom.RemoveListener(OnRoomEnter);
        Events.OutsideRoom.RemoveListener(OnRoomEnter);
    }
}
