using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("PlayerHealth")]

    [SerializeField] Image healthbarSprite;

    [SerializeField] float maximumHealth;

    float currentHealth;

    [Header("PlayerNumen")]

    [SerializeField] Image numenbarSprite;

    [SerializeField] float maximumNumen;

    float currentNumen;

    [Header("SpellsImages")]

    [SerializeField] Image fireballSlot;
    [SerializeField] Image explosionSlot;
    [SerializeField] Image healSlot;
    [SerializeField] Image poisonSlot;
    [SerializeField] Image pushSlot;

    [Header("SpellsEffects")]

    [SerializeField] Transform shootingPoint;
    [SerializeField] Transform shootingPointExplosion;

    [SerializeField] GameObject fireball;
    [SerializeField] float fireballCost;
    bool fireballUsed;

    [SerializeField] GameObject heal;
    [SerializeField] float healCost;
    [SerializeField] float healQuantity;
    bool healUsed;

    [SerializeField] GameObject poison;
    [SerializeField] float poisonCost;
    bool poisonUsed;

    [SerializeField] GameObject explosion;
    [SerializeField] float explosionCost;
    bool explosionUsed;

    [SerializeField] GameObject ice;
    [SerializeField] float iceCost;
    bool iceUsed;

    [Header("SpellsCheck")]

    [HideInInspector] public bool hasExplosion;
    [HideInInspector] public bool hasPoison;
    [HideInInspector] public bool hasPush;

    bool cast;

    [Header("Level")]

    [SerializeField] GameObject uiChange;

    [HideInInspector] public int level;

    [HideInInspector] public int skillPoint;

    [Header("Checks")]

    [SerializeField] GameObject cutscene;
    [SerializeField] Animator animator;

    void Start()
    {
        explosionSlot.enabled = false;
        healSlot.enabled = false;
        poisonSlot.enabled = false;
        pushSlot.enabled = false;
        currentHealth = maximumHealth;
        currentNumen = maximumNumen;
        skillPoint = 0;
        level = 1;
        UpdateHealthBar();
        UpdateNumenBar();
        ChangeNumenCount();
        StartCoroutine(RegenNumen());
        StartCoroutine(SpellWaitTimeFireball());
        StartCoroutine(SpellWaitTimeHeal());
        StartCoroutine(DeactivateHeal());
        StartCoroutine(SpellWaitTimePoison());
        StartCoroutine(SpellWaitTimeExplosion());
        StartCoroutine(SpellWaitTimeIce());
        StartCoroutine(UseSpells());
    }

    void Update()
    {
        ChangeSpells(); 
        if (SceneManager.GetActiveScene().name == ("Inside") && Time.timeScale == 1 && !cutscene.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CantUseSpells();
            }       
        }
        else if (SceneManager.GetActiveScene().name == ("Outside") && Time.timeScale == 1 && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                cast = true;
            }
            SpellCheck();
        }
    }

    void CantUseSpells()
    {
        uiChange.GetComponent<ButtonControl>().WarningMenuOn();
    }
    IEnumerator UseSpells()
    {
        while (true)
        {
            if (cast)
            {
                if (fireballSlot.enabled == true && !fireballUsed && currentNumen >= fireballCost)
                {
                    animator.SetBool("isCasting", true);
                    yield return new WaitForSecondsRealtime(1);
                    animator.SetBool("isCasting", false);
                    TakeNumen(fireballCost);
                    Instantiate(fireball, shootingPoint.position, Quaternion.identity);
                    fireballUsed = true;
                    cast = false;
                }
                else if (healSlot.enabled == true && !healUsed && currentNumen >= healCost)
                {
                    animator.SetBool("isCasting", true);
                    yield return new WaitForSeconds(1);
                    animator.SetBool("isCasting", false);
                    TakeNumen(healCost);
                    GiveHealth(healQuantity);
                    heal.SetActive(true);
                    healUsed = true;
                    cast = false;
                }
                else if (poisonSlot.enabled == true && !poisonUsed && currentNumen >= poisonCost)
                {
                    animator.SetBool("isCasting", true);
                    yield return new WaitForSeconds(1);
                    animator.SetBool("isCasting", false);
                    TakeNumen(poisonCost);
                    Instantiate(poison, shootingPoint.position, Quaternion.identity);
                    poisonUsed = true;
                    cast = false;
                }
                else if (explosionSlot.enabled == true && !explosionUsed && currentNumen >= explosionCost)
                {
                    animator.SetBool("isCasting", true);
                    yield return new WaitForSeconds(1);
                    animator.SetBool("isCasting", false);
                    TakeNumen(explosionCost);
                    Instantiate(explosion, shootingPointExplosion.position, Quaternion.identity);
                    explosionUsed = true;
                    cast = false;
                }
                else if (pushSlot.enabled == true && !iceUsed && currentNumen >= iceCost)
                {
                    animator.SetBool("isCasting", true);
                    yield return new WaitForSeconds(1);
                    animator.SetBool("isCasting", false);
                    TakeNumen(iceCost);
                    Instantiate(ice, shootingPoint.position, Quaternion.identity);
                    iceUsed = true;
                    cast = false;
                }
                else
                {
                    cast = false;
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }   
    }

    void ChangeSpells()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (hasExplosion)
            {
                if (fireballSlot.enabled == true)
                {
                    fireballSlot.enabled = false;
                    healSlot.enabled = true;
                }
                else if (healSlot.enabled == true)
                {
                    healSlot.enabled = false;
                    explosionSlot.enabled = true;
                }
                else if (explosionSlot.enabled == true)
                {
                    explosionSlot.enabled = false;
                    fireballSlot.enabled = true;
                }
            }
            else if (hasPoison)
            {
                if (fireballSlot.enabled == true)
                {
                    fireballSlot.enabled = false;
                    healSlot.enabled = true;
                }
                else if (healSlot.enabled == true)
                {
                    healSlot.enabled = false;
                    poisonSlot.enabled = true;
                }
                else if (poisonSlot.enabled == true)
                {
                    poisonSlot.enabled = false;
                    fireballSlot.enabled = true;
                }
            }
            else if (hasPush)
            {
                if (fireballSlot.enabled == true)
                {
                    fireballSlot.enabled = false;
                    healSlot.enabled = true;
                }
                else if (healSlot.enabled == true)
                {
                    healSlot.enabled = false;
                    pushSlot.enabled = true;
                }
                else if (pushSlot.enabled == true)
                {
                    pushSlot.enabled = false;
                    fireballSlot.enabled = true;
                }
            }
            else
            {
                if (fireballSlot.enabled == true)
                {
                    fireballSlot.enabled = false;
                    healSlot.enabled = true;
                }
                else if (healSlot.enabled == true)
                {
                    healSlot.enabled = false;
                    fireballSlot.enabled = true;
                }
            }
        }
    }

    void SpellCheck()
    {
        //FireballCheck
        if (currentNumen < fireballCost)
        {
            var tempColor = fireballSlot.color;
            tempColor.a = .43f;
            fireballSlot.color = tempColor;
        }
        else if (currentNumen >= fireballCost && fireballUsed)
        {
            var tempColor = fireballSlot.color;
            tempColor.a = .43f;
            fireballSlot.color = tempColor;
        }
        else
        {
            var tempColor = fireballSlot.color;
            tempColor.a = 1f;
            fireballSlot.color = tempColor;
        }

        //HealCheck
        if (currentNumen < healCost)
        {
            var tempColor = healSlot.color;
            tempColor.a = .43f;
            healSlot.color = tempColor;
        }
        else if (currentNumen >= healCost && healUsed)
        {
            var tempColor = healSlot.color;
            tempColor.a = .43f;
            healSlot.color = tempColor;
        }
        else
        {
            var tempColor = healSlot.color;
            tempColor.a = 1f;
            healSlot.color = tempColor;
        }

        //PoisonCheck
        if (currentNumen < poisonCost)
        {
            var tempColor = poisonSlot.color;
            tempColor.a = .43f;
            poisonSlot.color = tempColor;
        }
        else if (currentNumen >= poisonCost && poisonUsed)
        {
            var tempColor = poisonSlot.color;
            tempColor.a = .43f;
            poisonSlot.color = tempColor;
        }
        else
        {
            var tempColor = poisonSlot.color;
            tempColor.a = 1f;
            poisonSlot.color = tempColor;
        }

        //ExplosionCheck
        if (currentNumen < explosionCost)
        {
            var tempColor = explosionSlot.color;
            tempColor.a = .43f;
            explosionSlot.color = tempColor;
        }
        else if (currentNumen >= explosionCost && explosionUsed)
        {
            var tempColor = explosionSlot.color;
            tempColor.a = .43f;
            explosionSlot.color = tempColor;
        }
        else
        {
            var tempColor = explosionSlot.color;
            tempColor.a = 1f;
            explosionSlot.color = tempColor;
        }

        //IceCheck
        if (currentNumen < iceCost)
        {
            var tempColor = pushSlot.color;
            tempColor.a = .43f;
            pushSlot.color = tempColor;
        }
        else if (currentNumen >= iceCost && iceUsed)
        {
            var tempColor = pushSlot.color;
            tempColor.a = .43f;
            pushSlot.color = tempColor;
        }
        else
        {
            var tempColor = pushSlot.color;
            tempColor.a = 1f;
            pushSlot.color = tempColor;
        }
    }

    public void LevelUp()
    {
        skillPoint++;
        level++;
        uiChange.GetComponent<ButtonControl>().ChangeLevel();
        uiChange.GetComponent<ButtonControl>().ChangeSkillPoint();
    }

    public void ChangeNumenCount()
    {
        uiChange.GetComponent<ButtonControl>().ChangeLevelDisplay();
    }

    public void UpdateHealthBar()
    {
        healthbarSprite.fillAmount = currentHealth / maximumHealth;
    }

    public void UpdateNumenBar()
    {
        numenbarSprite.fillAmount = currentNumen / maximumNumen;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth - damage >= 0)
        {
            currentHealth -= damage;
        }
        else
        {
            uiChange.GetComponent<ButtonControl>().LoseInside();
            currentHealth = 0;
        }
        UpdateHealthBar();
    }

    public void TakeNumen(float numenQ)
    {
        if (currentNumen - numenQ >= 0)
        {
            currentNumen -= numenQ;
        }
        else
        {
            currentNumen = 0;
            Debug.Log("Out of Mana");
        }        
        UpdateNumenBar();
    }

    public void GiveHealth(float heal)
    {
        if (currentHealth + heal <= maximumHealth)
        {
            currentHealth += heal;
        }
        else
        {
            currentHealth = maximumHealth;
            Debug.Log("Full Healthx");
        }
        UpdateHealthBar();
    }

    public void GiveNumen(float numenG)
    {
        if (currentNumen + numenG <= maximumNumen)
        {
            currentNumen += numenG;
        }
        else
        {
            currentNumen = maximumNumen;
            Debug.Log("Full Mana");
        }
        UpdateNumenBar();
    }

    IEnumerator RegenNumen()
    {
        while (true)
        {
            if (currentNumen < maximumNumen)
            {
                currentNumen++;
                UpdateNumenBar();
                yield return new WaitForSeconds(.1f);
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator SpellWaitTimeFireball()
    {
        while (true)
        {
            if (fireballUsed)
            {
                yield return new WaitForSeconds(1f);
                fireballUsed = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator SpellWaitTimeHeal()
    {
        while (true)
        {
            if (healUsed)
            {
                yield return new WaitForSeconds(5f);
                healUsed = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator DeactivateHeal()
    {
        while (true)
        {
            if (heal.activeInHierarchy)
            {
                yield return new WaitForSeconds(3f);
                heal.SetActive(false);
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator SpellWaitTimePoison()
    {
        while (true)
        {
            if (poisonUsed)
            {
                yield return new WaitForSeconds(2.5f);
                poisonUsed = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator SpellWaitTimeExplosion()
    {
        while (true)
        {
            if (explosionUsed)
            {
                yield return new WaitForSeconds(8f);
                explosionUsed = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator SpellWaitTimeIce()
    {
        while (true)
        {
            if (iceUsed)
            {
                yield return new WaitForSeconds(1.5f);
                iceUsed = false;
            }
            else
            {
                yield return null;
            }
        }
    }
}
