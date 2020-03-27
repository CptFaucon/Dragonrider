using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource enemyDie;
    public AudioSource enemyEntry;
    public AudioSource target;
    public AudioSource wind;
    public AudioSource menuNavig;
    public AudioSource menuValid;
    public AudioSource playerAttack;
    public AudioSource playerCollide;
    public AudioSource playerDodge;
    public AudioSource playerWings;

    private void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu_Test"))
        {
            wind.Play();
            wind.loop = true;
        }
    }

    public void WingSound()
    {
        playerWings.Play();
    }
}
