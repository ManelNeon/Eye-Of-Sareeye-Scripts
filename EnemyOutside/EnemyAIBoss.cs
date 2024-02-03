using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBoss : MonoBehaviour
{
    Transform player;

    [SerializeField] float timeBetweenAttacks;

    bool alreadyAttacked;

    [SerializeField] Transform shootingPoint;

    [SerializeField] GameObject fireball;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        transform.LookAt(player, Vector3.up);

        if (!alreadyAttacked)
        {
            Instantiate(fireball, shootingPoint.position, Quaternion.identity);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

