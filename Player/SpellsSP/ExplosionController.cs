using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    bool didDamage;
    // Update is called once per frame
    void Update()
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.gameObject.tag == ("Enemy"))
            {
                didDamage = false;
                if (!didDamage)
                {
                    collider.GetComponent<EnemyController>().TakeDamage(75);
                    didDamage = true;
                }
            }
        }
        Destroy(gameObject, 3f);
    }
}
