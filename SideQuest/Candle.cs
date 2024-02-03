using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] GameObject fire2;
    [SerializeField] GameObject fire3;
    [SerializeField] GameObject fire4;

    [SerializeField] GameObject npc;
    bool flameON;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Fireball(Clone)") && !flameON)
        {
            fire.SetActive(true);
            if (fire.activeInHierarchy && fire2.activeInHierarchy && fire3.activeInHierarchy && fire4.activeInHierarchy)
            {
                npc.GetComponent<NPCSideQuest>().QuestComplete();
            }
            flameON = true;
        }
    }
}
