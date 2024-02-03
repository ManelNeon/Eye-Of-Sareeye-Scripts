using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCSideQuest : MonoBehaviour
{
    [Header("UI_Identify")]

    [SerializeField] GameObject uiPanel;
    [SerializeField] GameObject uiSideQuest1;
    [SerializeField] GameObject uiSideQuest2;
    [SerializeField] string questName;
    bool questComplete;
    [HideInInspector] public bool questAccepted;
    bool one;
    bool two;

    [Header("1st Dialogue")]

    [SerializeField] string dialogue;
    [SerializeField] string response;

    [Header("2nd Dialogue")]

    [SerializeField] bool twoDialogues;
    [SerializeField] string secondDialogue;
    [SerializeField] string secondResponse;

    [Header("Congratulations Reward")]

    [SerializeField] string congratsDialogue;
    [SerializeField] string congratsResponse;

    [Header("PromptUI")]

    [SerializeField] string promptUI;
    [SerializeField] private PlayerInteract playerInteract;

    bool isTalking = false;

    private void Start()
    {
        one = false;
        two = false;
    }

    private void Update()
    {
        if (playerInteract.GetInteractableSide() != null && isTalking == false)
        {
            PromptUION(playerInteract.GetInteractableSide());
        }
        else if (playerInteract.GetInteractableObject() == null || isTalking)
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

    public void QuestComplete()
    {
        questComplete = true;
        if (one)
        {
            uiSideQuest1.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (two)
        {
            uiSideQuest2.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
    }

    public void PromptUION(NPCSideQuest npcSideQuest)
    {
        if (npcSideQuest.gameObject == this.gameObject)
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameObject.transform.LookAt(playerPosition);
        Time.timeScale = 0;

        if (!questAccepted)
        {
            if (!uiSideQuest1.activeInHierarchy)
            {
                uiSideQuest1.SetActive(true);
                uiSideQuest1.GetComponent<TextMeshProUGUI>().text = questName;
                uiSideQuest1.GetComponent<TextMeshProUGUI>().color = Color.black;
                questAccepted = true;
                one = true;
            }
            else
            {
                uiSideQuest2.SetActive(true);
                uiSideQuest2.GetComponent<TextMeshProUGUI>().text = questName;
                uiSideQuest2.GetComponent<TextMeshProUGUI>().color = Color.black;
                questAccepted = true;
                two = true;
            }
        }

        if (questComplete)
        {
            uiPanel.GetComponent<ButtonControl>().OnNPCText(congratsDialogue, congratsResponse);
            uiPanel.GetComponent<ButtonControl>().finalResponse = true;
            if (one)
            {
                uiSideQuest1.SetActive(false);
            }
            else if (two)
            {
                uiSideQuest2.SetActive(false);
            }
        }
        else if (!twoDialogues)
        {
            uiPanel.GetComponent<ButtonControl>().OnNPCText(dialogue, response);
            uiPanel.GetComponent<ButtonControl>().finalResponse = true;
        }
        else if (twoDialogues)
        {
            uiPanel.GetComponent<ButtonControl>().OnNPCText(dialogue, response);
            uiPanel.GetComponent<ButtonControl>().secondDialogue = secondDialogue;
            uiPanel.GetComponent <ButtonControl>().secondResponse = secondResponse;
            uiPanel.GetComponent<ButtonControl>().finalResponse = false;
        }
    }
}
