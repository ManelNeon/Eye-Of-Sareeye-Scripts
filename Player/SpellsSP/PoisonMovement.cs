using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMovement : MonoBehaviour
{
    [SerializeField] GameObject leaveBehind;
    private void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("Camera");
        this.GetComponent<Rigidbody>().AddRelativeForce(camera.transform.forward * 500);
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag != ("Player") && other.gameObject.tag != ("Numen") && other.gameObject.tag != ("Trigger"))
        {
            Destroy(gameObject);
            Instantiate(leaveBehind, transform.position, Quaternion.identity);
        }
        if (other.gameObject.tag == ("Enemy"))
        {
            other.GetComponent<EnemyController>().PoisonedDamage(12);
            Instantiate(leaveBehind, transform.position, Quaternion.identity);  
        }
    }
}
