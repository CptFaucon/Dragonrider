using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Main menu
    public Button Play;
    public Button Settings;
    public Button Credits;
    public Button Quit;

    // Settings menu
    public GameObject Music;
    public GameObject MusicSlider;
    public GameObject SFX;
    public GameObject SFXSlider;
    public GameObject Voices;
    public GameObject VoicesSlider;
    public Button BackSettings;

    // Play menu
    public Button Tutorial;
    public Button Game;
    public Button BackPlay;

    // Credits menu
    public Button BackCredits;

    // Layers
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject PlayMenu;
    public GameObject CreditsMenu;


    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        PlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);

        MusicSlider.SetActive(false);
        SFXSlider.SetActive(false);
        VoicesSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.activeSelf)
        {
            if (Input.GetKeyDown("i"))
            {
                Debug.Log("Accès aux settings");
                Settings.Select();
                SettingsMenu.SetActive(true);
                MainMenu.SetActive(false);
            }

            if (Input.GetKeyDown("o"))
            {
                Debug.Log("Accès au jeu");
                Play.Select();
                PlayMenu.SetActive(true);
                MainMenu.SetActive(false);
            }

            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Accès aux crédits");
                Credits.Select();
                CreditsMenu.SetActive(true);
                MainMenu.SetActive(false);
            }

            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Quitter le jeu");
                Quit.Select();
            }
        }

        if (SettingsMenu.activeSelf)
        {
            if (Input.GetKeyDown("i"))
            {
                Debug.Log("Sélection du slider music");
                //Music.Select();
                MusicSlider.SetActive(true);
                SFXSlider.SetActive(false);
                VoicesSlider.SetActive(false);
            }

            if (Input.GetKeyDown("o"))
            {
                Debug.Log("Sélection du slider voices");
                //Voices.Select();
                VoicesSlider.SetActive(true);
                SFXSlider.SetActive(false);
                MusicSlider.SetActive(false);
            }

            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Sélection du slider SFX");
                //SFX.Select();
                SFXSlider.SetActive(true);
                VoicesSlider.SetActive(false);
                MusicSlider.SetActive(false);
            }

            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Sortir des settings");
                BackSettings.Select();
                MainMenu.SetActive(true);
                SettingsMenu.SetActive(false);
            }
        }

        if (PlayMenu.activeSelf)
        {
            if ((Input.GetKeyDown("i")) | (Input.GetKeyDown("k")))
            {
                Debug.Log("Jouer avec le tuto");
                Tutorial.Select();
                SceneManager.LoadScene(1);
            }

            if ((Input.GetKeyDown("p")) | (Input.GetKeyDown("m")))
            {
                Debug.Log("Jouer directement");
                Game.Select();
                SceneManager.LoadScene(2);
            }

            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Sortir du play");
                BackPlay.Select();
                MainMenu.SetActive(true);
                PlayMenu.SetActive(false);
            }
        }

        if (CreditsMenu.activeSelf)
        {
            if (Input.GetKeyDown("l"))
            {
                Debug.Log("Sortir des crédits");
                BackCredits.Select();
                MainMenu.SetActive(true);
                CreditsMenu.SetActive(false);
            }
        }
    }
}
