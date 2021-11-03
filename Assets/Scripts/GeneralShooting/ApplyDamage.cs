using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public float damage = 1;
    public float radius = 1;
    public LayerMask whatIdamage;
    [SerializeField] private bool notProjectile;
    private void FixedUpdate()
    {
        CheckHit();
    }

    private void CheckHit()
    {
        var hit = Physics2D.OverlapCircle(transform.position, radius, whatIdamage);
        if (hit == null) return;
        hit.TryGetComponent(out Damagable damagable);
        hit.TryGetComponent(out Defendable defendable);
        if (damagable != null && (defendable == null || (!defendable.IsDefending)))
        {
            damagable.CurrentValue -= damage;
            if (!notProjectile)
            {
                if (damagable.gameObject.CompareTag("Player"))
                {
                    ScreenShakeController.instance.StartShake(0.5f, 0.2f);
                }
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (damagable != null && defendable.IsDefending)
            {
                if (!notProjectile)
                    Destroy(this.gameObject);
            }
        }
    }
}
