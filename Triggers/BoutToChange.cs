using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutToChange : MonoBehaviour
{
    [SerializeField] GameObject guards;
    [SerializeField] GameObject doors;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject toolsMenu;
    [SerializeField] GameObject questMenu;

    bool once;

    private void Start()
    {
        once = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && once == false)
        {
            GameObject.FindGameObjectWithTag("Static").GetComponent<Statics>().PauseMusicInside();
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = new Vector3(22.6f, other.transform.position.y, 92.4f);
            cutscene.SetActive(true);
            questMenu.SetActive(false);
            toolsMenu.SetActive(false);
            once = true;
            guards.SetActive(true);
            doors.SetActive(false);
        }
    }
}
