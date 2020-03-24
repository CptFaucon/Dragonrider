using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Button Play;
    public Button Settings;
    public Button Credits;
    public Button Quit;
    public Button Back;

    public GameObject MainMenu;
    public GameObject SettingsMenu;


    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
            }

            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Accès aux crédits");
                Credits.Select();
            }

            if (Input.GetKeyDown("l"))
            {
                if (MainMenu.activeSelf)
                {
                    Debug.Log("Quitter le jeu");
                    Quit.Select();
                }

                else if (SettingsMenu.activeSelf)
                {
                    Debug.Log("Revenir au menu principal");
                    Back.Select();
                    MainMenu.SetActive(true);
                    SettingsMenu.SetActive(false);
                }
        }
    }
}
