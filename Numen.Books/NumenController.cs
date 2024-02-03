using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingNumen : MonoBehaviour
{
    [SerializeField] Transform player;
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player, Vector3.left);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount++;
            other.GetComponent<PlayerStats>().ChangeNumenCount();
            if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount == 6)
            {
                other.GetComponent<PlayerStats>().LevelUp();
            }
            Destroy(gameObject);
        }
    }
}
