using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 15f;
    public float attackCooldown = 1.2f;
    public float attackRange = 2f;

    float lastAttack = -999f;

    public void TryAttack(GameObject target)
    {
        if (Time.time - lastAttack < attackCooldown) return;

        if (target == null) return;

        float d = Vector3.Distance(transform.position, target.transform.position);
        if (d <= attackRange)
        {
            var dmg = target.GetComponent<DamageReceiver>();
            if (dmg != null) dmg.ApplyDamage(damage);
            lastAttack = Time.time;
        }
    }
}
