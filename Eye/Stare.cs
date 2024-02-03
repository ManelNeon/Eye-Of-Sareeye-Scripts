using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stare : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Update()
    {
        this.gameObject.transform.LookAt(player.transform.position);
    }
}
