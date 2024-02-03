using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;

    [Header("1st Dialogue")]

    [SerializeField] string dialogue;
    [SerializeField] string response;

    [Header("2nd Dialogue")]

    [SerializeField] bool twoDialogues;
    [SerializeField] string secondDialogue;
    [SerializeField] string secondResponse;

    [Header("PromptUI")]

    [SerializeField] string promptUI;
    [SerializeField] private PlayerInteract playerInteract;

    bool isTalking = false;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null && isTalking == false)
        {
            PromptUION(playerInteract.GetInteractableObject());
        }
        else if (playerInteract.GetInteractableSide() == null || isTalking)
        {
            PromptUIOff();
        }

        if (!uiPanel.GetComponent<ButtonControl>().interactionMenu.activeInHierarchy)
        {
            isTalking = false;
        }
        else
        {
            isTalking = true;
        }
    }
    public void PromptUION(NPCInteractable npcInteractable)
    {
        if (npcInteractable.gameObject == this.gameObject)
        {
            uiPanel.GetComponent<ButtonControl>().PromptActivate(promptUI);
        }
    }

    public void PromptUIOff()
    {
        uiPanel.GetComponent<ButtonControl>().PromptDeactivate();
    }

    public void EnableUIPanel(Transform playerPosition)
    {
        if (this.gameObject.name == ("NPC- Marmac"))
        {
            uiPanel.GetComponent<ButtonControl>().boss = true;
            GameObject.Find("Main Quest").SetActive(false);
            GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().ChangeOutsideMusic();
        }
        else
        {
            gameObject.transform.LookAt(playerPosition);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        if (!twoDialogues)
        {
            uiPanel.GetComponent<ButtonControl>().OnNPCText(dialogue, response);
            uiPanel.GetComponent<ButtonControl>().finalResponse = true;
        }
        if (twoDialogues)
        {
            uiPanel.GetComponent<ButtonControl>().OnNPCText(dialogue, response);
            uiPanel.GetComponent<ButtonControl>().secondDialogue = secondDialogue;
            uiPanel.GetComponent <ButtonControl>().secondResponse = secondResponse;
            uiPanel.GetComponent<ButtonControl>().finalResponse = false;
        }
    }
}
