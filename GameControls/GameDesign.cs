using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDesign : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject toolMenu;
    [SerializeField] GameObject statsMenu;
    [SerializeField] GameObject loreMenu;
    [SerializeField] GameObject questMenu;
    [SerializeField] GameObject warningMenu;
    [SerializeField] GameObject loseInsideMenu;
    [SerializeField] GameObject tutorialNumen;
    [SerializeField] GameObject runAwayMenu;
    [SerializeField] GameObject loreFirst;
    [SerializeField] GameObject interactionMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject mainQuest;

    [SerializeField] GameObject player;
    [SerializeField] GameObject cutscene;
    [SerializeField] Animator playerModel;
    [SerializeField] GameObject controls;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !warningMenu.activeInHierarchy && !loseInsideMenu.activeInHierarchy && !gameOverMenu.activeInHierarchy && !tutorialNumen.activeInHierarchy && !runAwayMenu.activeInHierarchy && !loreFirst.activeInHierarchy && !interactionMenu.activeInHierarchy && !cutscene.activeInHierarchy && !controls.activeInHierarchy)
        {
            if (!pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                toolMenu.SetActive(false);
                pauseMenu.SetActive(true);
                loreMenu.SetActive(false);
                statsMenu.SetActive(true);
                questMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                toolMenu.SetActive(true);
                questMenu.SetActive(true);
            }
        }
    }


    public void AfterCutscene()
    {
        GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().PlayMusicInside();
        GameObject.Find("Canvas").GetComponent<ButtonControl>().RunAwayMenuOn();
        playerModel.SetBool("isDaFast", false);
        playerModel.SetBool("isCrouching", true);
        player.GetComponent<CharacterController>().enabled = true;
        questMenu.SetActive(true);
        cutscene.SetActive(false);
        toolMenu.SetActive(true);
        mainQuest.SetActive(true);
    }
}
