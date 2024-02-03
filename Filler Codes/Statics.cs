using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statics : MonoBehaviour
{    
    [HideInInspector] public int numenCount = 0;
    [HideInInspector] public int bookCount = 0;

    [HideInInspector] public bool hasBeastiary = false;
    [HideInInspector] public bool hasMaid = false;
    [HideInInspector] public bool hasMarmacEntity = false;
    [HideInInspector] public bool hasMarmacBio = false;
    [HideInInspector] public bool hasMap = false;

    [SerializeField] AudioSource insideM;
    [SerializeField] AudioSource outsideM;
    [SerializeField] AudioSource churchM;

    [HideInInspector] public bool no;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        hasBeastiary = false;
        hasMaid = false;
        hasMarmacEntity = false;
        hasMarmacBio = false;
        hasMap = false;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == ("MainMenu"))
        {
            MainMenuMusic();
            numenCount = 0;
            bookCount = 0;
            no = false;

            hasBeastiary = false;
            hasMaid = false;
            hasMarmacEntity = false;
            hasMarmacBio = false;
            hasMap = false;
        }

        if (SceneManager.GetActiveScene().name == ("Outside"))
        {
            OutsideMusic();
        }
    }


    void MainMenuMusic()
    {
        if (churchM.enabled == true)
        {
            churchM.enabled = false;
        }
        if (insideM.enabled == true)
        {
            insideM.enabled = false;
        }
        if (outsideM.enabled == true)
        {
            outsideM.enabled = false;
        }
    }

    void OutsideMusic()
    {
        if (outsideM.enabled == false && churchM.enabled == false)
        {
            insideM.enabled = false;
            outsideM.enabled = true;
        }
    }

    public void ChangeOutsideMusic()
    {
        if (churchM.enabled == false)
        {
            churchM.enabled = true;
            outsideM.enabled = false;
        }
    }

    public void PauseMusicInside()
    {
        insideM.Pause();
    }

    public void PlayMusicInside()
    {
        insideM.Play();
    }

}
