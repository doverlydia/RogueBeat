using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerManager player))
        {
            Events.InsideRoom.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerManager player))
        {
            Events.OutsideRoom.Invoke();
        }
    }
}
