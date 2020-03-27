using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Main menu
    public Button Play;
    public Button Credits;
    public Button Quit;

    // Play menu
    public Button Tutorial;
    public Button Game;
    public Button BackPlay;

    // Credits menu
    public Button BackCredits;

    // Layers
    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject CreditsMenu;
    public GameObject Intro;

    //Lien vers les sons
    private SoundManager sdm;


    // Start is called before the first frame update
    void Start()
    {
        Intro.SetActive(true);
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);

        sdm = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Intro.activeSelf)
        {
            if (Input.GetKeyDown("i") || Input.GetKeyDown("o") || Input.GetKeyDown("p") || Input.GetKeyDown("k") || Input.GetKeyDown("l") || Input.GetKeyDown("m"))
            {
                Debug.Log("Accès au menu principal");
                Intro.SetActive(false);
                MainMenu.SetActive(true);
            }
        }

        if (MainMenu.activeSelf)
        {
            if (Input.GetKeyDown("i"))
            {
                Debug.Log("Accès au jeu");
                Play.Select();
                MainMenu.SetActive(false);
                PlayMenu.SetActive(true);
                sdm.menuValid.Play();
            }

            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Accès aux crédits");
                Credits.Select();
                MainMenu.SetActive(false);
                CreditsMenu.SetActive(true);
                sdm.menuValid.Play();
            }

            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Quitter le jeu");
                Quit.Select();
                sdm.menuValid.Play();
                Application.Quit();
            }
        }

        if (PlayMenu.activeSelf)
        {
            if ((Input.GetKeyDown("i")) | (Input.GetKeyDown("k")))
            {
                Debug.Log("Jouer avec le tuto");
                Tutorial.Select();
                sdm.menuValid.Play();
                SceneManager.LoadScene(1);
            }

            if ((Input.GetKeyDown("p")) | (Input.GetKeyDown("m")))
            {
                Debug.Log("Jouer directement");
                Game.Select();
                sdm.menuValid.Play();
                SceneManager.LoadScene(2);
            }

            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Sortir du play");
                BackPlay.Select();
                PlayMenu.SetActive(false);
                MainMenu.SetActive(true);
                sdm.menuValid.Play();
            }
        }

        if (CreditsMenu.activeSelf)
        {
            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Sortir des crédits");
                BackCredits.Select();
                CreditsMenu.SetActive(false);
                MainMenu.SetActive(true);
                sdm.menuValid.Play();
            }
        }
    }
}
