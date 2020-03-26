using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource enemyDie;
    public AudioSource enemyEntry;
    public AudioSource target;
    public AudioSource menuNavig;
    public AudioSource menuValid;
    public AudioSource playerAttack;
    public AudioSource playerCollide;
    public AudioSource playerDodge;
    public AudioSource playerWings;

    private void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu_Test")) StartCoroutine(WingDelay());
    }

    IEnumerator WingDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5015f);
            playerWings.Play();
            yield return new WaitForSeconds(0.5015f);
        }
    }
}
