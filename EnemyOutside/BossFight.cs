using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    int count;

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        if (count == 5)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.Find("Canvas").GetComponent<ButtonControl>().GameOver();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Spell"))
        {
            count++;
            Destroy(other.gameObject);
        }
    }
}
