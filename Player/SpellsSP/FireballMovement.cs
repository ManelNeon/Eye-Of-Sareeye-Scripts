using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] GameObject leaveBehind;
    private void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("Camera");
        this.GetComponent<Rigidbody>().AddRelativeForce(camera.transform.forward * 1500);
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != ("Player") && other.gameObject.tag != ("Numen"))
        {
            Destroy(gameObject);
            Instantiate(leaveBehind, transform.position, Quaternion.identity);
        }
        if (other.gameObject.tag == ("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(30);
            Instantiate(leaveBehind, transform.position, Quaternion.identity);
        }
    }
}
