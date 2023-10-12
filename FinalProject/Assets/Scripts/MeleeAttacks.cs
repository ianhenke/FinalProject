using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 1;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] int damageOutput = 34;
    [SerializeField] SpriteRenderer attackIndicator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
            StartCoroutine(AttackIndicatorRoutine());
            Debug.Log("INICATOR ON");
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D hitEnemy in hitEnemies)
        {
            Debug.Log("enemy hit");

            hitEnemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageOutput);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackIndicatorRoutine()
    {
        attackIndicator.enabled = true;
        yield return new WaitForSeconds(.1f);
        attackIndicator.enabled = false;
    }

}
