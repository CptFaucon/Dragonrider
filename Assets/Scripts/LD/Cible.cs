using UnityEngine;

public class Cible : Hittable
{
    private ScoreManager sm;
    private ParticleSystem particle;
    private Renderer r;
    public float scoreBonus;

    public override void OnHit()
    {
        if (particle = null)
        {
            sm = FindObjectOfType<ScoreManager>();
            particle = transform.GetChild(0).GetComponent<ParticleSystem>();
            r = GetComponent<MeshRenderer>();
        }
        if (!particle.isPlaying)
        {
            r.enabled = false;
            particle.Play();
            sm.modifyScore(scoreBonus);
        }
    }
}
