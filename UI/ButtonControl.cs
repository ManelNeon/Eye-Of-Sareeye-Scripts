using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [Header("UI_Identify")]

    [SerializeField] GameObject toolMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject statsMenu;
    [SerializeField] GameObject loreMenu;
    [SerializeField] GameObject questMenu;
    [SerializeField] GameObject warningMenu;
    [SerializeField] GameObject loseMenuInside;
    [SerializeField] GameObject tutorialNumen;
    [SerializeField] GameObject runAwayMenu;
    [SerializeField] GameObject loreFirst;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject mainQuest;

    [SerializeField] GameObject bossFightActivate;


    [HideInInspector] public bool boss;

    [Header("NPCStuff")]

    [SerializeField] public GameObject interactionMenu;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] TextMeshProUGUI interactionResponseText;
    [SerializeField] GameObject interactionResponseButton;
    [SerializeField] GameObject promptUi;
    [SerializeField] TextMeshProUGUI promptUIText;  

    [HideInInspector] public string secondDialogue;
    [HideInInspector] public string secondResponse;

    [HideInInspector] public bool finalResponse;

    [Header("Stats")]

    [SerializeField] TextMeshProUGUI levelNumber;
    [SerializeField] TextMeshProUGUI skillNumber;
    [SerializeField] Image p1;
    [SerializeField] Image p2;
    [SerializeField] Image p3;
    [SerializeField] Image p4;
    [SerializeField] Image p5;
    [SerializeField] Image p6;

    [Header("BooksButtons")]

    [SerializeField] GameObject beastiaryButton;
    [SerializeField] GameObject maidButton;
    [SerializeField] GameObject marmacEntityButton;
    [SerializeField] GameObject marmacBioButton;
    [SerializeField] GameObject mapButton;

    [Header("Books")]

    [SerializeField] GameObject beastiary;
    [SerializeField] GameObject maid;
    [SerializeField] GameObject marmacEntity;
    [SerializeField] GameObject marmacBio;
    [SerializeField] GameObject map;

    [Header("Spells")]

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject push;
    [SerializeField] GameObject poison;

    [Header("SpellsDescription")]

    [SerializeField] GameObject poisonDescription;
    [SerializeField] GameObject explosionDescription;
    [SerializeField] GameObject pushDescription;

    [Header("Player")]

    [SerializeField] GameObject player;

    private void Start()
    {
        boss = false;
    }
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        toolMenu.SetActive(true);
        questMenu.SetActive(true);
    }
    public void OnControlsPress()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void OnBackPress()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OnMainMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnStatsPress()
    {
        loreMenu.SetActive(false);
        statsMenu.SetActive(true);
    }

    public void OnLorePress()
    {
        beastiaryButton.SetActive(false);
        maidButton.SetActive(false);
        marmacEntityButton.SetActive(false);
        marmacBioButton.SetActive(false);
        mapButton.SetActive(false);
        statsMenu.SetActive(false);
        loreMenu.SetActive(true);
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasBeastiary)
        {
            beastiaryButton.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMaid)
        {
            maidButton.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMarmacEntity)
        {
            marmacEntityButton.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMarmacBio)
        {
            marmacBioButton.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().hasMap)
        {
            mapButton.SetActive(true);
        }
        maid.SetActive(false);
        marmacEntity.SetActive(false);
        marmacBio.SetActive(false);
        map.SetActive(false);
        beastiary.SetActive(false);
    }

    public void OnBeastiaryPress()
    {
        maid.SetActive(false);
        marmacEntity.SetActive(false);
        marmacBio.SetActive(false);
        map.SetActive(false);
        beastiary.SetActive(true);
    }

    public void OnMaidPress()
    {
        marmacEntity.SetActive(false);
        marmacBio.SetActive(false);
        map.SetActive(false);
        beastiary.SetActive(false);
        maid.SetActive(true);
    }

    public void OnMarmacEntityPress()
    {
        maid.SetActive(false);
        marmacBio.SetActive(false);
        map.SetActive(false);
        beastiary.SetActive(false);
        marmacEntity.SetActive(true);
    }

    public void OnMarmacBioPress()
    {
        maid.SetActive(false);
        marmacEntity.SetActive(false);
        map.SetActive(false);
        beastiary.SetActive(false);
        marmacBio.SetActive(true);
    }

    public void OnMapPress()
    {
        maid.SetActive(false);
        marmacEntity.SetActive(false);
        marmacBio.SetActive(false);
        beastiary.SetActive(false);
        map.SetActive(true);
    }

    public void OnExplosionPress()
    {
        if (player.GetComponent<PlayerStats>().skillPoint == 1)
        {
            player.GetComponent<PlayerStats>().skillPoint = 0;
            ChangeSkillPoint();
            player.GetComponent<PlayerStats>().hasExplosion = true;
            explosion.GetComponent<Image>().color = new Color(1f,.89f,.35f,1f);
        }
    }

    public void OnPoisonPress()
    {
        if (player.GetComponent<PlayerStats>().skillPoint == 1)
        {
            player.GetComponent<PlayerStats>().skillPoint = 0;
            ChangeSkillPoint();
            player.GetComponent<PlayerStats>().hasPoison = true;
            poison.GetComponent<Image>().color = new Color(1f, .89f, .35f, 1f);
        }
    }

    public void OnPushPress()
    {
        if (player.GetComponent<PlayerStats>().skillPoint == 1)
        {
            player.GetComponent<PlayerStats>().skillPoint = 0;
            ChangeSkillPoint();
            player.GetComponent<PlayerStats>().hasPush = true;
            push.GetComponent<Image>().color = new Color(1f, .89f, .35f, 1f);
        }
    }

    public void ChangeLevel()
    {
        levelNumber.text = ("2");
    }

    public void ChangeSkillPoint()
    {
        if (player.GetComponent<PlayerStats>().skillPoint == 1)
        {
            skillNumber.text = ("1");
        }
        else
        {
            skillNumber.text = ("0");
        }
    }

    public void ChangeLevelDisplay()
    {
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount == 1 && !GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().no)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().no = true;
            tutorialNumen.SetActive(true);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount >= 1)
        {
            p1.color = new Color(0f,.74f,1f,1f);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount >= 2)
        {
            p2.color = new Color(0f, .74f, 1f, 1f);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount >= 3)
        {
            p3.color = new Color(0f, .74f, 1f, 1f);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount >= 4)
        {
            p4.color = new Color(0f, .74f, 1f, 1f);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount >= 5)
        {
            p5.color = new Color(0f, .74f, 1f, 1f);
        }
        if (GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().numenCount == 6)
        {
            p1.color = new Color(1f, 1f, 1f, 1f);
            p2.color = new Color(1f, 1f, 1f, 1f);
            p3.color = new Color(1f, 1f, 1f, 1f);
            p4.color = new Color(1f, 1f, 1f, 1f);
            p5.color = new Color(1f, 1f, 1f, 1f);
            p6.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnMouseOverPoison()
    {
        poisonDescription.SetActive(true);
    }

    public void OnMouseQuitPoison()
    {    
        poisonDescription.SetActive(false);
    }
    
    public void OnMouseOverExplosion()
    {
        explosionDescription.SetActive(true);
    }

    public void OnMouseQuitExplosion()
    {
        explosionDescription.SetActive(false);
    }
    
    public void OnMouseOverPush()
    {
        pushDescription.SetActive(true);
    }

    public void OnMouseQuitPush()
    {
        pushDescription.SetActive(false);
    }

    public void OnNPCText(string text, string response)
    {
        interactionMenu.SetActive(true);
        interactionText.text = text;
        interactionResponseText.text = response;
    }

    public void OnResponseClick()
    {
        if (finalResponse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            interactionMenu.SetActive(false);
            Time.timeScale = 1;
            if (boss)
            {
                mainQuest.SetActive(true);
                mainQuest.GetComponent<TextMeshProUGUI>().text = ("- Defeat Marmac");
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(-156.67f, player.transform.position.y , 5.73f);
                player.GetComponent<CharacterController>().enabled = true; 
                GameObject.Find("NPC- Marmac").SetActive(false);
                bossFightActivate.SetActive(true);
                player.transform.Translate(0, 0, 10 * Time.deltaTime);
            }
        }
        else
        {
            interactionText.text = secondDialogue;
            interactionResponseText.text = secondResponse;
            finalResponse = true;  
        }
    }

    public void PromptActivate(string promptText)
    {
        Debug.Log("EE");
        promptUIText.text = promptText;
        promptUi.SetActive(true);
    }

    public void PromptDeactivate()
    {
        promptUi.SetActive(false);
    }

    public void WarningMenuOn()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        warningMenu.SetActive(true);
    }

    public void GotItWarning()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        warningMenu.SetActive(false);
    }

    public void GotItNumen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        tutorialNumen.SetActive(false);
    }

    public void GotItRunAway()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        runAwayMenu.SetActive(false);
    }

    public void RunAwayMenuOn()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        runAwayMenu.SetActive(true);
    }

    public void LoreFirstOn()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loreFirst.SetActive(true);
    }

    public void GotItLoreFirst()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        loreFirst.SetActive(false);
    }

    public void LoseInside()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        questMenu.SetActive(false);
        toolMenu.SetActive(false);
        loseMenuInside.SetActive(true);
    }

    public void GameOver()
    {
        toolMenu.SetActive(false);
        questMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }
}
