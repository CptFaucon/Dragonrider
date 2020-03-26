using UnityEngine;
using System.Collections;

public class Obstacle : Scorable
{
    private PlayerController pc;
    private ScoreManager sm;
    private Renderer r;
    private TutorialManager tm;
    private SoundManager sdm;

    public bool hasCollided;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        r = GetComponent<Renderer>();
        pc = FindObjectOfType<PlayerController>();
        tm = FindObjectOfType<TutorialManager>();
        sdm = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sm.modifyScore(scoreMalus);
        r.enabled = false;
        hasCollided = true;
        StartCoroutine(ReEnable());
        sdm.playerCollide.Play();
        if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleTouched();
    }

    private IEnumerator ReEnable()
    {
        int i = 0;
        while (i < 2 / Time.fixedDeltaTime)
        {
            if (!pc.isOnPause)
            {
                i++;
            }
            yield return new WaitForFixedUpdate();
        }
        r.enabled = true;
        hasCollided = false;
    }
}
