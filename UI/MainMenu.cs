using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject controls;

    private void Start()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void OnPlayPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inside");
    }

    public void OnOptionsPress()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void OnExitPress()
    {
        Application.Quit();
    }
}
