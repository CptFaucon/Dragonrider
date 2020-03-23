﻿using UnityEngine;

public class DodgeObstacle : MonoBehaviour
{
    private ScoreManager sm;
    private Obstacle o;
    private TutorialManager tm;

    public bool hasDodged;

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        tm = FindObjectOfType<TutorialManager>();
        o = GetComponentInParent<Obstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hasDodged = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (o.hasCollided == false)
        {
            sm.modifyScore(o.scoreBonus);
            if (GameObject.Find("TutorialTextBox") != null) tm.ObstacleDodged();
        }
    }
}
