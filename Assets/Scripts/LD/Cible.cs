using UnityEngine;

public class Cible : Hittable
{
    private ScoreManager sm;
    private ParticleSystem particle;
    public float scoreBonus;

    public override void OnHit()
    {
        if (particle = null)
        {
            sm = FindObjectOfType<ScoreManager>();
            particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        }
        if (!particle.isPlaying)
        {
            particle.Play();
            sm.modifyScore(scoreBonus);
        }
    }
}
