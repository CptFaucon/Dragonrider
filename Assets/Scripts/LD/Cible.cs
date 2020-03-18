using UnityEngine;

public class Cible : Hittable
{
    private ScoreManager sm;
    private ParticleSystem particle;
    //private TutorialManager tm;

    public float scoreBonus;

    public override void OnHit()
    {
        if (particle = null)
        {
            sm = FindObjectOfType<ScoreManager>();
            //tm = FindObjectOfType<TutorialManager>();
            particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        }
        if (!particle.isPlaying)
        {
            particle.Play();
            sm.modifyScore(scoreBonus);
            //if (GameObject.Find("TutorialTextBox") != null) tm.TargetHit();
        }
    }
}
