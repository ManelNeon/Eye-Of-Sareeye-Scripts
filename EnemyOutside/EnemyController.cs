using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Health")]

    float currentHealth;
    [SerializeField] float maximumHealth;

    bool poisoned = false;
    int count = 0;

    void Start()
    {
        currentHealth = maximumHealth;
        StartCoroutine(PoisonDamage());
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else if (currentHealth - damage <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SlowAndDamage(int damage)
    {
        bool slowed = false;
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else if (currentHealth - damage <= 0)
        {
            Destroy(this.gameObject);
        }
        if (!slowed)
        {
            float speed = this.gameObject.GetComponent<NavMeshAgent>().speed;

            this.gameObject.GetComponent<NavMeshAgent>().speed -= speed/2;

            slowed = true;
        }
    }

    public void PoisonedDamage(int damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else if (currentHealth - damage <= 0)
        {
            Destroy(this.gameObject);
        }
        poisoned = true;
    }

    IEnumerator PoisonDamage()
    {
        while (true)
        {
            if (poisoned)
            {
                if (count < 9)
                {
                    TakeDamage(5);
                    count++;
                    yield return new WaitForSeconds(2f);
                }
                else
                {
                    count = 0;
                    TakeDamage(5);
                    poisoned = false;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
