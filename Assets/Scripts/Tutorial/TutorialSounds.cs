using UnityEngine;

public class TutorialSounds : MonoBehaviour
{
    [Header("Le tableau contenant tous les sons")]
    public GameObject[] sounds;

    private void Start()
    {
        sounds = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) sounds[i] = transform.GetChild(i).gameObject;
    }
}
