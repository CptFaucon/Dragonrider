using UnityEngine;
using System.Collections;

public class Obstacle : Scorable
{
    private PlayerController pc;
    private ScoreManager sm;
    private Renderer r;
    private TutorialManager tm;

    public bool hasCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (r = null)
        {
            sm = FindObjectOfType<ScoreManager>();
            r = GetComponent<Renderer>();
            pc = FindObjectOfType<PlayerController>();
            GetComponentInChildren<avoidObstacle>().Assign(sm, this);
        }
        sm.modifyScore(scoreMalus);
        r.enabled = false;
        hasCollided = true;
        StartCoroutine(ReEnable());
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
