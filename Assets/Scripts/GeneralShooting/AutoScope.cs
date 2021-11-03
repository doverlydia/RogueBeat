using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutoScope : MonoBehaviour
{
    [SerializeField] float radius;
    Collider2D[] targets = new Collider2D[10];
    [SerializeField] LayerMask targetLayerMask;

    public Vector2 GetClosestTarget() // returns vector 0 if there are no targets in radius
    {
        int t = Physics2D.OverlapCircleNonAlloc(transform.position, radius, targets, targetLayerMask);
        if (t > 0)
        {
            Vector3 closestTarget = targets[0].transform.position;
            float minDis = Vector2.Distance(transform.position, closestTarget);
            for (int i = 0; i < t; i++)
            {
                Collider2D target = targets[i];
                if (Vector2.Distance(transform.position, target.transform.position) < minDis)
                {
                    closestTarget = target.transform.position;
                    minDis = Vector2.Distance(transform.position, target.transform.position);
                }
            }
            return closestTarget;
        }
        return Vector2.zero;
    }
}
