using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0,50)] [SerializeField] float attackRange = 5, sightRange = 20,timeBetweenAttacks = 3;

    [Range(0,20)] [SerializeField] int power;
    private UnityEngine.AI.NavMeshAgent thisEnemy;
    public Transform playerPos;

    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerPos = FindObjectOfType<PlayerHealth>().transform;    
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(playerPos.position, this.transform.position);

        if(distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange)
        {
            isAttacking = false;
            thisEnemy.isStopped = false;
            StopAllCoroutines();

            ChasePlayer();
        }

        if(distanceFromPlayer <= attackRange && !isAttacking && !PlayerHealth.isDead)
        {
            thisEnemy.isStopped = true;
            StartCoroutine(AttackPlayer());
        }

        if(PlayerHealth.isDead)
        {
            thisEnemy.isStopped = true;
        }
    }
    private void ChasePlayer()
    {
        thisEnemy.SetDestination(playerPos.position);
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        yield return new WaitForSeconds(timeBetweenAttacks);

        // Debug.Log("Hurt Player");
        FindObjectOfType<PlayerHealth>().TakeDamage(power);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
    
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
