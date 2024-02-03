using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirebal : MonoBehaviour
{
    private void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        this.GetComponent<Rigidbody>().AddRelativeForce(enemy.transform.forward * 1250);
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(15);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != ("Enemy") && other.gameObject.tag != ("Player"))
        {
            Destroy(gameObject);
        }
    }
}
