


using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
    }
}
