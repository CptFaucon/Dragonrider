using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private SoundManager sdm;

    private void Start()
    {
        sdm = FindObjectOfType<SoundManager>();
    }

    public void CallSound()
    {
        sdm.WingSound();
    }
}
