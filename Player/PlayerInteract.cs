using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void Update()
    {
        OnDialoguePressed();


    }

    void OnDialoguePressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.gameObject.tag == ("NPC") && collider.gameObject.GetComponent<NPCInteractable>().enabled == true)
                {
                    collider.GetComponent<NPCInteractable>().EnableUIPanel(transform);
                }
                else if (collider.gameObject.tag == ("SideNPC"))
                {
                    collider.GetComponent<NPCSideQuest>().EnableUIPanel(transform);
                }
            }
        }
    }

    public NPCInteractable GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }
        }
        return null;
    }

    public NPCSideQuest GetInteractableSide()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCSideQuest npcSideQuest))
            {
                return npcSideQuest;
            }
        }
        return null;
    }
}
