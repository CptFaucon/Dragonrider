using UnityEngine;
using System.Collections.Generic;

public class Cible : Hittable
{
    private ScoreManager sm;
    private List<ParticleSystem> particle = new List<ParticleSystem>();

    public float scoreBonus;

    public override void OnHit()
    {
        if (particle.Count == 0)
        {
            sm = FindObjectOfType<ScoreManager>();
            for (int i = 0; i < 3; i++)
            {
                particle.Add(transform.GetChild(0).GetChild(i).GetComponent<ParticleSystem>());
            }
        }
        if (!particle[0].isPlaying)
        {
            foreach (var item in particle)
            {
                item.Play();
            }
            sm.modifyScore(scoreBonus);
        }
    }
}