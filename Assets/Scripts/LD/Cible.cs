using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cible : Hittable
{
    private ScoreManager sm;
    private List<ParticleSystem> particle = new List<ParticleSystem>();
    private Renderer rend;
    private PlayerController pc;
    private TutorialManager tm;
    private SoundManager sdm;

    public bool touched;

    public override void OnHit()
    {
        if (particle.Count == 0)
        {
            sm = FindObjectOfType<ScoreManager>();
            rend = GetComponent<Renderer>();
            pc = FindObjectOfType<PlayerController>();
            tm = FindObjectOfType<TutorialManager>();
            sdm = FindObjectOfType<SoundManager>();
            for (int i = 0; i < 3; i++)
            {
                particle.Add(transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>());
            }
        }
        if (!particle[0].isPlaying)
        {
            foreach (var item in particle)
            {
                item.Play();
            }
            sm.modifyScore(scoreBonus);
            touched = true;
            sdm.target.Play();
            if (GameObject.Find("TutorialTextBox") != null) tm.TargetHit();
            rend.enabled = false;
            StartCoroutine(ReAppearance());
        }
    }

    private IEnumerator ReAppearance()
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
        rend.enabled = true;
    }
}