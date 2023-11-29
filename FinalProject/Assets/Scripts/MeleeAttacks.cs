using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 1;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] int damageOutput = 34;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] AudioSource kickAudio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !PauseMenuManager.gameIsPaused)
        {
            Attack();
            kickAudio.Play();
            StartCoroutine(ChangeAnimationAfterDelay("Kicking", 0.3f)); // Delay the animation change
        }
    }

    private IEnumerator ChangeAnimationAfterDelay(string animationName, float delay)
    {
        animationStateChanger.ChangeAnimationState(animationName);
        animationStateChanger.canChangeAnimation = false;
        yield return new WaitForSeconds(delay); // Wait for the specified duration
        animationStateChanger.canChangeAnimation = true;
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
}
