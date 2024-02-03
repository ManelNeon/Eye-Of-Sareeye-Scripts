using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealNPC : MonoBehaviour
{
    [SerializeField] GameObject heal;
    [SerializeField] GameObject npcSide;

    bool healed;

    private void Update()
    {
        if (heal.activeInHierarchy && !healed && npcSide.GetComponent<NPCSideQuest>().questAccepted)
        {
            this.gameObject.transform.Rotate(new Vector3(-90,0,0), Space.Self);
            this.gameObject.GetComponent<NPCInteractable>().enabled = true;
            npcSide.GetComponent<NPCSideQuest>().QuestComplete();
            healed = true;
        }
    }
}
