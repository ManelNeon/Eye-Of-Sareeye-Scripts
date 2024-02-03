using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesSide : MonoBehaviour
{
    [SerializeField] GameObject enemies;

    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;

    [SerializeField] GameObject uiSideQuest1;
    [SerializeField] GameObject uiSideQuest2;
    [SerializeField] GameObject uiSideQuest3;

    bool one;
    bool two;
    bool three;

    bool activaded;

    private void Update()
    {
        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null)
        {
            if (one)
            {
                uiSideQuest1.SetActive(false);
            }
            if (two)
            {
                uiSideQuest2.SetActive(false);
            }
            if (three)
            {
                uiSideQuest3.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (!uiSideQuest1.activeInHierarchy && !activaded)
            {
                uiSideQuest1.SetActive(true);
                uiSideQuest1.GetComponent<TextMeshProUGUI>().text = ("- Defeat the sorcerers");
                one = true;
                activaded = true;
            }
            else if (!uiSideQuest2.activeInHierarchy && !activaded)
            {
                uiSideQuest2.SetActive(true);
                uiSideQuest2.GetComponent<TextMeshProUGUI>().text = ("- Defeat the sorcerers");
                two = true;
                activaded = true;
            }
            else if (!uiSideQuest3.activeInHierarchy && !activaded)
            {
                uiSideQuest3.SetActive(true);
                uiSideQuest3.GetComponent<TextMeshProUGUI>().text = ("- Defeat the sorcerers");
                three = true;
                activaded = true;
            }

            enemies.SetActive(true);
           
        }
        
    }
}
